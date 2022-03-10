using AutoMapper;
using BearGoodbyeKolkhozProject.API.Configuration.ExceptionResponse;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/event")]
    [SwaggerTag("The controller can be used after authentication/authorization under the role of Admin")]

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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<EventOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get list Events. Roles: Admin")]

        public ActionResult<List<EventOutputModel>> GetEvents()
        {
            var entity = _service.GetEvents();

            var result = _mapperApi.Map<List<EventOutputModel>>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/events/
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(EventOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get Event by id. Roles: Admin")]
      
        public ActionResult<EventOutputModel> GetEventById(int id)
        {
            var entity = _service.GetEventById(id);

            var result = _mapperApi.Map<EventOutputModel>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }


        //api/events/
        [HttpPut()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(EventUpdateInputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Update Event. Roles: Admin")]
 
        public ActionResult<EventUpdateInputModel> UpdateEvent(int id, [FromBody] EventUpdateInputModel eventUpdateInputModel)
        {
            EventModel entity = _mapperApi.Map<EventModel>(eventUpdateInputModel);

            _service.UpdateEvent(id, entity);

            return Ok(entity);
        }

        //api/events/
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [SwaggerOperation("Deleted Event. Roles: Admin")]
       
        public ActionResult<EventUpdateInputModel> DeleteEvent(int id)
        {
            _service.DeleteEvent(id);

            return NoContent();
        }

    }
}