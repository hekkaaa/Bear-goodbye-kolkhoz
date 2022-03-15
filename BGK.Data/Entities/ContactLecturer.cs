using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("ContactLecturer")]
    public class ContactLecturer
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public override bool Equals(object? obj)
        {
            if (Id != ((ContactLecturer)obj).Id
                && ContactType != ((ContactLecturer)obj).ContactType
                && Value != ((ContactLecturer)obj).Value
                && Lecturer != ((ContactLecturer)obj).Lecturer)
            {
                return false;
            }
            return true;
        }
    }
}
