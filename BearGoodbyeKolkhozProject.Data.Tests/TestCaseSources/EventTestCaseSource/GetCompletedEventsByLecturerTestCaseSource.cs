using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.EventTestCaseSource
{
    public class GetCompletedEventsByLecturerTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Lecturer lecturer = new Lecturer()
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = new DateTime(1999, 12, 12),
                Email = "123qwe@mail.com",
                Gender = Gender.Male,
            };

            Training training = new Training()
            {
                Id = 1,
                Name = "Name",
                MembersCount = 1,
                Duration = 1,
                Price = 1000,
                IsDeleted = false
            };

            Classroom classroom = new Classroom()
            {
                MembersCount = 8,
                City = "Санк-Петербург",
                Address = "ул.Вавилова,д.6,оф.17"
            };

            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    Id = 1,
                    StartDate = new DateTime(2022, 03, 03),

                    Training = training,
                    Classroom = classroom,
                    Lecturer = lecturer
                },
                new Event()
                {
                    Id = 2,
                    StartDate = new DateTime(2022, 03, 05),

                    Training = training,
                    Classroom = classroom,
                    Lecturer = lecturer
                },
                new Event()
                {
                    Id = 3,
                    StartDate = new DateTime(2022, 03, 05),

                    Classroom = new Classroom
                    {
                        MembersCount = 8,
                        City = "Санк-Петербург",
                        Address = "ул.Вавилова,д.6,оф.17"
                    },
                    Lecturer = new Lecturer()
                    {
                        Id = 2,
                        Name = "amor",
                        LastName = "voraza",
                        Password = "ewq",
                        BirthDay = new DateTime(2000, 12, 12),
                        Email = "321ewq@mail.com",
                        Gender = Gender.Male
                    }
                },
                new Event()
                {
                    Id = 4,
                    StartDate = new DateTime(2022, 03, 10),

                    Classroom = classroom,
                    Lecturer = lecturer
                }
            };

            List<Event> expected = new List<Event>()
            {
                new Event()
                {
                    Id = 1,
                    StartDate = new DateTime(2022, 03, 03),

                    Training = training,
                    Classroom = classroom,
                    Lecturer = lecturer
                },
                new Event()
                {
                    Id = 2,
                    StartDate = new DateTime(2022, 03, 05),

                    Training = training,
                    Classroom = classroom,
                    Lecturer = lecturer
                }
            };

            yield return new object[] { lecturer, events, new DateTime(2022, 03, 08), expected };
        }
    }
}
