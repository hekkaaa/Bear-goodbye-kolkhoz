using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventsController : Controller
    {
        private readonly IEventService _service;

        private IMapper _mapperApi;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _service = eventService;

            _mapperApi = mapper;
        }

        //api/events/
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<EventOutputModel>> GetEvents()
        {
            var entity = _service.GetEvents();

            var result = _mapperApi.Map<List<EventOutputModel>>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/events/
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<EventOutputModel> GetEventById(int id)
        {
            var entity = _service.GetEventById(id);

            var result = _mapperApi.Map<EventOutputModel>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        ////api/events/
        [HttpPost()]
        [ProducesResponseType(typeof(EventUpdateInputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [Authorize(Roles = "Admin")]
        public ActionResult<EventUpdateInputModel> AddEvent([FromBody] EventUpdateInputModel eventOutputModel)
        {

            EventModel entity = _mapperApi.Map<EventModel>(eventOutputModel);

            _service.AddEventFromClient(entity);

            return StatusCode(StatusCodes.Status201Created, entity);

        }

        //api/events/
        [HttpPut()]
        [ProducesResponseType(typeof(EventUpdateInputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [Authorize(Roles = "Admin")]
        public ActionResult<EventUpdateInputModel> UpdateEvent(int id, [FromBody] EventUpdateInputModel eventUpdateInputModel)
        {
            EventModel entity = _mapperApi.Map<EventModel>(eventUpdateInputModel);

            _service.UpdateEvent(id, entity);

            return Ok(entity);
        }

        //api/events/
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EventUpdateInputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [Authorize(Roles = "Admin")]
        public ActionResult<EventUpdateInputModel> DeleteEvent(int id)
        {
            _service.DeleteEvent(id);

            return NoContent();
        }

    }
}