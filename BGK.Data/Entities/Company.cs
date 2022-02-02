using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TrainingReview> TrainingReviews { get; set; }
        public virtual ICollection<LecturerReview> LecturerReviews { get; set; }
    }
}
