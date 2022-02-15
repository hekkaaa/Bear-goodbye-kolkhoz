using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public interface ICompanyRepository
    {
        void RegistrCompany(Company company);
        void DeleteCompany(Company company);
        Company GetCompanyById(int id);
        List<Company> GetCompanies();
        void UpdateCompany(Company company);
        void UpdateCompany(int id, bool isDel);
    }
}