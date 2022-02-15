using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System.Collections.Generic;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.LecturerReviewTestCaseSource
{
    public class GetLecturerReviewsByLecturerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var client = new Client()
            {
                Id = 111,
                Name = "qwe123",
                LastName = "321ewq",
                Gender = Gender.Male,
                BirthDay = "11.11.2000",
                Email = "123qwe@mail.com",
                PhoneNumber = "77777777777",
                Password = "qwe!23",
                IsDeleted = false
            };

            var clientModel = new ClientModel() { };

            var lecturer = new Lecturer()
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Gender.Male,
                IsDeleted = false
            };

            var lecturerModel = new LecturerModel()
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Gender.Male,
                IsDeleted = false
            };

            List<LecturerReview> reviews = new List<LecturerReview>()
            {
                new LecturerReview()
                {
                    Id = 1,
                    Text = "qwdfghu",
                    Mark = 3,
                    Client = client,
                    Lecturer = lecturer
                },
                new LecturerReview()
                {
                    Id = 3,
                    Text = "hgfds",
                    Mark = 6,
                    Client = client,
                    Lecturer = lecturer
                },
            };

            List<LecturerReviewModel> expected = new List<LecturerReviewModel>()
            {
                new LecturerReviewModel()
                {
                    Id = 1,
                    Text = "qwdfghu",
                    Mark = 3,
                    Client = clientModel,
                    LecturerModel = lecturerModel
                },
                new LecturerReviewModel()
                {
                    Id = 3,
                    Text = "hgfds",
                    Mark = 6,
                    Client = clientModel,
                    LecturerModel = lecturerModel
                },
            };

            yield return new object[] { reviews, expected, 1 };
        }
    }
}
