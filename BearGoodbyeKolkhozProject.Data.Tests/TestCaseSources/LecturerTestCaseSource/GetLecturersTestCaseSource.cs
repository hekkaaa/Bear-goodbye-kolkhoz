using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    public class GetLecturersTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Lecturer> lecturers = new List<Lecturer>{ new Lecturer {
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                Email = "123qwe@mail.com",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
                Trainings = new List<Training>{
                    new Training {
                        Description = "qwertui",
                        Name = "name",
                        MembersCount = 12,
                        Price = 1234,
                        Duration = 123,
                        IsDeleted = false}}}
            , new Lecturer{
                Name = "Slava",
                LastName = "Azarov",
                Password = "asd",
                BirthDay = "12.12.2004",
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male}
            , new Lecturer {
                Name = "qwe",
                LastName = "asd",
                Email = "123qwe@mail.com",
                Password = "123",
                BirthDay = "11.22.1234",
                Gender = Enums.Gender.Other,
                IsDeleted = true}
            };

            List<Lecturer> expected = new List<Lecturer> { new Lecturer {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male,
                Trainings = new List<Training>{
                    new Training {
                        Id = 1,
                        Description = "qwertui",
                        Name = "name",
                        MembersCount = 12,
                        Price = 1234,
                        Duration = 123,
                        IsDeleted = false}}}
            , new Lecturer {
                Id = 2,
                Name = "Slava",
                LastName = "Azarov",
                Password = "asd",
                BirthDay = "12.12.2004",
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male}
            };

            yield return new object[] { lecturers, expected };
        }
    }
}
