using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ICompanyRepository
    {
        int RegistrationCompany(Company company);
        void DeleteCompany(int id);
        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        void UpdateCompany(Company company);
        void UpdateCompany(int id, bool isDel);
        void ChangePasswordCompany(string password, Company company);
        Company Login(string email);
    }
}