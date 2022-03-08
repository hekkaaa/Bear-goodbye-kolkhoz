using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IUserRepository
    {
        bool ChangeDeleteStatusUser(User item, bool isDeleted);
        User? GetUserByEmail(string email);
        User? GetUserById(int Id);
    }
}