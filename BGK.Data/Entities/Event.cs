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
        public string StartDate { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Client>? Clients { get; set; }
       
    }
}
