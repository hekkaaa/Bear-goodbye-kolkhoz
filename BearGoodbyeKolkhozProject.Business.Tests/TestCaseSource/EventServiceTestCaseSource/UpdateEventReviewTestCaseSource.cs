using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventServiceTestCaseSource
{
    public class UpdateEventReviewTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Training> training = new List<Training>
            {
                new Training
                {
                    Id = 1,
                    Name = "Супер бекенд",
                    Description = "TOP so Many",
                    Duration = 1,
                    IsDeleted = false,
                    Price = 1000,
                    MembersCount = 1,
                 },

                new Training
                {
                    Id = 2,
                    Name = "Супер фронт",
                    Description = "AGAIN",
                    Duration = 2,
                    IsDeleted = false,
                    Price = 2000,
                    MembersCount = 1,
                 },

                new Training {
                    Id = 3,
                    Name = "Супер devops",
                    Description = "AGAIN",
                    Duration = 23,
                    IsDeleted = true,
                    Price = 2000,
                    MembersCount = 1,
                }
            };


            Client user = new Client
            {
                Id = 3,
                Name = "Варя",
                LastName = "Чехова",
                Gender = Data.Enums.Gender.Female,
                Password = "sadasd",
                Email = "dsad@dasd.as",
                IsDeleted = false,
            };

            List<Lecturer> lector = new List<Lecturer>
            {
                new Lecturer
                {
                    Id = 1,
                    Name = "Roma",
                    LastName = "Azarov",
                    Password = "qwe",
                    BirthDay = new DateTime(1999, 12, 12),
                    Email = "123qwe@mail.com",
                    Gender = Data.Enums.Gender.Male,
                    Role = Data.Enums.Role.Lecturer,
                    IsDeleted = false,
                },

                new Lecturer
                {
                    Id = 2,
                    Name = "Foma",
                    LastName = "Ptika",
                    Password = "asdsa2",
                    BirthDay = new DateTime(1902, 01, 12),
                    Email = "ads@mail.com",
                    Gender = Data.Enums.Gender.Male,
                     Role = Data.Enums.Role.Lecturer,
                    IsDeleted = false,
                },
            };


            List<Classroom> classrom = new List<Classroom>
            {
                new Classroom
                {
                    Address = "Марата 12",
                    City = "Ростов",
                    IsDeleted = false,
                    MembersCount= 10,
                },

                new Classroom
                {

                    Address = "Бората 69",
                    City = "Астана",
                    IsDeleted = true,
                    MembersCount= 100,
                }
            };

            EventModel newUpdateEvent = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 07, 06),
            };


            Event expected = new Event
            {
                Id = 1,
                IsDeleted = false,
                StartDate = new DateTime(2022, 07, 06),

                Classroom = new Classroom
                {
                    Id = 5,
                    Address = "Бората 69",
                    City = "Астана",
                    IsDeleted = false,
                    MembersCount = 100,
                },

                Lecturer = new Lecturer
                {
                    Id = 2,
                    Name = "Foma",
                    LastName = "Ptika",
                    Password = "asdsa2",
                    BirthDay = new DateTime(1902, 01, 12),
                    Email = "ads@mail.com",
                    Gender = Data.Enums.Gender.Male,

                },

                Training = new Training
                {
                    Id = 2,
                    Name = "Супер фронт",
                    Description = "AGAIN",
                    Duration = 23,
                    IsDeleted = false,
                    Price = 2000,
                    MembersCount = 1,
                }
            };

            yield return new object[] { training, user, lector, classrom, newUpdateEvent, expected };
        }
    }
}
