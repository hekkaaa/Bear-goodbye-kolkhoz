using BearGoodbyeKolkhozProject.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingReviewOutputModel : Controller
    {
        //public int Id { get; set; }
        //public ClientModel Client { get; set; }
        //public TrainingModel Training { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
    }
}
