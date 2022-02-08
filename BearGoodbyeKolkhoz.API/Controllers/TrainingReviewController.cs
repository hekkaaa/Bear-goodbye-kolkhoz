using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/training-review")]
    public class TrainingReviewController : Controller
    {

        private readonly ITrainingReviewService _service;

        public TrainingReviewController(ITrainingReviewService trainingReviewService)
        {
            _service = trainingReviewService;
        }


    }
}
