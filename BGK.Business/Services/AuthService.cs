using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class AuthService
    {
        private readonly ILecturerRepository _lecturerRepo;
        private readonly IMapper _mapper;

        public AuthService(ILecturerRepository lecturerRepo, IMapper mapper)
        {
            _lecturerRepo = lecturerRepo;
            _mapper = mapper;
        }

        public LecturerModel LoginLecturer(string email, string password)
        {
            Lecturer entity = _lecturerRepo.Login(email, password);
            return _mapper.Map<LecturerModel>(entity);
        }
    }
}
