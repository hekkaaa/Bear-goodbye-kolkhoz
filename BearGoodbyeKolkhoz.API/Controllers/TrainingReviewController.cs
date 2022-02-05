using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    public class TrainingReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public ActionResult GetTrainingReviewById(int id)
        {
            return NotFound($"Лекция {id} не найдена!");

            return Ok(new );
        }

        [HttpGet]
        public ActionResult<List<>> GetTrainingReviews()
        {
            return Ok(new List<>());
        }
    }
}
