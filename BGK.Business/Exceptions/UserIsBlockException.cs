using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Exceptions
{
    public class UserIsBlockException : Exception
    {
        public UserIsBlockException(string message) : base(message)
        {
        }
    }
}
