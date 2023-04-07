using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using core.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Especificaciones;
using Core.models.Dto;
using AutoMapper;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Metrics;
using Core.models;
using API.Utils;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class employeesController : ControllerBase
    {
        private readonly IRepositorio<employees> _repo;
        public IMapper _Mapper;
        private readonly IRepoEmployee _RepoEmployee;

        protected DtoResponse _response;

        public employeesController(IRepositorio<employees> repo, IMapper mapper, IRepoEmployee RepoEmployee)
        {
            _RepoEmployee = RepoEmployee;
            _Mapper = mapper;
            _repo = repo;
            _response = new DtoResponse();
        }

        [HttpGet(Name = nameof(GetAllemployees))]

        public async Task<ActionResult<EmployeeTotal>> GetAllemployees(int page = 1, int pageSize = 3)
        {
            var espec = new EspecificacionesEmployee();
            var results = await _repo.ObtenerTodosEspec(espec);
            var res = _Mapper.Map<IReadOnlyList<employees>, IReadOnlyList<DtoEmployees>>(results);

            foreach (var item in res)
            {
                await calcularImpuestosAsync(item);
            }

            //repsonse & pagination
            EmployeeTotal respuesta = new EmployeeTotal();
            respuesta.total = res.Count;

            List<DtoEmployees> employeesActive = new List<DtoEmployees>();
            List<DtoEmployees> employeesInactive = new List<DtoEmployees>();

            foreach (var employeesItem in res)
            {
                if (employeesItem.isActive)
                {
                    employeesActive.Add(employeesItem);
                }
                else
                {
                    employeesInactive.Add(employeesItem);
                }
            }
            respuesta.totalactive = employeesActive.Count;
            respuesta.totalinactive = employeesInactive.Count;

            respuesta.active = employeesActive
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArray();
            respuesta.totalPages = (int)Math.Ceiling((decimal)respuesta.total / pageSize);
            respuesta.inactive = employeesInactive.ToArray();
            respuesta.Page = page;

            return Ok(respuesta);
        }

        private async Task calcularImpuestosAsync(DtoEmployees employee)
        {
            if(employee.salaryFinal >= Deducciones.limitISR)
            {
                employee.ISR = (int)(employee.netSalary * Deducciones.ISR);
            }
            employee.AFP = (int)(employee.netSalary * Deducciones.AFP);
            employee.ARS = (int)(employee.netSalary * Deducciones.ASF);
            employee.Adiccion = await _RepoEmployee.searchAdicciones(employee.Id);
            employee.salaryFinal = employee.salaryFinal + employee.Adiccion;

        }

        [HttpGet("{id:int}", Name = nameof(GetemployeeById))]
        public async Task<ActionResult<DtoEmployees>> GetemployeeById(int id)
        {
            var espec = new EspecificacionesEmployee(id);
            var results = await _repo.obtenerEspec(espec);
            return Ok(_Mapper.Map<employees, DtoEmployees>(results));
        }

        [HttpGet("{search}/{isActive}", Name = nameof(GetemployeeBySearch))]
        public async Task<ActionResult<DtoEmployees>> GetemployeeBySearch(string search, bool isActive)
        {
            var espec = new EspecificacionesEmployee(search);
            var results = await _repo.ObtenerTodosBySearh(espec);
            var resp = _Mapper.Map<IReadOnlyList<employees>, IReadOnlyList<DtoEmployees>>(results);

            List<DtoEmployees> respuesta = new List<DtoEmployees>();

            foreach (var item in resp)
            {
                if (isActive)
                {
                    if (item.isActive)
                    {
                        respuesta.Add(item);
                    }
                } else 
                {
                    if (!item.isActive)
                    {
                        respuesta.Add(item);
                    }
                }
            }

            return Ok(respuesta);
        }


        [HttpPost(Name = nameof(CreateOrUpdateEmployee))]
        public async Task<ActionResult<DtoResponse>> CreateOrUpdateEmployee([FromBody] DtoEmployeesCreate dtoEmployees)
        {

            var resp = await _RepoEmployee.CreateOrUpdate(dtoEmployees);
            if (resp == "updated")
            {
                _response.results = null;
                _response.message = "se ha actualizado exitosamente";
                return Ok(_response);
            }

            _response.results = null;
            _response.message = "se ha creado exitosamente";
            return Ok(_response);
        }

        [HttpDelete]

        public async Task<ActionResult<DtoResponse>> Delete(int id)
        {
            var resp = await _RepoEmployee.DesactiveEmployee(id);
            if (resp == "not found")
            {
                _response.results = null;
                _response.message = "no fue encontrado";
                return Ok(_response);
            }

            _response.results = null;
            _response.message = "Se ha despido este empleado";
            return Ok(_response);
        }


        [HttpPost("/adiccion", Name = nameof(Adicciones))]
        public async Task<ActionResult<DtoResponse>> Adicciones([FromBody] DtoAdiccion _adicción) 
        {
            var resp = await _RepoEmployee.Adicciones(_adicción);
            if(resp == "not found")
            {
                _response.message = "No encontrado";
                _response.statusCode = 404;
                Console.Write("prueba");
                return Ok(_response);
            }

            _response.message = "Accion completada";
            _response.statusCode = 200;
            return Ok(_response);

        }


        [HttpGet("prestaciones/{id}")]

        public async Task<ActionResult<DtoResponsePrestaciones>> GetPrestaciones(int id)
        {

            //
            DateTime fechaUno = Convert.ToDateTime("2013-12-24 13:30:15");
            DateTime fechados = Convert.ToDateTime("2018-06-15 09:30:00");

            TimeSpan difFechas = fechados - fechaUno;
            //var días = difFechas.Days;

            Console.WriteLine(difFechas.Days);

            //
            var espec = new EspecificacionesEmployee(id);
            var results = await _repo.obtenerEspec(espec);
            var _DtoResponsePrestaciones = new DtoResponsePrestaciones();
            _DtoResponsePrestaciones.NombreEmpleado = results.FullName;
            _DtoResponsePrestaciones.salarioDelEmpleado = results.netSalary;
            _DtoResponsePrestaciones.TiempoEmpresa = difFechas.Days >= 365
                ? (difFechas.Days / 365).ToString() + " años " + (difFechas.Days % 30).ToString() + " Meses y " + ((difFechas.Days % 356) % 30).ToString() + " dias" 
                : (difFechas.Days / 30).ToString() + " Meses y " + (difFechas.Days % 30).ToString() + " dias";
            _DtoResponsePrestaciones.PrestacionesTotales = calculadoraDePrestaciones(results.netSalary, difFechas.Days);
            return Ok(_DtoResponsePrestaciones);
        }

        private double calculadoraDePrestaciones(double salario, int totaldays)
        {
            if (totaldays < 90)
            {
                return 0;
            }
            if(totaldays > 90 && totaldays < 180) {
                return (salario / 30) * 10;
            }
            if (totaldays > 180 && totaldays < 365)
            {
                return (30 / salario) * 15;
            }
            var isYears = (int)totaldays / 365;
            return (salario / 30) * (isYears * 15);

            // Relación laboral de 3 meses a 6 meses: 6 días de salario ordinario.

            //• Relación laboral de 6 meses a 1 año: 13 días de salario ordinario.

            //• Relación laboral mayor a 1 año y no mayor a 5 años: 21 días de salario ordinario.

            //• Relación laboral mayor a 5 años: 23 días de salario ordinario.
        }
       
    }
}