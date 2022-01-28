using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Lecturer")]
    public class Lecturer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool Gender { get; set; }

        public string BirthDay { get; set; }

    }
}
