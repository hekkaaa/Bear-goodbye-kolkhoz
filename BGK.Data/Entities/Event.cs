using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Event")]
    public  class Event
    {
        public int Id { get; set; }

        public Admin Admin { get; set; }

        public Lecturer Lecturer { get; set; }

        public Classroom Classroom { get; set; }

        public int Members { get; set; }

        public int Duration { get; set; }

        public string StartDate { get; set; }

        public int Price { get; set; }
    }
}
