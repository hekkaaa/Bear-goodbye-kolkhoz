using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public User GetUserByEmail(string email) =>
            _context.User.FirstOrDefault(x => x.Email == email);

        public User GetUserById(int id) =>
            _context.User.FirstOrDefault(x => x.Id == id);
    }
}
