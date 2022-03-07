using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSource
{
    public class UpdateCompanyTestCaseSourceTwo : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var company = new Company
            {
                Id = 2,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false

            };

            var updateCompany = new Company
            {
                Id = 2,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = true
            };

            var expected = new Company
            {
                Id = 2,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = true

            };

            yield return new object[] { company, updateCompany, expected };
        }
    }
}
