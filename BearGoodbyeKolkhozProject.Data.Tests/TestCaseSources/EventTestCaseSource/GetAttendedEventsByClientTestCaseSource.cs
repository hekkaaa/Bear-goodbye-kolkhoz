using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.EventTestCaseSource
{
    public class GetAttendedEventsByClientTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Client client = new Client()
            {
                Id = 10,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = new DateTime(1999, 12, 12),
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male,
            };

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
                    StartDate = new DateTime(2022, 03, 10),

                    Classroom = classroom,
                    Lecturer = lecturer,
                    Clients = new List<Client>(){ client }
                },
                new Event()
                {
                    Id = 2,
                    StartDate = new DateTime(2022, 03, 05),

                    Classroom = classroom,
                    Lecturer = lecturer,
                    Clients = new List<Client>(){ client }
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
                    Id = 2,
                    StartDate = new DateTime(2022, 03, 05),

                    Classroom = classroom,
                    Lecturer = lecturer,
                    Clients = new List<Client>(){ client }
                },
            };

            yield return new object[] { client, events, new DateTime(2022, 03, 08), expected };
        }
    }
}
