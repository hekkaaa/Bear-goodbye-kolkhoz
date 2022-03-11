using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ICompanyRepository
    {
        int RegistrationCompany(Company company);
        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        void UpdateCompany(Company company);
        bool ChangePasswordCompany(string password, Company company);
        Company Login(string email);
    }
}