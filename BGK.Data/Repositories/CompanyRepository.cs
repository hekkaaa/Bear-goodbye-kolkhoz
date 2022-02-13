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
        public void RegistrCompany(Company company)
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

            var res = _context.Company.FirstOrDefault(с => с.Id == company.Id);

            res.Name = company.Name;
            res.Tin = company.Tin;
            res.PhoneNumber = company.PhoneNumber;

            _context.SaveChanges();
        }

        public void UpdateCompany(int id, bool isDel)
        {

            var entity = _context.Company.FirstOrDefault(x => x.Id == id);

            entity.IsDeleted = isDel;

            _context.SaveChanges();

        }

        public void DeleteCompany(Company company)
        {

            _context.Company.Remove(company);

            _context.SaveChanges();

        }

    }
}
