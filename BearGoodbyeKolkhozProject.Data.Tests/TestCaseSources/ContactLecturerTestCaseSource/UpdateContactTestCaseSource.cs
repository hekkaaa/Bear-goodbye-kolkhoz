using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.ContactLecturerTestCaseSource
{
    public class UpdateContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Lecturer lecturer = new Lecturer()
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = new DateTime(1999, 12, 12),
                Email = "123qwe@mail.com",
                Gender = Enums.Gender.Male,
            };

            ContactLecturer contact = new ContactLecturer()
            {
                Id = 1,
                ContactType = Enums.ContactType.Telegram,
                Value = "@qwe",
                Lecturer = lecturer
            };

            ContactLecturer model = new ContactLecturer()
            {
                Id = 1,
                ContactType = Enums.ContactType.Instagram,
                Value = "@qqq",
                Lecturer = lecturer
            };

            ContactLecturer expected = new ContactLecturer()
            {
                Id = 1,
                ContactType = Enums.ContactType.Instagram,
                Value = "@qqq",
                Lecturer = lecturer
            };

            yield return new object[] { contact, model, expected };
        }
    }
}
