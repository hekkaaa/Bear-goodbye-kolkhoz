using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSourse
{
    public class UpdateEventTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var even = new Event
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),
                Company = new Company
                {

                    Name = "OOO Ivan",
                    Email = "qwe@mail.ru",
                    PhoneNumber = "123456789",
                    Tin = 123234,
                    Password = "1234"
                },

                Classroom = new Classroom
                {

                    MembersCount = 10,
                    City = "Санк-Петербург",
                    Address = "ул.Вавилова,д.6,оф.17"
                },
                Lecturer = new Lecturer
                {

                    Name = "Семен",
                    LastName = "Семенов",
                    BirthDay = new DateTime(1993, 03, 03),
                    Gender = Enums.Gender.Male,
                    Password = "12345"

                }


            };

            var updateEvent = new Event
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 04),
                Company = new Company
                {

                    Name = "OOO Oleg",
                    Email = "oleg@mail.ru",
                    PhoneNumber = "987654321",
                    Tin = 113234,
                    Password = "4321"
                },

                Classroom = new Classroom
                {
                    MembersCount = 10,
                    City = "Санк-Петербург",
                    Address = "ул.Вавилова,д.7,оф.7"
                },
                Lecturer = new Lecturer
                {

                    Name = "Семен",
                    LastName = "Семенов",
                    BirthDay = new DateTime(1993, 03, 03),
                    Gender = Enums.Gender.Male,
                    Password = "12345"

                }
            };

            var expected = new Event
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 04),
                Company = new Company
                {

                    Name = "OOO Oleg",
                    Email = "oleg@mail.ru",
                    PhoneNumber = "987654321",
                    Tin = 113234,
                    Password = "4321"
                },

                Classroom = new Classroom
                {
                    MembersCount = 10,
                    City = "Санк-Петербург",
                    Address = "ул.Вавилова,д.7,оф.7"
                },
                Lecturer = new Lecturer
                {

                    Name = "Семен",
                    LastName = "Семенов",
                    BirthDay = new DateTime(1993, 03, 03),
                    Gender = Enums.Gender.Male,
                    Password = "12345"

                }

            };

            yield return new object[] { even, updateEvent, expected };
        }
    }
}
