﻿using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingOutputModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MembersCount { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }

        public List<TrainingReviewModel> TrainingReviews { get; set; }
        public List<TopicModel> Topic { get; set; }
    }
}