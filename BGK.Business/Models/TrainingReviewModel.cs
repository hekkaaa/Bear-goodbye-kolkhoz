namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class TrainingReviewModel
    {
        public int Id { get; set; }
        //public ClientModel Client { get; set; }
        public TrainingModel Training { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }

    }
}
