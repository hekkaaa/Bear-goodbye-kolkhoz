using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Client")]
    public  class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string BirthDay { get; set; }

        public string Email { get; set; }

        [StringLength(20)]
        public int PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public List<TrainingReview> TrainingReviews { get; set; }
        public List<LecturerReview> LecturerReviews { get; set; }
    }
}
