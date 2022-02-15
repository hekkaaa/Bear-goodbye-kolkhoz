using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
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
    }
}
