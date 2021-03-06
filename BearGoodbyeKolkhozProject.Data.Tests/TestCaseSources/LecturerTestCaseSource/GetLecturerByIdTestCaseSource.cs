using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    public class GetLecturerByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lecturer = new Lecturer
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Email = "123qwe@mail.com",
                Password = "qwe",
                BirthDay = new DateTime(1999, 12, 12),
                Gender = Enums.Gender.Male,
            };

            var expected = new Lecturer
            {
                Id = lecturer.Id,
                Name = "Roma",
                LastName = "Azarov",
                Email = "123qwe@mail.com",
                Password = "qwe",
                BirthDay = new DateTime(1999, 12, 12),
                Gender = Enums.Gender.Male,
            };
            yield return new object[] { lecturer, expected };
        }
    }
}