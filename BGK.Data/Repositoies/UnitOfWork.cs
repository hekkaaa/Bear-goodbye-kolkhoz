using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.ConnectDb
{
    public class UnitOfWork
    {
        private static ApplicationContext? _context;
        private UnitOfWork()
        {

        }

        public static  ApplicationContext GetInstance()
        {
            if (_context == null)
            {
                _context = new ApplicationContext();
            }
            return _context;
        }

       
    }
}