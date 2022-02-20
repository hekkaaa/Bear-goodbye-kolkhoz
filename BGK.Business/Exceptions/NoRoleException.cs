using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Exceptions
{
    public class NoRoleException : Exception
    {
        public NoRoleException(string message) : base(message)
        {

        }
    }
}
