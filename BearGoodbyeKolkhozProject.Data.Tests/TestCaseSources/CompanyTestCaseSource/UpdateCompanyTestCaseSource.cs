using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;


namespace BearGoodbyeKolkhozProject.Data.Tests.TestCase
{
    public class UpdateCompanyTestCaseSource : IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            var company = new Company
            {
                Id = 1,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234

            };

            var updateCompany = new Company
            {
                Id = 1,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234
            };

            var expected = new Company
            {
                Id = 1,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234

            };

            yield return new object[] { company, updateCompany, expected };
        }

    }
}
