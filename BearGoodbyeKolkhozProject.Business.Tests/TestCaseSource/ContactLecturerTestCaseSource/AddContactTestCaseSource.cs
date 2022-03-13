using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.ContactLecturerTestCaseSource
{
    public class AddContactTestCaseSource : IEnumerable
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
                Gender = Gender.Male,
            };

            ContactLecturerModel contact = new ContactLecturerModel()
            {
                ContactType = ContactType.Telegram,
                Value = "@qwe"
            };

            yield return new object[] { 1, lecturer, contact };
        }
    }
}
