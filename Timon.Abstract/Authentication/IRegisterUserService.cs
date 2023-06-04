using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timon.Abstract.Authentication
{
    public interface IRegisterUserService
    {
        void Register(string username, string password);
    }
}
