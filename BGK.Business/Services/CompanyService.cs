using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository? _companyRepository;
        private readonly IUserRepository? _userRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository,IUserRepository userRepository,IMapper mapper)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public CompanyModel GetCompanyById(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NotFoundException("Такой Компания не существует.");

            return _mapper.Map<CompanyModel>(company);
        }

        public List<CompanyModel> GetCompanies()
        {
            List<Company> companies = _companyRepository.GetCompanies();

            return _mapper.Map<List<CompanyModel>>(companies);

        }

        public int RegistrationCompany(CompanyModel companyModel)
        {
            CheckDublicateEmailForTable.CheckDublicateEmailForTableUser(companyModel.Email, _userRepository);

            companyModel.Password = PasswordHash.HashPassword(companyModel.Password);
            var item = _mapper.Map<Company>(companyModel);

            return _companyRepository.RegistrationCompany(_mapper.Map<Company>(item));
          
        }

        public void UpdateCompany(CompanyModel companyModel)
        {
            var company = _companyRepository.GetCompanyById(companyModel.Id);

            if (company == null)
                throw new NotFoundException("Такой Компании не существует.");

            var entity = _mapper.Map<Company>(companyModel);

            _companyRepository.UpdateCompany(entity);

        }
        public bool UpdatePasswordCompany(int id, string password)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company is null)
            {
                throw new NotFoundException("Такой Компании не существует.");
            }

            string hashPassword = PasswordHash.HashPassword(password);
            return _companyRepository.ChangePasswordCompany(hashPassword, company);
        }
    }
}
