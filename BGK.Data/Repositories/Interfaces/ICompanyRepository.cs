using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ICompanyRepository
    {
        int RegistrationCompany(Company company);
        Company? GetCompanyByEmail(string email);
        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        void UpdateCompany(Company company);
        void ChangePasswordCompany(string password, Company company);
        Company Login(string email);
    }
}