using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;
using Core.Interfaces;
using Core.models.Dto;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;




namespace Infraestructura.Repositorio
{
    public class RepoEmployee : IRepoEmployee
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public RepoEmployee(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;

        }
        public async Task<string> CreateOrUpdate(DtoEmployeesCreate dtoEmployees)
        {
            var employee = _mapper.Map<DtoEmployeesCreate, employees>(dtoEmployees);
            if(employee.Id > 0)
            {
                _db.employees.Update(employee);
                await _db.SaveChangesAsync();
                return "updated";
            }
            _db.employees.Add(employee);
            await _db.SaveChangesAsync();
            return "created";

        }

        public Task<string> DesactiveEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}