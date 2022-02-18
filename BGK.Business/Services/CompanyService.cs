using AutoMapper;
using BearGoodbyeKolkhozProject.API.Configuration;
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
                throw new BusinessException("Такой Компания не существует.");

            return _mapper.Map<CompanyModel>(company);
        }

        public List<CompanyModel> GetCompanies()
        {
            List<Company> companies = _companyRepository.GetCompanies();

            return _mapper.Map<List<CompanyModel>>(companies);

        }

        public void RegistrCompany(CompanyModel companyModel)
        {

            var mappedCompany = new Company
            {

                Email = companyModel.Email,
                Password = companyModel.Password,
                Name = companyModel.Name,
                PhoneNumber = companyModel.PhoneNumber,
                Tin = companyModel.Tin,
                IsDeleted = companyModel.IsDeleted

            };

            _companyRepository.RegistrCompany(_mapper.Map<Company>(mappedCompany));
        }



        public void UpdateCompany(CompanyModel companyModel)
        {
            var company = _companyRepository.GetCompanyById(companyModel.Id);

            if (company == null)
                throw new BusinessException("Такой Компании не существует.");

            

            _companyRepository.UpdateCompany(_mapper.Map<Company>(companyModel));

        }



        public void DeleteCompany(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            _companyRepository.DeleteCompany(id);

        }

        public void UpdateCompany(int id, bool isDel)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            _companyRepository.UpdateCompany(id, isDel);
        }

        
    }
}
