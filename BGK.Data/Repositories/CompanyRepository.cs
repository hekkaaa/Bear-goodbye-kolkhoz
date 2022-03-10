using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationContext _context;

        public CompanyRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int RegistrationCompany(Company company)
        {

            _context.Company.Add(company);

            _context.SaveChanges();

            return company.Id;
        }

        public List<Company> GetCompanies() =>
            _context.Company.Where(c => !c.IsDeleted).ToList();


        public Company GetCompanyById(int id) =>
            _context.Company.Find(id);

        public void UpdateCompany(Company company)
        {
            var entity = GetCompanyById(company.Id);

            entity.Name = company.Name;
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

        public void ChangePasswordCompany(string password, Company company)
        {
            company.Password = password;
            _context.SaveChanges();           
        }

        public Company Login(string email)
        {
            Company? entity = _context.Company
                .FirstOrDefault(c => c.Email == email);

            return entity;
        }


    }
}
