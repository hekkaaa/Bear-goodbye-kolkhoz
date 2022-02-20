using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    internal class ChangeDeleteStatusByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lecturer = new Lecturer
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
                IsDeleted = false
            };

            var expected = new Lecturer
            {
                Id = lecturer.Id,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
                IsDeleted = true
            };

            yield return new object[] { lecturer, expected };
        }
    }
}
