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
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AdminModel GetAdminById(int id)
        {
            var res = _mapper.Map<AdminModel>(_repository.GetAdminById(id));
            if (res == null)
            {
                throw new EntryPointNotFoundException("Нет пользователя по указанному Id");
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
                throw new EntryPointNotFoundException("Нет никаких пользователей в списке Администраторов");
            }
            else
            {
                return res;
            }
        }

        public int AddNewAdmin(AdminModel newItem)
        {
            bool res = CheckDublicateEmailAddAdmin(newItem.Email);

            if (res)
            {
                throw new DuplicateException("User with this Email already exists | Пользователь с таким Email уже существует ");
            }
            else
            {
                newItem.Password = PasswordHash.HashPassword(newItem.Password);
                var item = _mapper.Map<Admin>(newItem);
                item.Role = Data.Enums.Role.Admin;
                item.IsDeleted = false; 

                return _repository.AddNewAdmin(item);
            }
        }

        public bool DeleteAdmin(int id)
        {
            var item = _repository.GetAdminById(id);

            if (item == null)
            {
                throw new EntryPointNotFoundException("Нет пользователя по указанному Id");
            }
            else
            {
                return _repository.DeleteAdminById(item.Id);
            }
        }

        public bool UpdateAdminInfo(int id, AdminModel newItem)
        {
            var existingAdmin = _repository.GetAdminById(id);

            if (existingAdmin == null)
            {
                throw new NotFoundException("The object with the specified id does not exist | Обьекта с указанным id не существет");
            }
            
            if(existingAdmin.Email != newItem.Email)
            {
                bool res = CheckDublicateEmailUpdateAdmin(id, newItem.Email);
                if(res) throw new DuplicateException("User with this Email already exists | Пользователь с таким Email уже существует ");
            }

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

        private bool CheckDublicateEmailAddAdmin(string email)
        {
            var allList = _repository.GetAdminAll();
            Admin res = allList.FirstOrDefault(a => a.Email == email);

            if (res == null)
            {
                return false;
            }
            return true;
        }

        private bool CheckDublicateEmailUpdateAdmin(int id, string email)
        {
            var allList = _repository.GetAdminAll();
            
            var res = allList.Where(a => a.Email == email).Where(x=>x.Id < id || x.Id > id).Count();

            if(res != 0)
            {
                return true;
            }
            return false;
        }
    }
}
