using Microsoft.AspNetCore.Mvc;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Services;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        private LecturerService _service = new LecturerService();

        [HttpDelete("{id}")]
        public ActionResult DeleteLecturerById(int id)
        {
            _service.DeleteLecturerById(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetLecturerById(int id)
        {
            return Ok();
        }
    }
}