using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TrainingReview> TrainingReviews { get; set; }
        public virtual ICollection<LecturerReview> LecturerReviews { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
