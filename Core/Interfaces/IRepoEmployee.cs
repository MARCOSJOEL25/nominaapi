using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;
using Core.models;
using Core.models.Dto;

namespace Core.Interfaces
{
    public interface IRepoEmployee
    {
        public Task<string> CreateOrUpdate(DtoEmployeesCreate dtoEmployees);
        public Task<string> DesactiveEmployee(int id);
        public Task<string> Adicciones(adicción _adicción);
    }
}