using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByEmail(string email);
    }
}