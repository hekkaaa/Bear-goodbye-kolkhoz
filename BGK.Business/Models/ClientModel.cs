﻿using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<TrainingReviewModel> TrainingReviews { get; set; }
        public List<LecturerReviewModel> LecturerReviews { get; set; }
        public List<TopicModel> Topic { get; set; }
    }
}
