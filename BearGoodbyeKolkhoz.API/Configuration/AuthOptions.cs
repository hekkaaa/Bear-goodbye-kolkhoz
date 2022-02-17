using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BearGoodbyeKolkhozProject.API.Configuration
{
	public class AuthOptions
	{
		public const string Issuer = "BgkBack"; // издатель токена
		public const string Audience = "Client"; // потребитель токена

		private const string _key = "Сюда пихнуть ключ";   // ключ для шифрации

		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

	}
}
