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

        private IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
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

        public void RegistrationCompany(CompanyModel companyModel)
        {
            companyModel.Password = PasswordHash.HashPassword(companyModel.Password);

            var mappedCompany = new Company
            {
                Email = companyModel.Email,
                Password = companyModel.Password,
                Name = companyModel.Name,
                PhoneNumber = companyModel.PhoneNumber,
                Tin = companyModel.Tin,
                IsDeleted = companyModel.IsDeleted
            };

            mappedCompany.Role = Data.Enums.Role.Company;

            _companyRepository.RegistrationCompany(_mapper.Map<Company>(mappedCompany));


        }


        public void UpdateCompany(CompanyModel companyModel)
        {
            var company = _companyRepository.GetCompanyById(companyModel.Id);

            if (company == null)
                throw new NotFoundException("Такой Компании не существует.");

            var entity = _mapper.Map<Company>(companyModel);

            _companyRepository.UpdateCompany(entity);

        }



        public void DeleteCompany(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NotFoundException("Такой Компании не существует.");

            _companyRepository.DeleteCompany(id);


        }

        public void UpdateCompany(int id, bool isDel)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NotFoundException("Такой Компании не существует.");

            _companyRepository.UpdateCompany(id, isDel);
        }

        public void UpdatePasswordCompany(int id, string password)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company is null)
            {
                throw new NotFoundException("Такой Компании не существует.");
            }

            string hashPassword = PasswordHash.HashPassword(password);
            _companyRepository.ChangePasswordCompany(hashPassword, company);
        }


    }
}
