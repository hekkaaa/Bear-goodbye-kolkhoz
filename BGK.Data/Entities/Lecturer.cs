using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Lecturer")]
    public class Lecturer
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        public string? BirthDay { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<LecturerReview> LecturerReviews { get; set; }
    }
}