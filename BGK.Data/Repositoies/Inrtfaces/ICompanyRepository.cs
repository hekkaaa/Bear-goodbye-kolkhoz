using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        void DeleteCompany(int id);
        Company GetCompanyById(int id);
        List<Company> GetCompanies();
        void UpdateCompany(Company company);
        void UpdateCompany(int id, bool isDel);
    }
}