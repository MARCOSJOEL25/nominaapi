using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;

namespace Core.Interfaces
{
    public interface IRepoEmployee
    {
        public Task<employees> GetEmployeeById(int id);
        public Task<IReadOnlyList<employees>> GetEmployees();
    }
}