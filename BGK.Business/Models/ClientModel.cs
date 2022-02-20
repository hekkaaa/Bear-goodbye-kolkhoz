using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<TrainingReview> TrainingReviews { get; set; }
        public virtual List<LecturerReview> LecturerReviews { get; set; }
        public virtual List<Topic> Topic { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((ClientModel)obj).Id
                || Name != ((ClientModel)obj).Name
                || LastName != ((ClientModel)obj).LastName
                || Gender != ((ClientModel)obj).Gender
                || BirthDay != ((ClientModel)obj).BirthDay
                || Email != ((ClientModel)obj).Email
                || PhoneNumber != ((ClientModel)obj).PhoneNumber
                || Password != ((ClientModel)obj).Password
                || IsDeleted != ((ClientModel)obj).IsDeleted)
            {
                return false;
            }

            return true;
        }
    }
}
