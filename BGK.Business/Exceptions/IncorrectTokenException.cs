using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Exceptions
{
    public class IncorrectTokenException : Exception
    {
        public IncorrectTokenException(string message) : base(message)
        {

        }
    }
}
