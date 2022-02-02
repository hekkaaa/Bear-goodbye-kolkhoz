using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public class CompanyRepository
    {
        private ApplicationContext _context;
        public void AddCompany(Company company)
        {
            var excistanCompany = GetCompanyById(company.Id);

            if (excistanCompany != null)
            {
                throw new ArgumentException("Пользователь с таким именем уже зарегистрирован", nameof(company.Name));
            }

            _context.SaveChanges();

        }
        public Company GetCompanyById(int id) =>
            _context.Company.Find(id);
       
        public void UpdateCompany(Company company)
        {
            var entity = GetCompanyById(company.Id);

            entity.Name = company.Name;
            entity.Password = company.Password;
            entity.PhoneNumber = company.PhoneNumber;
            entity.Tin = company.Tin;
            entity.IsDeleted = company.IsDeleted;

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
