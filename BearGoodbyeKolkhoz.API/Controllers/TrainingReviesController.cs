using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/training-review")]
    public class TrainingReviesController : Controller
    {

        private readonly ITrainingReviewService _service;
        private readonly IMapper _mapper;


        public TrainingReviesController(ITrainingReviewService trainingReviewService, IMapper mapper)
        {
            _service = trainingReviewService;
            _mapper = mapper;
        }


    }
}
