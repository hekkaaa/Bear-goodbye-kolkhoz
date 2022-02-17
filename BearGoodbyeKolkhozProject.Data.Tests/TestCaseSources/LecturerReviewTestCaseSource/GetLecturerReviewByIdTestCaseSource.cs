using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerReviewTestCaseSource
{
    public class GetLecturerReviewByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lecturerReview = new LecturerReview
            {
                Id = 200,
                Text = "ewq",
                Mark = 4,
                Client = new Client
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
                },
                Lecturer = new Lecturer
                {
                    Id = 1,
                    Name = "Roma",
                    LastName = "Azarov",
                    Password = "qwe",
                    BirthDay = "12.12.1999",
                    Gender = Gender.Male,
                }
            };

            var expected = new LecturerReview
            {
                Id = 200,
                Text = "ewq",
                Mark = 4,
                Client = lecturerReview.Client,
                Lecturer = lecturerReview.Lecturer
            };

            yield return new object[] { lecturerReview, expected, 200 };
        }
    }
}
