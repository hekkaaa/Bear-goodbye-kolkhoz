using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
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
        private readonly IMapper _mapper;

        public AuthService(ILecturerRepository lecturerRepo, IMapper mapper)
        {
            _lecturerRepo = lecturerRepo;
            _mapper = mapper;
        }

        public string LoginLecturer(string email, string password)
        {
            Lecturer entity = _lecturerRepo.Login(email, password);

            var claims = new List<Claim> { 
                new Claim(ClaimTypes.Email, entity.Email),
                new Claim(ClaimTypes.UserData, entity.Id.ToString())
            };

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
