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
    }
}
