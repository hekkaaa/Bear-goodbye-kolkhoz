using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[conroller]")]
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}
