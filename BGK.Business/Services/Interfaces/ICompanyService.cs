using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public interface ICompanyService
    {
        void AddCompany(CompanyModel companyModel);
        void DeleteCompany(int id, bool isDel);
        List<CompanyModel> GetCompanies();
        CompanyModel GetCompanyById(int id);
        void UpdateCompany(int id, CompanyModel companyModel);
    }
}