namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingReviewInputModel : TrainingReviewUpdateInputModel
    {
        public int ClientId { get; set; }
        public int TrainingId { get; set; }
    }
}
