using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public class CompanyService
    {
        private readonly CompanyRepository? companyRepository;

        public void GetCompanyById(int id)
        {
            var company = companyRepository.GetCompanyById(id);
            if (company != null)
                throw new Exception("Такой Компания не существует.");
        }

        public void AddCompany(int id,CompanyModel companyModel)
        {
            var company = companyRepository.GetCompanyById(id);
            if (company != null)
                throw new Exception("Такая Компания уже существует.");
            var mappedCompany = new Company
            {
                Email = companyModel.Email,
                Password = companyModel.Password,
                Name = companyModel.Name,
                PhoneNumber = companyModel.PhoneNumber,
                Tin = companyModel.Tin,
                IsDeleted = companyModel.IsDeleted
                
            };

            companyRepository.AddCompany(mappedCompany);
        }
        public void UpdateCompany(int id, CompanyModel companyModel )
        {
            var company = companyRepository.GetCompanyById(id);
            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            var mappedCompany = new Company
            {
                Name = companyModel.Name,
                PhoneNumber = companyModel.PhoneNumber,
                Tin = companyModel.Tin,
                Password = companyModel.Password
            };

            companyRepository.UpdateCompany(mappedCompany);

        }

        public void DeleteCompany(int id, bool isDel)
        {
            var company = companyRepository.GetCompanyById(id);
            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            companyRepository.UpdateCompany(id, isDel);

        }
    }
}
