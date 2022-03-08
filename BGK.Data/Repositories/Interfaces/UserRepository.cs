using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _db;

        public UserRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public User? GetUserByEmail(string email) =>
            _db.User.FirstOrDefault(x => x.Email == email);

        public User? GetUserById(int Id) =>
            _db.User.FirstOrDefault(x => x.Id == Id);

        public bool ChangeDeleteStatusUser(User item, bool isDeleted)
        {
            item.IsDeleted = isDeleted;
            _db.SaveChanges();
            return true;
        }


    }
}