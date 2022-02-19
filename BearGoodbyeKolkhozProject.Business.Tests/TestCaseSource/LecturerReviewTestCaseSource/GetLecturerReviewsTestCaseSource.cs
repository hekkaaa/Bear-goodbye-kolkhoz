using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.LecturerReviewTestCaseSource
{
    public class GetLecturerReviewsTestCaseSource : IEnumerable
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

            List<LecturerReview> reviews = new List<LecturerReview>()
            {
                new LecturerReview()
                {
                    Id = 1,
                    Text = "qwdfghu",
                    Mark = 3,
                    Client = client
                },
                new LecturerReview()
                {
                    Id = 2,
                    Text = "1234567",
                    Mark = 5,
                    Client = new Client()
                    {
                        Id = 112,
                        Name = "qwe123",
                        LastName = "321ewq",
                        Gender = Gender.Male,
                        BirthDay = "11.11.2000",
                        Email = "123qwe@mail.com",
                        PhoneNumber = "88777777777",
                        Password = "qwe!23",
                        IsDeleted = false
                    }
                },
                new LecturerReview()
                {
                    Id = 3,
                    Text = "hgfds",
                    Mark = 6,
                    Client = client
                },
            };

            List<LecturerReviewModel> expected = new List<LecturerReviewModel>()
            {
                new LecturerReviewModel()
                {
                    Id = 1,
                    Text = "qwdfghu",
                    Mark = 3,
                    Client = clientModel
                },
                new LecturerReviewModel()
                {
                    Id = 2,
                    Text = "1234567",
                    Mark = 5,
                    Client = new ClientModel()
                },
                new LecturerReviewModel()
                {
                    Id = 3,
                    Text = "hgfds",
                    Mark = 6,
                    Client = clientModel
                },
            };

            yield return new object[] { reviews, expected };
            yield return new object[] { new List<LecturerReview>(), new List<LecturerReviewModel>() };

        }
    }
}
