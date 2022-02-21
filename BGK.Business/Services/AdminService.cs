using AutoMapper;
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
            return _mapper.Map<AdminModel>(_repository.GetAdminById(id));
        }

        public List<AdminModel> GetAdminAll()
        {
            return _mapper.Map<List<AdminModel>>(_repository.GetAdminAll());
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
                var item = _mapper.Map<Admin>(newItem);
                item.Role = Data.Enums.Role.Admin;
                item.IsDeleted = false; // делам при создании нового админа статус НЕзаблокирован по умолчанию.

                return _repository.AddNewAdmin(item);
            }
        }

        public bool DeleteAdmin(int id)
        {
            var item = _repository.GetAdminById(id);

            if (item == null)
            {
                throw new EntryPointNotFoundException();
            }
            else
            {

                return _repository.DeleteAdminById(item.Id);
            }

        }

        public bool UpdateAdminInfo(int id, AdminModel newItem)
        {
            var existingAdmin = _repository.GetAdminById(id);

            // Проверка на присутсвие нужного обьекта по id
            if (existingAdmin == null)
            {
                throw new NotFoundException("The object with the specified id does not exist | Обьекта с указанным id не существет");
            }
            // Проверяем изменяется ли Email.
            if(existingAdmin.Email != newItem.Email)
            {
                bool res = CheckDublicateEmailUpdateAdmin(id, newItem.Email);
                if(res) throw new DuplicateException("User with this Email already exists | Пользователь с таким Email уже существует ");
            }

            var modifiedAdmin = _mapper.Map<Admin>(newItem);
            return _repository.UpdateAdminInfo(existingAdmin, modifiedAdmin);
        }

        public bool ChangeAdminPassword(int id, AdminModel newData)
        {
            return _repository.ChangePasswordAdmin(id, _mapper.Map<Admin>(newData));
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
            // Ищем совпадения по Email отталкиваясь от изменяемого ID.
            var res = allList.Where(a => a.Email == email).Where(x=>x.Id < id || x.Id > id).Count();

            if(res != 0)
            {
                return true;
            }
            return false;
        }
    }
}
