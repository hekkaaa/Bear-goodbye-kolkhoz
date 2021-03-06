using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    public class AddLecturerTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lecturer = new Lecturer
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = new DateTime(1999, 12, 12),
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male,
            };

            var lecturerWithTraining = new Lecturer
            {
                Id = 2,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                Email = "123qwe@mail.com",
                BirthDay = new DateTime(1999, 12, 12),
                Gender = Enums.Gender.Male,
                Trainings = new List<Training>{
                    new Training {
                        Description = "qwertui",
                        Name = "name",
                        MembersCount = 12,
                        Price = 1234,
                        Duration = 123,
                        IsDeleted = false}}
            };

            yield return new object[] { lecturer };
            yield return new object[] { lecturerWithTraining };
        }
    }
}
