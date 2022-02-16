using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BearGoodbyeKolkhozProject.API.Configuration
{
    public class AuthOptions
    {
        public const string Issuer= "BearGoodbyeKolkhoz"; // издатель токена
        public const string Audience= "front"; // потребитель токена
        private const string _key = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 300; // время жизни токена - 300 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()=>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
        
    }
}
