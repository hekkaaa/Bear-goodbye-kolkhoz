using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public string GetToken(string email, string password)
        {
            User entity = _userRepo.GetUserByEmail(email);

            if (entity is null)
            {
                throw new NotFoundException($"Нет пользователя с email = {email}");
            }
            if(entity.IsDeleted == true)
            {
                throw new UserIsBlockException("User deleted or blocked | Пользователь удален или заблокирован");
            }

            IsCorrectPassword(password, entity.Password);

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Email, entity.Email),
                new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                new Claim(ClaimTypes.Role, entity.Role.ToString())
            };
            

            var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.Issuer,
                            audience: AuthOptions.Audience,
                            claims: claims,
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private void IsCorrectPassword(string password, string hash)
        {
            if (!PasswordHash.ValidatePassword(password, hash))
            {
                throw new IncorrectPasswordException("Неверный пароль");
            }
        }
    };
}

