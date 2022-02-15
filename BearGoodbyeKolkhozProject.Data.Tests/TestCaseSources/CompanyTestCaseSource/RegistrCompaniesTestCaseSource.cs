using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCase
{
    public class RegistrCompaniesTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var company1 = new Company
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail.ru",
                PhoneNumber = "123456789",
                Tin = 123234,
                Password = "1234"

            };

            var company2 = new Company
            {
                Id = 2,
                Name = "OOO Semen",
                Email = "rty@mail.ru",
                PhoneNumber = "+793456789",
                Tin = 123890,
                Password = "9876"

            };

            yield return new object[] { company1 };
            yield return new object[] { company2 };
        }

    }
}



