namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IUserService
    {
        bool DeleteUserById(int id);
        bool RecoverUserByEmail(string email);
    }
}