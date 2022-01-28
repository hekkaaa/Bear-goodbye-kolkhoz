using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("ContacType")]
    public  class ContactType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContactLecturer ContactLecturer { get; set; }
    }
}
