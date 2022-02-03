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
        private readonly CompanyRepository companyRepository;
        public void UpdateCompany(int id, CompanyModel companyModel )
        {
            var company = companyRepository.GetCompanyById(id);
            if (company == null)
                throw new NullReferenceException("Такой Компании не существует.");

            var mappedCompany = new Company { Name = companyModel.}

        }
    }
}
