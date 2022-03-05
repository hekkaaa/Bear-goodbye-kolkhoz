using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.EventTestCaseSource
{
    public class DeleteEventTestCaseSource : IEnumerable
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
                    Email = "lector@mail.ru",
                    BirthDay = new DateTime(1993, 03, 03),
                    Gender = Enums.Gender.Male,
                    Password = "12345"

                },

                


            };

            Event expected = null;

            yield return new object[] { even, expected };



        }

    }
}
