using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public interface ICompanyService
    {
        int RegistrationCompany(CompanyModel companyModel);
        List<CompanyModel> GetCompanies();
        CompanyModel GetCompanyById(int id);
        void UpdateCompany(CompanyModel companyModel);
        bool UpdatePasswordCompany(int id, string password);
    }
}