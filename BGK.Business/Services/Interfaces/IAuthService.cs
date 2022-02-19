namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IAuthService
    {
        string GetToken(string email, string password);
    }
}