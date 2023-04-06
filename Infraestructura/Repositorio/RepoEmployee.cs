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
using Microsoft.Extensions.DependencyInjection;
using Core.models;
using System.ComponentModel;

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
                employee.salaryFinal = (int)calcularDeducciones(employee.netSalary);
                _db.employees.Update(employee);
                await _db.SaveChangesAsync();
                return "updated";
            }
            employee.salaryFinal = (int)calcularDeducciones(employee.netSalary);
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
        public async Task<int> searchAdicciones(int id)
        {
            var addicion = await _db.adicción.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if(addicion == null)
            {
                return 0;
            }
            return (int)addicion.adicciónSalary;

        }
        public async Task<string> Adicciones(DtoAdiccion _adicción) 
        {
            var employee = await _db.employees.FirstOrDefaultAsync(x => x.Id == _adicción.EmployeeId);
            if(employee == null)
            {
                return "not found";
            }

            _db.adicción.Add(_mapper.Map<DtoAdiccion, adicción>(_adicción));
            await _db.SaveChangesAsync();
            return "Done";
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