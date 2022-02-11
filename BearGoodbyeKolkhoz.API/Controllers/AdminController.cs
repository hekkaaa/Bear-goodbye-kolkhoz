using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpGet("{id}")]

        public ActionResult<AdminOutputModel> GetAdminById(int id)
        {   

            return new AdminOutputModel();
        }
    }
}
