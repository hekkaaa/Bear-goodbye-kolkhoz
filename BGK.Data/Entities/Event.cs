using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Event")]
    public class Event
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Classroom? Classroom { get; set; }
        public virtual Lecturer? Lecturer { get; set; }
        public virtual Training Training { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Client>? Clients { get; set; }
    }
}