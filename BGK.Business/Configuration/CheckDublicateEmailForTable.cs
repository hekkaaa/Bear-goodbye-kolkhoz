using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Configuration
{
    public class CheckDublicateEmailForTable
    {
        public static bool CheckDublicateEmailForTableUser(string email, IUserRepository _repository)
        {
            var res = _repository.GetUserByEmail(email);

            if (res is null)
            {
                return false;
            }
            else
            {
                throw new DuplicateException("User with this Email already exists | Пользователь с таким Email уже существует.");
            }
        }
    }
}
