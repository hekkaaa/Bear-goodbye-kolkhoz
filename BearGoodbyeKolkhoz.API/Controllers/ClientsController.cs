using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/client")]
    [SwaggerTag("The controller can be used after authentication/authorization under the role of Admin/Client and Anonymous.")]

    public class ClientsController : Controller
    {
        private readonly IClientService _service;
        private IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _service = clientService;
            _mapper = mapper;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(ClientModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Add new Client")]
        [AllowAnonymous]

        public ActionResult ClientRegistration([FromBody] RegistrationInputModel model)
        {
            ClientModel entity = _mapper.Map<ClientModel>(model);
            _service.RegistrationClient(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<ClientOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show all list info Client")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<ClientOutputModel>> GetClients()
        {
            var clients = _service.GetClients();
            var result = _mapper.Map<List<ClientOutputModel>>(clients);
            return Ok(result);
        }

        [HttpPut("/{id}")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show info Client")]
        [Authorize(Roles = "Client")]
        public ActionResult UpdateClient(int id, [FromBody] UpdateInputModel model)
        {
            var entity = _mapper.Map<ClientModel>(model);
            _service.UpdateClientInfo(id, entity);
            return Ok();
        }

        [HttpPut("{id}/password")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Change password Client")]
        [Authorize(Roles = "Client")]
        public ActionResult ChangePassword(int id, [FromBody] ChangePasswordInputModel newItem)
        {
            _service.ChangePasswordClient(id, newItem.Password);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Edit info Client")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> DeleteAndBanUserById(int id)
        {
            return Ok(_service.DeleteClient(id));
        }

        [HttpPut("{id}/restore")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Restore ban/delete Client")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> RestoreUserById(int id)
        {
            return Ok(_service.RestoreClient(id));
        }
    }
}
