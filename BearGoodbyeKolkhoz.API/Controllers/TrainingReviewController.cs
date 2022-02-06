using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    public class TrainingReviewController : Controller
    {
        private TrainingReviewService _service = new TrainingReviewService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public ActionResult<TrainingReviewOutputModel> GetTrainingReviewById(int id)
        {
            var entity = _service.GetTrainingReviewModelById(id);
            var result = CustomMapper.GetInstance().Map<TrainingReviewOutputModel>(entity);

            if (result == null)
            {
                return NotFound($"Лекция {id} не найдена!");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        public ActionResult<List<TrainingReviewOutputModel>> GetTrainingReviews()
        {
            return Ok(new List<TrainingReviewOutputModel>());
        }



    }
}
