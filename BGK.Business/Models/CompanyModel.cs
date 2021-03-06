using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Tin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<TrainingReview> TrainingReviews { get; set; }
        public ICollection<LecturerReview> LecturerReviews { get; set; }
    }
}
