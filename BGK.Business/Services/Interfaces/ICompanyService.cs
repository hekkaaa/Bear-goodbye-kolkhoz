using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public interface ICompanyService
    {
        void RegistrationCompany(CompanyModel companyModel);
        void DeleteCompany(int id);
        List<CompanyModel> GetCompanies();
        CompanyModel GetCompanyById(int id);
        void UpdateCompany(CompanyModel companyModel);

        void UpdateCompany(int id, bool isDel);
    }
}