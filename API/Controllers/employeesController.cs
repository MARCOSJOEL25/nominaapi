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
        public async Task<ActionResult<List<DtoEmployees>>> GetAllemployees()
        {
            var espec = new EspecificacionesEmployee();
            var results = await _repo.ObtenerTodosEspec(espec);
            return Ok(_Mapper.Map<IReadOnlyList<employees>, IReadOnlyList<DtoEmployees>>(results));
        }

        [HttpGet("{id:int}", Name = nameof(GetemployeeById))]
        public async Task<ActionResult<DtoEmployees>> GetemployeeById(int id)
        {
            var espec = new EspecificacionesEmployee(id);
            var results = await _repo.obtenerEspec(espec);
            return Ok(_Mapper.Map<employees, DtoEmployees>(results));
        }

        [HttpGet("{search}", Name = nameof(GetemployeeBySearch))]
        public async Task<ActionResult<DtoEmployees>> GetemployeeBySearch(string search)
        {
            var espec = new EspecificacionesEmployee(search);
            var results = await _repo.ObtenerTodosBySearh(espec);
            return Ok(_Mapper.Map<IReadOnlyList<employees>, IReadOnlyList<DtoEmployees>>(results));
        }


        [HttpPost(Name = nameof(CreateOrUpdateEmployee))]
        public async Task<ActionResult<DtoResponse>> CreateOrUpdateEmployee([FromBody] DtoEmployeesCreate dtoEmployees)
        {

            var resp = await _RepoEmployee.CreateOrUpdate(dtoEmployees);
            if(resp == "updated")
            {
                _response.results = null;
                _response.message = "se ha actualizado exitosamente";
                return Ok(_response);
            }

            _response.results = null;
            _response.message = "se ha creado exitosamente";
            return Ok(_response);
        }
    }
}