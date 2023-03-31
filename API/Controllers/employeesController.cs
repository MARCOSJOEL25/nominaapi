using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using core.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class employeesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
         
        public employeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<employees>>> GetAllemployees()
        {
            return Ok(await _db.employees.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<employees>> GetemployeeById(int id)
        {
            return Ok(await _db.employees.FirstOrDefaultAsync(item => item.Id == id ));

        }
    }
}