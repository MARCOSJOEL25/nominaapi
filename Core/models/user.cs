using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.models
{
    public class user
    {
        public int Id { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        // public byte[] passwordsalt { get; set; }
        // public byte[] passwordHash { get; set; }
    }
}