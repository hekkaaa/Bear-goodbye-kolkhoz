using Microsoft.AspNetCore.Mvc;
using BearGoodbyeKolkhozProject.API.Models;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        [HttpGet]
        public ActionResult RegistationLecturer()
        {
            return StatusCode(StatusCodes.Status201Created, new LecturerRegistrationInputModel { });
        }
    }
}