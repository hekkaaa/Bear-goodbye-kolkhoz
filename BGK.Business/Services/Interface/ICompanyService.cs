namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ICompanyService
    {
        void DeleteCompany(int id);
        List<CompanyModel> GetCompanies();
        CompanyModel GetCompanyById(int id);
        void RegistrCompany(CompanyModel companyModel);
        void UpdateCompany(CompanyModel companyModel);
        void UpdateCompany(int id, bool isDel);
    }
}