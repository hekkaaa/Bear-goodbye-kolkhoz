using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var item = _mapper.Map<Admin>(newItem);
            item.Role = Data.Enums.Role.Admin;
            item.IsDeleted = false; // делам при создании нового админа статус НЕзаблокирован по умолчанию.
            return _repository.AddNewAdmin(item);
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
            if (existingAdmin == null)
            {
                throw new EntryPointNotFoundException();
            }
            else
            {
                var modifiedAdmin = _mapper.Map<Admin>(newItem);
                return _repository.UpdateAdminInfo(existingAdmin, modifiedAdmin);
            }
        }

        public bool ChangeAdminPassword(int id, AdminModel newData)
        {
            return _repository.ChangePasswordAdmin(id, _mapper.Map<Admin>(newData));
        }
    }
}
