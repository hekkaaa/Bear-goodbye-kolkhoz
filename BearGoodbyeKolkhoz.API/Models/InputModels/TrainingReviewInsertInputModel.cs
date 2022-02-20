namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingReviewInsertInputModel
    {
        public int ClientId { get; set; }
        public CompanyInputModel? Company { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
    }
}
