using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using core.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class employeesController : ControllerBase
    {
        private readonly IRepositorio<employees> _repo;
         
        public employeesController(IRepositorio<employees> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<employees>>> GetAllemployees()
        {
            return Ok(await _repo.ObtenerTodosAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<employees>> GetemployeeById(int id)
        {
            return Ok(await _repo.ObtenerAsync(id));

        }
    }
}