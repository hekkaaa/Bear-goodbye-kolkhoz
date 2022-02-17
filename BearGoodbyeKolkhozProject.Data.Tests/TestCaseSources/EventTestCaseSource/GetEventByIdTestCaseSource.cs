using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;


namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.EventTestCaseSource
{
    public class GetEventByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var even = new Event
            {
                Id = 1,
                StartDate = "03.03.2022",
                Company = new Company
                {
                    Id = 1,
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
                    BirthDay = "03.03.1993",
                    Gender = Enums.Gender.Male,
                    Password = "12345"

                },
            };

                var expected = new Event
                {
                    Id = even.Id,
                    StartDate = "03.03.2022",
                    Company = new Company
                    {
                        Id = 1,
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
                        BirthDay = "03.03.1993",
                        Gender = Enums.Gender.Male,
                        Password = "12345"

                    }
                };

            yield return new object[] { even, expected };
        }
    }

    
}
