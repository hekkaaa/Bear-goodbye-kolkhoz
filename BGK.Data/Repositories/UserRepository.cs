using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public User? GetUserByEmail(string email) =>
            _context.User.FirstOrDefault(x => x.Email == email);
    }
}