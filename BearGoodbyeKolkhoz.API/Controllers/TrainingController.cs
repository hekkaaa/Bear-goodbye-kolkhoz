using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult GetTrainingById()
        {
            return View();
        }
        public IActionResult GetTrainings()
        {
            return View();
        }
    }
}
