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
        private readonly IMapper _mapper;
         
        public employeesController
        (
            IRepositorio<employees> repo,
            IMapper mapper
        )
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<IReadOnlyList<DtoEmployees>>>> GetAllemployees()
        {
            var espec = new EspecificacionesEmployee();
            var employees = await _repo.ObtenerTodosEspec(espec);
            return Ok(_mapper.Map<IReadOnlyList<employees>, IReadOnlyList<DtoEmployees>>(employees));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DtoEmployees>> GetemployeeById(int id)
        {
            var espec = new EspecificacionesEmployee(id);
            var employee = await _repo.obtenerEspec(espec);
            return Ok(_mapper.Map<employees, DtoEmployees>(employee));
        }
    }
}