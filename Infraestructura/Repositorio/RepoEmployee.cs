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
using API.Utils;

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
                employee.salaryFinal = calcularDeducciones(employee.netSalary);
                _db.employees.Update(employee);
                await _db.SaveChangesAsync();
                return "updated";
            }
            employee.salaryFinal = calcularDeducciones(employee.netSalary);
            _db.employees.Add(employee);
            await _db.SaveChangesAsync();
            return "created";

        }

        public async Task<string> DesactiveEmployee(int id)
        {   
            var employee = await _db.employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee == null)
            {
                return "not found";
            }

            employee.isActive = false;
            _db.employees.Update(employee);
            await _db.SaveChangesAsync();
            return "fired";
        }

        private double calcularDeducciones(double salary) 
        {
            salary = salary - ((salary * Deducciones.AFP) + (salary * Deducciones.ASF));
            if(salary >= Deducciones.limitISR)
                return salary - (salary * Deducciones.ISR);
            return salary;
        }
    }
}