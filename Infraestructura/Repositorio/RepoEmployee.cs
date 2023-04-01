using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;



namespace Infraestructura.Repositorio
{
    public class RepoEmployee : IRepoEmployee
    {
        private readonly ApplicationDbContext _db;
        public RepoEmployee(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<employees> GetEmployeeById(int id)
        {
            return await _db.employees.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IReadOnlyList<employees>> GetEmployees()
        {
            return await _db.employees.ToListAsync();

        }
    }
}