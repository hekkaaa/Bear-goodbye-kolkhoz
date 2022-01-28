using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("ContactLecturer")]
    public class ContactLecturer
    {
        public int Id { get; set; }

        public ContactType ContactType { get; set; } 

        public Lecturer Lecturer { get; set; }

        public string Value { get; set; }
    }
}
