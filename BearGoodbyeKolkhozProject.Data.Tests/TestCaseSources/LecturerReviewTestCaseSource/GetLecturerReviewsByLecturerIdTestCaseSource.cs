using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerReviewTestCaseSource
{
    public class GetLecturerReviewsByLecturerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lecturer = new Lecturer()
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Email = "123qwe@mail.com",
                Gender = Gender.Male,
            };

            var client1 = new Client()
            {
                Id = 1,
                Name = "qwe123",
                LastName = "321ewq",
                Gender = Gender.Male,
                BirthDay = "11.11.2000",
                Email = "123qwe@mail.com",
                PhoneNumber = "77777777777",
                Password = "qwe!23",
                IsDeleted = false
            };

            var client2 = new Client()
            {
                Id = 3,
                Name = "kjhgfd",
                LastName = "asdfgh",
                Gender = Gender.Other,
                BirthDay = "11.11.2000",
                Email = "123@mail.com",
                PhoneNumber = "77777777888",
                Password = "qwe",
                IsDeleted = false
            };

            List<LecturerReview> reviews = new List<LecturerReview>
            {
                new LecturerReview
                {
                    Id = 1,
                    Text = "ewq",
                    Mark = 4,
                    Client = client1,
                    Lecturer = lecturer
                },
                new LecturerReview
                {
                    Id = 2,
                    Text = "qwe",
                    Mark = 5,
                    Client = new Client
                    {
                        Id = 2,
                        Name = "qwe",
                        LastName = "ewq",
                        Gender = Gender.Other,
                        BirthDay = "11.11.2000",
                        Email = "qwe@mail.com",
                        PhoneNumber = "77777777777",
                        Password = "qwe23",
                        IsDeleted = false
                    },
                    Lecturer = new Lecturer
                    {
                        Id = 2,
                        Name = "123",
                        LastName = "456",
                        Password = "zxc",
                        BirthDay = "12.12.1999",
                        Email = "123qwe@mail.com",
                        Gender = Gender.Female,
                    }
                },
                new LecturerReview
                {
                    Id = 3,
                    Text = "ewq",
                    Mark = 4,
                    Client = client2,
                    Lecturer = lecturer
                }
            };

            List<LecturerReview> expected = new List<LecturerReview>
            {
                new LecturerReview
                {
                    Id = 1,
                    Text = "ewq",
                    Mark = 4,
                    Client = client1,
                    Lecturer = lecturer
                },
                new LecturerReview
                {
                    Id = 3,
                    Text = "ewq",
                    Mark = 4,
                    Client = client2,
                    Lecturer = lecturer
                }
            };

            yield return new object[] { reviews, expected, 1 };

            List<LecturerReview> reviews2 = new List<LecturerReview>
            {
                new LecturerReview
                {
                    Id = 10,
                    Text = "ewq",
                    Mark = 4,
                    Client = client1,
                    Lecturer = lecturer
                },
                new LecturerReview
                {
                    Id = 20,
                    Text = "qwe",
                    Mark = 5,
                    Client = new Client
                    {
                        Id = 2,
                        Name = "qwe",
                        LastName = "ewq",
                        Gender = Gender.Other,
                        BirthDay = "11.11.2000",
                        Email = "qwe@mail.com",
                        PhoneNumber = "77777777777",
                        Password = "qwe23",
                        IsDeleted = false
                    },
                    Lecturer = new Lecturer
                    {
                        Id = 20,
                        Name = "123",
                        LastName = "456",
                        Password = "zxc",
                        BirthDay = "12.12.1999",
                        Email = "123qwe@mail.com",
                        Gender = Gender.Female,
                    }
                },
                new LecturerReview
                {
                    Id = 30,
                    Text = "ewq",
                    Mark = 4,
                    Client = client2,
                    Lecturer = lecturer
                }
            };

            List<LecturerReview> expected2 = new List<LecturerReview> { };

            yield return new object[] { reviews2, expected2, 100 };

        }
    }
}
