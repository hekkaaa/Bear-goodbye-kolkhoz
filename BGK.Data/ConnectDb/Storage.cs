using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.ConnectDb
{
    public class Storage
    {
        private static ApplicationContext _context;
        private Storage()
        {

        }

        public static ApplicationContext GetStorage()
        {
            if (_context == null)
            {
                _context = new ApplicationContext();
            }
            return _context;
        }
    }
}