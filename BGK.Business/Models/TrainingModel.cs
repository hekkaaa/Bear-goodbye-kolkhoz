namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class TrainingModel
    {

        public TrainingModel()
        {
            Topics = new List<TopicModel>();
            TrainingReviews = new List<TrainingReviewModel>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MembersCount { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }

        public List<TrainingReviewModel> TrainingReviews { get; set; }
        public List<TopicModel> Topics { get; set; }
    }
}
