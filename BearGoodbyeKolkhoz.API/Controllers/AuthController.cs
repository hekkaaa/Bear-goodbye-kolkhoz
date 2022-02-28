using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation("Authentication")]
        public ActionResult Login([FromBody] AuthInputModel auth)
        {
            var token = _authService.GetToken(auth.Email, auth.Password, auth.Role);
            return Json(token);
        }
    }
}