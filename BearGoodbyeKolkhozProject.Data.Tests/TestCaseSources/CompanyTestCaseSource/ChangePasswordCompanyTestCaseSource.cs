using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSource
{
    public class ChangePasswordCompanyTestCaseSource : IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            var company = new Company
            {
                Id = 5,
                Name = "OOO Andru",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false
            };

            string newPasss = "qweqwe123123";

            var expected = new Company
            {
                Id = 5,
                Name = "OOO Andru",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "qweqwe123123",
                IsDeleted = false
            };

            yield return new object[] { company, newPasss, expected };
        }
    }
}
