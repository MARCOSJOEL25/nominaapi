using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            
        }
        // public async Task<T> ObtenerAsync(int id)
        // {
        //     return await _db.Set<T>().FirstOrDefaultAsync(); 
        // }

        // public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        // {
            
        //     return await _db.Set<T>().ToListAsync(); 
        // }

        public async Task<T> obtenerEspec(IEspecificaciones<T> espec)
        {
            return await AplicarEspecificacion(espec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosEspec(IEspecificaciones<T> espec)
        {
            return await AplicarEspecificacion(espec).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosBySearh(IEspecificaciones<T> espec)
        {
            return await AplicarEspecificacion(espec).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> createOrUpdate(IEspecificaciones<T> espec)
        {
            return await AplicarEspecificacion(espec).ToListAsync();
        }

        private IQueryable<T> AplicarEspecificacion(IEspecificaciones<T> espec)
        {
            return EvaluatorEspecification<T>.GetQuery(_db.Set<T>().AsQueryable(), espec);
        }
    }
}