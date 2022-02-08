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

            if (company != null)
                throw new Exception("Такой Компания не существует.");

            return CustomMapper.GetInstance().Map<CompanyModel>(company);
        }

        public List<CompanyModel> GetCompanies()
        {
            List<Company> companies = _companyRepository.GetCompanies();

            return CustomMapper.GetInstance().Map<List<CompanyModel>>(companies);

        }

        public void AddCompany(CompanyModel companyModel)
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

            _companyRepository.AddCompany(CustomMapper.GetInstance().Map<Company>(mappedCompany));
        }



        public void UpdateCompany(int id, CompanyModel companyModel)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            var mappedCompany = new Company
            {
                Name = companyModel.Name,
                PhoneNumber = companyModel.PhoneNumber,
                Tin = companyModel.Tin,
                Password = companyModel.Password
            };


            _companyRepository.UpdateCompany(CustomMapper.Custom.Map<Company>(mappedCompany));

        }



        public void DeleteCompany(int id, bool isDel)
        {
            var company = _companyRepository.GetCompanyById(id);

            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            _companyRepository.UpdateCompany(id, isDel);

        }
    }
}
