using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.ContactLecturerTestCaseSource
{
    public class AddContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            ContactLecturer expected = new ContactLecturer()
            {
                Id = 1,
                ContactType = Enums.ContactType.Telegram,
                Value = "@qwe",
                Lecturer = new Lecturer()
                {
                    Id = 1,
                    Name = "Roma",
                    LastName = "Azarov",
                    Password = "qwe",
                    BirthDay = new DateTime(1999, 12, 12),
                    Email = "123qwe@mail.com",
                    Gender = Enums.Gender.Male,
                }
            };

            yield return new object[] { expected, 1 };
        }
    }
}
