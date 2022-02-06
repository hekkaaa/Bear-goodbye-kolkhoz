using BearGoodbyeKolkhozProject.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingReviewUpdateInputModel
    {
        public string Text { get; set; }
        public int Mark { get; set; }

    }
}
