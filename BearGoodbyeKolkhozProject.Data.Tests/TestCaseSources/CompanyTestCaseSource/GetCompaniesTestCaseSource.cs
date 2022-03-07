using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSource
{
    public class GetCompaniesTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Company> companies = new List<Company>{ new Company {

                Name = "OOO Andrey",
                Email = "qsdfdsf@mail.ru",
                PhoneNumber = "123456789",
                Tin = 15676534,
                Password = "1257567",
                IsDeleted = false}
            , new Company{

                Name = "OOO Lena",
                Email = "rty@mail.ru",
                PhoneNumber = "9876543",
                Tin = 1237463,
                Password = "1256",
                IsDeleted = false}
            , new Company{

                Name = "OOO Anna",
                Email = "ann@mail.ru",
                PhoneNumber = "9821313",
                Tin = 5677463,
                Password = "3456",
                IsDeleted = false}
            };

            List<Company> expected = new List<Company> { new Company {
                Id = 1,
                Name = "OOO Andrey",
                Email = "qsdfdsf@mail.ru",
                PhoneNumber = "123456789",
                Tin = 15676534,
                IsDeleted = false}
            , new Company{
                Id = 2,
                Name = "OOO Lena",
                Email = "rty@mail.ru",
                PhoneNumber = "9876543",
                Tin = 1237463,
                IsDeleted = false}

            , new Company {
                Id = 3,
                Name = "OOO Anna",
                Email = "ann@mail.ru",
                PhoneNumber = "9821313",
                Tin = 5677463,
                IsDeleted = false}
            };

            yield return new object[] { companies, expected };
        }

    }
}
