using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.ContactLecturerTestCaseSource
{
    internal class UpdateContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            ContactLecturerModel contactModel = new ContactLecturerModel()
            {
                ContactType = ContactType.Telegram,
                Value = "@qwe"
            };

            ContactLecturer contact = new ContactLecturer()
            {
                Id = 1,
                ContactType = ContactType.Telegram,
                Value = "@qwe",
            };

            yield return new object[] { 1, contactModel, contact };
        }
    }
}
