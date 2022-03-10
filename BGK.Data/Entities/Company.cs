using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long Tin { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TrainingReview>? TrainingReviews { get; set; }
        public virtual ICollection<LecturerReview>? LecturerReviews { get; set; }
    }
}
