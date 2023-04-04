using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.models;

namespace Core.Especificaciones
{
    public class EspecificacionesEmployee : EspecificacionesBase<employees>
    {
        public EspecificacionesEmployee() : base(x => x.isActive)
        {
            AgregarInclude(x => x.user);
            AgregarInclude(x => x.job);
        }

        public EspecificacionesEmployee(int id) : base(x => x.Id == id)
        {
            AgregarInclude(x => x.user);
            AgregarInclude(x => x.job);
        }

        public EspecificacionesEmployee(string search) : base(x => x.FullName.ToLower().Contains(search.ToLower()))
        {
            AgregarInclude(x => x.user);
            AgregarInclude(x => x.job);
        }
    }
}