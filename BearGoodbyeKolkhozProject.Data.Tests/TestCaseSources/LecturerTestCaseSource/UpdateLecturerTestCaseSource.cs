using BearGoodbyeKolkhozProject.Data.Entities;
using System;
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
                BirthDay = new DateTime(1999, 12, 12),
                Email = "123qwe@mail.com",
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
                BirthDay = new DateTime(2000, 01, 21),
                Email = "123qwe@mail.com",
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
                BirthDay = new DateTime(2000, 01, 21),
                Email = "123qwe@mail.com",
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
                BirthDay = new DateTime(1999, 12, 12),
                Email = "123qwe@mail.com",
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
                Email = "123qwe@mail.com",
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
                Email = "123qwe@mail.com",
                BirthDay = null,
                Gender = Enums.Gender.Other,
                IsDeleted = false,
                Trainings = new List<Training>()
            };

            yield return new object[] { lecturer1, updateLecturer1, expected1 };

        }
    }
}
