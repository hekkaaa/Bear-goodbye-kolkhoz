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

       

        [HttpGet("{id}")]
        public ActionResult<TrainingReviewOutputModel> GetTrainingReviewById(int id)
        {
            var entity = _service.GetTrainingReviewModelById(id);
            var result = CustomMapper.GetInstance().Map<TrainingReviewOutputModel>(entity);

            if (result == null)
            {
                return NotFound($"Обзор {id} на лекцию не найден!");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        public ActionResult<List<TrainingReviewOutputModel>> GetTrainingReviews()
        {
            var entities = _service.GetTrainingReviewModelsAll();
            return Ok(CustomMapper.GetInstance().Map<List<TrainingReviewOutputModel>>(entities));
        }



    }
}
