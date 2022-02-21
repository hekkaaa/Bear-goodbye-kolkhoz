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
        private readonly ILecturerRepository _lecturerRepo;
        private readonly IAdminRepository _adminRepo;
        private readonly IClientRepository _userRepo;

        public AuthService(ILecturerRepository lecturerRepo, IAdminRepository adminRepo, IClientRepository userRepo)
        {
            _lecturerRepo = lecturerRepo;
            _adminRepo = adminRepo;
            _userRepo = userRepo;
        }

        public string GetToken(string email, string password, string role)
        {
            List<Claim> claims = new List<Claim>();
            if (role == "Lecturer")
            {
                Lecturer entity = _lecturerRepo.Login(email);

                if (entity is null)
                {
                    throw new NotFoundException($"Нет пользователя с email = {email}");
                }

                IsCorrectPassword(password, entity.Password);

                // проверка на блок
                if(entity.IsDeleted == true)
                {
                    throw new UserIsBlockException("User deleted or blocked | Пользователь удален или заблокирован");
                }

                claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                    new Claim(ClaimTypes.Role, entity.Role.ToString())
                };
            }

            else if (role == "Admin")
            {
                Admin entity = _adminRepo.Login(email);

                if (entity is null)
                {
                    throw new NotFoundException($"Нет пользователя с email = {email}");
                }

                IsCorrectPassword(password, entity.Password);

                // проверка на блок
                if (entity.IsDeleted == true)
                {
                    throw new UserIsBlockException("User deleted or blocked | Пользователь удален или заблокирован");
                }

                claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                    new Claim(ClaimTypes.Role, entity.Role.ToString())
                };
            }

            else if (role == "Client")
            {
                Client entity = _userRepo.Login(email);

                if (entity is null)
                {
                    throw new NotFoundException($"Нет пользователя с email = {email}");
                }

                IsCorrectPassword(password, entity.Password);

                Client entity = _userRepo.Login(email, password);

                // проверка на блок
                if (entity.IsDeleted == true)
                {
                    throw new UserIsBlockException("User deleted or blocked | Пользователь удален или заблокирован");
                }

                claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                    new Claim(ClaimTypes.Role, entity.Role.ToString())
                };
            }
            else
            {
                throw new NoRoleException("Wrong role specified in JSON request | Не верно указана роль в JSON запросе");
            }

            // создаем JWT-токен
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

