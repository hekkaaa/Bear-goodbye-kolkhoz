using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("lecturer/login")]
        public ActionResult LecturerLogin([FromBody] LecturerInputAuthModel authModel)
        {
            var token = _authService.LoginLecturer(authModel.Email, authModel.Password);
            return Json(token);
        }
    }
}