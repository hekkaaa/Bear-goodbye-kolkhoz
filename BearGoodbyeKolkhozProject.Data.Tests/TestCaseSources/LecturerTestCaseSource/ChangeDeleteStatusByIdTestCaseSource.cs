using BearGoodbyeKolkhozProject.Data.Entities;
using System;
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
                Email = "123qwe@mail.com",

                BirthDay = new DateTime(1999, 12, 12),
                Gender = Enums.Gender.Male,
                IsDeleted = false
            };

            var expected = new Lecturer
            {
                Id = lecturer.Id,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                Email = "123qwe@mail.com",

                BirthDay = new DateTime(1999, 12, 12),
                Gender = Enums.Gender.Male,
                IsDeleted = true
            };

            yield return new object[] { lecturer, expected };
        }
    }
}
