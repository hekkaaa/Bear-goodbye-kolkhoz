using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModel
{
    public class CompanyOutputModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Tin { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<TrainingReview> TrainingReviews { get; set; }
        public virtual List<LecturerReview> LecturerReviews { get; set; }
    }
}
