using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Client")]
    public class Client : User
    {
        public string PhoneNumber { get; set; }

        public virtual ICollection<TrainingReview>? TrainingReviews { get; set; }
        public virtual ICollection<LecturerReview>? LecturerReviews { get; set; }
        public virtual ICollection<Topic>? Topic { get; set; }
        public virtual ICollection<Event>? Event { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((Client)obj).Id
                || Name != ((Client)obj).Name
                || LastName != ((Client)obj).LastName
                || Gender != ((Client)obj).Gender
                || BirthDay != ((Client)obj).BirthDay
                || Email != ((Client)obj).Email
                || PhoneNumber != ((Client)obj).PhoneNumber
                || Password != ((Client)obj).Password
                || IsDeleted != ((Client)obj).IsDeleted)
            {
                return false;
            }

            return true;
        }
    }
}
