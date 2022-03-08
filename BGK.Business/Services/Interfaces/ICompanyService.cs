using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public interface ICompanyService
    {
        int RegistrationCompany(CompanyModel companyModel);
        void DeleteCompany(int id);
        List<CompanyModel> GetCompanies();
        CompanyModel GetCompanyById(int id);
        void UpdateCompany(CompanyModel companyModel);
        void UpdatePasswordCompany(int id, string password);
        void RestoreCompany(int id);
    }
}