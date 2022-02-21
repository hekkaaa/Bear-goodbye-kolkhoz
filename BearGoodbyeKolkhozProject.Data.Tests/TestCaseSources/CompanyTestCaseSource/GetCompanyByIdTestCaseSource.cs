using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSource
{
    public class GetCompanyByIdTestCaseSource :IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var company4 = new Company
            {
                Id = 1,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false

            };

            var expected = new Company
            {
                Id = company4.Id,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false
            };

            yield return new object[] { company4, expected };


        }
    }
}
