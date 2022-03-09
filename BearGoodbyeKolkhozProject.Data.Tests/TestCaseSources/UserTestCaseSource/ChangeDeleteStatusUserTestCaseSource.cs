using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.UserTestCaseSource
{
    public class ChangeDeleteStatusUserTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var user = new Lecturer
            {
                Id = 1,
                Name = "Ada",
                LastName = "Erata",
                Email = "AdaQween35@ya.ru",
                BirthDay = new DateTime(1993, 05, 05),
                Gender = Enums.Gender.Female,
                Password = "qwe123",
                IsDeleted = true,
            };

            var expected = new Lecturer
            {
                Id = 1,
                Name = "Ada",
                LastName = "Erata",
                Email = "AdaQween35@ya.ru",
                BirthDay = new DateTime(1993, 05, 05),
                Gender = Enums.Gender.Female,
                Password = "qwe123",
                IsDeleted = false,
            };

            yield return new object[] { user, expected };
        }
    }
}
