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

        public virtual ICollection<Training>? Trainings { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
        public virtual ICollection<LecturerReview>? LecturerReviews { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {LastName} {BirthDay} {IsDeleted} {Gender} {Password}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((Lecturer)obj).Id
                || Name != ((Lecturer)obj).Name
                || LastName != ((Lecturer)obj).LastName
                || BirthDay != ((Lecturer)obj).BirthDay
                || Gender != ((Lecturer)obj).Gender
                || Password != ((Lecturer)obj).Password)
            {
                return false;
            }

            return true;
        }
    }
}