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
        private readonly IRepoEmployee _repo;
         
        public employeesController(IRepoEmployee repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<employees>>> GetAllemployees()
        {
            return Ok(_repo.GetEmployees());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<employees>> GetemployeeById(int id)
        {
            return Ok(_repo.GetEmployeeById(id));

        }
    }
}