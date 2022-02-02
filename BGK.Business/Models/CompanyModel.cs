using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class CompanyModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int Tin { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Password { get; set; }
        bool IsDeleted { get; set; }

        List<TrainingReview> TrainingReviews { get; set; }
        List<LecturerReview> LecturerReviews { get; set; }
    }
}
