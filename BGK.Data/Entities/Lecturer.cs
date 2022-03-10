using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Lecturer")]
    public class Lecturer : User
    {
        public virtual ICollection<Training>? Trainings { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
        public virtual ICollection<LecturerReview>? LecturerReviews { get; set; }
        public virtual ICollection<ContactLecturer>? ContactLecturer { get; set; }

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
                || Password != ((Lecturer)obj).Password
                || Role != ((Lecturer)obj).Role)
            {
                return false;
            }

            return true;
        }
    }
}