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
                Id = 2,
                Name = "OOO Ivan",
                Email = "qwe@mail.ru",
                PhoneNumber = "123456789",
                Tin = 123234,
                Password = "1234"
            };

            var updateCompany = new Company
            {
                Id = 3,
                Name = "OOO Semen",
                Email = "ewq@mail.ru",
                PhoneNumber = "987654321",
                Tin = 143231,
                Password = "4321"
            };

            var expected = new Company
            {
                Id = 3,
                Name = "OOO Semen",
                Email = "ewq@mail.ru",
                PhoneNumber = "987654321",
                Tin = 143231,
                Password = "4321"
            };

            yield return new object[] { company, updateCompany, expected };
        }

    }
}
