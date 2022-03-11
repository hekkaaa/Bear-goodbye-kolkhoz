using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSource
{
    public class GetCompanyByEmailTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Company> companies = new List<Company>()
            {
                new Company {
                Id = 1,
                Name = "Dronw.Ink",
                Tin = 100,
                Email = "Dronw44@ya.ru",
                Password = "qwe321",
                IsDeleted = true,
                },

                new Company {
                Id = 2,
                Name = "AdaCompany",
                Tin = 101,
                Email = "Ada@ya.ru",
                Password = "qwe321",
                IsDeleted = false,
                },

                new Company {
                Id = 3,
                Name = "GertDev",
                Tin = 102,
                Email = "GertDev@ya.ru",
                Password = "qwe321",
                IsDeleted = false,
                },
            };

            var expected = new Company
            {
                Id = 2,
                Name = "AdaCompany",
                Tin = 101,
                Email = "Ada@ya.ru",
                Password = "qwe321",
                IsDeleted = false,
            };

            yield return new object[] { companies, expected };
        }
    }
}
