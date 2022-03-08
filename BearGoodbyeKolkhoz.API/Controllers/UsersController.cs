using AutoMapper;
using BearGoodbyeKolkhozProject.API.Extensions;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _service = userService;
            _mapper = mapper;
        }

        [HttpPut("self")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status500InternalServerError)]
        [SwaggerOperation("Self-Delete/Ban Account. Roles: Client, Company, Lecturer")]
        [Authorize(Roles = "Client, Company, Lecturer")]
        public ActionResult<bool> DeleteAccountUser()
        {
            int id = HttpContext.GetUserIdFromToken();
            return Ok(_service.DeleteUserById(id));
        }

        [HttpPut("{email}/restore")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status500InternalServerError)]
        [SwaggerOperation("Restore User. Roles: Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> RestoreUserById(string email)
        {
            return Ok(_service.RecoverUserByEmail(email));// тут будет метод восстановления. 
        }

        [HttpPut("{id}/delete-ban")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status500InternalServerError)]
        [SwaggerOperation("Delete/ban. Roles: Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> RestoreAdminById(int id)
        {
            return Ok(_service.DeleteUserById(id));
        }
    }
}