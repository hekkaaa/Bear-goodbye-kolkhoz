using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
                Lecturer entity = _lecturerRepo.Login(email, password);

                claims = new List<Claim> {
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                    new Claim(ClaimTypes.Role, entity.Role.ToString())
                };
            }

            else if (role == "Admin")
            {
                Admin entity = _adminRepo.Login(email, password);

                claims = new List<Claim> {
                new Claim(ClaimTypes.Email, entity.Email),
                new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                new Claim(ClaimTypes.Role, entity.Role.ToString())
                };
            }

            else if (role == "Client")
            {   
                Client entity = _userRepo.Login(email, password);
                claims = new List<Claim> {
                new Claim(ClaimTypes.Email, entity.Email),
                new Claim(ClaimTypes.UserData, entity.Id.ToString()),
                new Claim(ClaimTypes.Role, entity.Role.ToString())
                };
            }
            else
            {
                //throw new NoRole();
            }
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.Issuer,
                            audience: AuthOptions.Audience,
                            claims: claims,
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

    };
}

