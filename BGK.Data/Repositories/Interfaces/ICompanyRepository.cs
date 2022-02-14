using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ICompanyRepository
    {
        void RegistrCompany(Company company);
        void DeleteCompany(int id);
        List<Company> GetCompanies();
        Company GetCompanyById(int id);
        void UpdateCompany(Company company);
        void UpdateCompany(int id, bool isDel);
    }
}