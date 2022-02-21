using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    public class UpdateLecturerTestCaseSource : IEnumerable
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
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            var updateLecturer = new Lecturer
            {
                Id = 1,
                Name = "Amor",
                LastName = "Voraza",
                Password = "ewq",
                BirthDay = "21.01.2000",
                Gender = Enums.Gender.Other,
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            var expected = new Lecturer
            {
                Id = 1,
                Name = "Amor",
                LastName = "Voraza",
                Password = "qwe",
                BirthDay = "21.01.2000",
                Gender = Enums.Gender.Other,
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            yield return new object[] { lecturer, updateLecturer, expected };

            var lecturer1 = new Lecturer
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            var updateLecturer1 = new Lecturer
            {
                Id = 1,
                Name = "Amor",
                LastName = "Voraza",
                Password = "ewq",
                BirthDay = null,
                Gender = Enums.Gender.Other,
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            var expected1 = new Lecturer
            {
                Id = 1,
                Name = "Amor",
                LastName = "Voraza",
                Password = "qwe",
                BirthDay = null,
                Gender = Enums.Gender.Other,
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            yield return new object[] { lecturer1, updateLecturer1, expected1 };

        }
    }
}
