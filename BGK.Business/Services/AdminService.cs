using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository repository,IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public AdminModel GetAdminById(int id)
        {
            var res = _mapper.Map<AdminModel>(_repository.GetAdminById(id));
            if (res == null)
            {
                throw new NotFoundException("Нет пользователя по указанному Id");
            }
            else
            {
                return res;
            }
        }

        public List<AdminModel> GetAdminAll()
        {
            var res = _mapper.Map<List<AdminModel>>(_repository.GetAdminAll());

            if (res == null)
            {
                throw new NotFoundException("Нет никаких пользователей в списке Администраторов");
            }
            else
            {
                return res;
            }
        }

        public int AddNewAdmin(AdminModel newItem)
        {
            CheckDublicateEmailForTable.CheckDublicateEmailForTableUser(newItem.Email, _userRepository);

            newItem.Password = PasswordHash.HashPassword(newItem.Password);
            var item = _mapper.Map<Admin>(newItem);
            item.Role = Data.Enums.Role.Admin;
            item.IsDeleted = false;

            return _repository.AddNewAdmin(item);
        }

        public bool UpdateAdminInfo(int id, AdminModel newItem)
        {
            var existingAdmin = _repository.GetAdminById(id);

            if (existingAdmin == null)
            {
                throw new NotFoundException("The object with the specified id does not exist | Обьекта с указанным id не существет");
            }

            CheckDublicateEmailForTable.CheckDublicateEmailForTableUser(newItem.Email, _userRepository);

            var modifiedAdmin = _mapper.Map<Admin>(newItem);
            return _repository.UpdateAdminInfo(existingAdmin, modifiedAdmin);
        }

        public bool ChangeAdminPassword(int id, string password)
        {
            var admin = _repository.GetAdminById(id);

            if (admin is null)
            {
                throw new NotFoundException($"Нет клиента с id = {id}");
            }

            string hashPassword = PasswordHash.HashPassword(password);
            return _repository.ChangePasswordAdmin(hashPassword, admin);
        }
    }
}
