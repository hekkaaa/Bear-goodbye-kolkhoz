using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.UserTestCaseSource
{
    public class DeleteUserByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Client> users = new List<Client>()
            {
                new Client {
                Id = 1,
                Name = "Eva",
                LastName = "Verden",
                Email = "EvaAlone44@ya.ru",
                BirthDay = new DateTime(1997, 12, 10),
                Gender = Data.Enums.Gender.Female,
                Password = "qwe321",
                IsDeleted = true,
                },

                new Client {
                Id = 2,
                Name = "Ada",
                LastName = "Erata",
                Email = "AdaQween35@ya.ru",
                BirthDay = new DateTime(1993, 05, 05),
                Gender = Gender.Female,
                Password = "qwe123",
                IsDeleted = false,

                },

                new Client {
                Id = 3,
                Name = "Georgy",
                LastName = "Ston",
                Email = "barakuda22new@mail.ru",
                BirthDay = new DateTime(1985, 01, 09),
                Gender = Gender.Male,
                Password = "wos29flyEr",
                IsDeleted = false,
                },
            };

            var expected = new Client
            {
                Id = 2,
                Name = "Ada",
                LastName = "Erata",
                Email = "AdaQween35@ya.ru",
                BirthDay = new DateTime(1993, 05, 05),
                Gender = Gender.Female,
                Password = "qwe123",
                IsDeleted = false,
            };

            yield return new object[] { users, expected };
        }
    }
}
