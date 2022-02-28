using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/client")]
    
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
        [AllowAnonymous]
        public ActionResult ClientRegistration([FromBody] RegistrationInputModel model)
        {
            ClientModel entity = _mapper.Map<ClientModel>(model);
            _service.RegistrationClient(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<ClientOutputModel>> GetClients()
        {
            var clients = _service.GetClients();
            var result = _mapper.Map<List<ClientOutputModel>>(clients);
            return Ok(result);
        }

        [HttpPut("/{id}")]
        [Authorize(Roles = "Client")]
        public ActionResult UpdateClient(int id, [FromBody] UpdateInputModel model)
        {
            var entity = _mapper.Map<ClientModel>(model);
            _service.UpdateClientInfo(id, entity);
            return NoContent();
        }

        [HttpPut("{id}/password")]
        [Authorize(Roles = "Client")]
        public ActionResult ChangePassword(int id, [FromBody] ChangePasswordInputModel newItem)
        {
            _service.ChangePasswordClient(id, newItem.Password);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> DeleteAndBanUserById(int id)
        {   
            return Ok(_service.DeleteClient(id));
        }

        [HttpPut("{id}/restore")]
        [Authorize(Roles = "Admin")]
        public ActionResult<bool> RestoreUserById(int id)
        {
            return Ok(_service.RestoreClient(id));
        }
    }
}
