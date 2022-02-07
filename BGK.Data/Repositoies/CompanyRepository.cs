using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationContext _context;

        public CompanyRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void AddCompany(Company company)
        {

            _context.Company.Add(company);

            _context.SaveChanges();
        }

        public List<Company> GetCompanies() =>
            _context.Company.Where(c => !c.IsDeleted).ToList();


        public Company GetCompanyById(int id) =>
            _context.Company.Find(id);

        public void UpdateCompany(Company company)
        {
            var entity = GetCompanyById(company.Id);

            entity.Name = company.Name;
            entity.Password = company.Password;
            entity.PhoneNumber = company.PhoneNumber;
            entity.Tin = company.Tin;

            _context.SaveChanges();
        }

        public void UpdateCompany(int id, bool isDel)
        {

            var entity = GetCompanyById(id);

            entity.IsDeleted = isDel;

            _context.SaveChanges();

        }

        public void DeleteCompany(int id)
        {
            var entity = GetCompanyById(id);

            _context.Company.Remove(entity);

            _context.SaveChanges();

        }

    }
}
