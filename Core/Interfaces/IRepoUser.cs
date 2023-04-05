using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public  interface IRepoUser
    {
        Task<int> Register(user user, string password);
        Task<string> login(string userName, string password);
        Task<bool> UserExiste(string username);
    }
}
