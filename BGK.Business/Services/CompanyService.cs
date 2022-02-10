using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;

namespace BearGoodbyeKolkhozProject.Business.Processor
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
                throw new NotAuthorizedException($"Такой Компании {id} не существует.");

            return _mapper.Map<CompanyModel>(company);
        }

        public List<CompanyModel> GetCompanies()
        {
            List<Company> companies = _companyRepository.GetCompanies();

            return _mapper.Map<List<CompanyModel>>(companies);

        }

        public void RegistrCompany(CompanyModel companyModel)
        {
            var company = _companyRepository.GetCompanyById(companyModel.Id);

            if (company != null)
                throw new NotAuthorizedException($"Такой Компании {company.Id} не существует.");

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
                throw new NotAuthorizedException($"Такой Компании {company.Id} не существует.");

            _companyRepository.UpdateCompany(_mapper.Map<Company>(companyModel));

        }



        public void DeleteCompany(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            _companyRepository.DeleteCompany(company);

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
