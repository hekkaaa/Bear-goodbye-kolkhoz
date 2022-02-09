using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository? _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

        }

        public CompanyModel GetCompanyById(int id)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new Exception("Такой Компания не существует.");

            return CustomMapper.GetInstance().Map<CompanyModel>(company);
        }

        public List<CompanyModel> GetCompanies()
        {
            List<Company> companies = _companyRepository.GetCompanies();

            return CustomMapper.GetInstance().Map<List<CompanyModel>>(companies);

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

            _companyRepository.RegistrCompany(CustomMapper.GetInstance().Map<Company>(mappedCompany));
        }



        public void UpdateCompany(CompanyModel companyModel)
        {
            var company = _companyRepository.GetCompanyById(companyModel.Id);

            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            _companyRepository.UpdateCompany(CustomMapper.GetInstance().Map<Company>(companyModel));

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
