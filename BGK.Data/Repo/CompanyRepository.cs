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
        public Company GetCompanyById(int id)
        {

            var company = UnitOfWork.GetInstance();

            return company.Companie.FirstOrDefault(c => c.Id == id);


        }

        public void UpdateCompany(int id, bool IsDel)

    }
}
