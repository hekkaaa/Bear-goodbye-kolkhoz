using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Company")]
    public class Company : User
    {
        public long Tin { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ICollection<TrainingReview>? TrainingReviews { get; set; }
        public virtual ICollection<LecturerReview>? LecturerReviews { get; set; }
    }
}
