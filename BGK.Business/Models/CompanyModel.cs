﻿using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public List<TrainingReview>? TrainingReviews { get; set; }
        public List<LecturerReview>? LecturerReviews { get; set; }


    }
}
