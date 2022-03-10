using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    public class DeleteTrainingTestCaseSource : IEnumerable
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
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male,
                Trainings = new List<Training>()
            };

            Training training = new Training
            {
                Description = "qwertui",
                Name = "name",
                MembersCount = 12,
                Price = 1234,
                Duration = 123,
                IsDeleted = false
            };

            lecturer.Trainings.Add(training);

            var expected = new Lecturer
            {
                Id = lecturer.Id,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                Email = "123qwe@mail.com",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
            };

            yield return new object[] { lecturer, expected, training };


        }
    }
}
