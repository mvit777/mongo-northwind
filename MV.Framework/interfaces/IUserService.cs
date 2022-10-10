using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MV.Framework.interfaces
{
    public interface IUserService
    {
        public bool LogIn(string username, string password);
        public void LogOut();
        public bool IsAdmin();
    }
}
