using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public ActionResult GetTrainingById(int id)
        {
            return NotFound($"Лекция {id} не найдена!");

            return Ok(new );
        }

        [HttpGet]
        public ActionResult<List<>> GetTrainings()
        {
            return Ok(new List<>());
        }

    }
}
