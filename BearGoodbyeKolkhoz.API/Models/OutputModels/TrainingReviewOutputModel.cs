using BearGoodbyeKolkhozProject.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingReviewOutputModel
    {
        public int Id { get; set; }
        public ClientOutputModel Client { get; set; }
        public TrainingOutputModel Training { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
    }
}
