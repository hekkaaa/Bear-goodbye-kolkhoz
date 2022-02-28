using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
    }
}