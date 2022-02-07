

namespace BearGoodbyeKolkhozProject.Data.ConnectDb
{
    public class Storage
    {
        private static ApplicationContext? _context = new ApplicationContext();
        private Storage()
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