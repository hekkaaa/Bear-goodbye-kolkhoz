using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[conroller]")]
    public class EventsController : Controller
    {
        [HttpPost]
        public ActionResult AddEvent()
        {
            return NoContent();
        }


    }
}
