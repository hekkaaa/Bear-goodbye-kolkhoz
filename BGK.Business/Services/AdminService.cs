using AutoMapper;
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
            return _repository.AddNewAdmin(_mapper.Map<Admin>(newItem));
        }

        public bool DeleteAdmin(int id)
        {
            return _repository.DeleteAdminById(id);
        }

        public bool UpdateAdminInfo(int id, AdminModel newItem)
        {
            var entities = _mapper.Map<Admin>(newItem);
            return _repository.UpdateAdminInfo(id, entities);
        }

        public bool ChangeAdminPassword(int id, AdminModel newData)
        {
            return _repository.ChangePasswordAdmin(id, _mapper.Map<Admin>(newData));
        }
    }
}
