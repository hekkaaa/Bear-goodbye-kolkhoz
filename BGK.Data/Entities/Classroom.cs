using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Classroom")]
    public class Classroom
    {
        public int Id { get; set; }

        public int MembersCount { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

    }
}
