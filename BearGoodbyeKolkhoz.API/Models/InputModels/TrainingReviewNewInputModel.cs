using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingReviewInputModel
    {
        public ClientModel Client { get; set; }
        public TrainingModel Training { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
    }
}
