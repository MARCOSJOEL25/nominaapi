using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> ObtenerAsync(int id);

        Task<IReadOnlyList<T>> ObtenerTodosAsync();
    }
}