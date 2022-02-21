using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public ActionResult LecturerRegistration([FromBody] RegistrationInputModel model)
        {
            ClientModel entity = _mapper.Map<ClientModel>(model);
            _service.RegistrationClient(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpGet()]
        public ActionResult<List<ClientOutputModel>> GetLecturers()
        {
            var clients = _service.GetClients();
            var result = _mapper.Map<List<ClientOutputModel>>(clients);
            return Ok(result);
        }

        [HttpPut("/{id}")]
        public ActionResult UpdateClient(int id, [FromBody] UpdateInputModel model)
        {
            var entity = _mapper.Map<ClientModel>(model);
            _service.UpdateClientInfo(id, entity);
            return NoContent();
        }

        [HttpPut("{id}/password")]
        public ActionResult ChangePassword(int id, [FromBody] ChangePasswordInputModel newItem)
        {
            _service.ChangePasswordClient(id, newItem.Password);
            return Ok();
        }
    }
}
