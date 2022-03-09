using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool DeleteUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user is null)
            {
                throw new NotFoundException($"Нет пользователя c id = {id}");
            }

            if (user.IsDeleted == true)
            {
                throw new DuplicateException("The user has already been deleted/banned.");
            }

            var res = _repository.ChangeDeleteStatusUser(user, true);

            return res;
        }

        public bool RecoverUserByEmail(string email)
        {
            var user = _repository.GetUserByEmail(email);

            if (user is null)
            {
                throw new NotFoundException($"Нет пользователя c email = {email}");
            }

            if (user.IsDeleted == false)
            {
                throw new DuplicateException("The user has NOT been blocked.");
            }

            var res = _repository.ChangeDeleteStatusUser(user, false);

            return res;
        }
    }
}
