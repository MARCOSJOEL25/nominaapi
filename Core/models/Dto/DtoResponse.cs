using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.models.Dto
{
    public class DtoResponse
    {
        public object results { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }
}