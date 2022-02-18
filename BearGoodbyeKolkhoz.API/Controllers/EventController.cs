using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/event/[controller]")]
    public class EventController : Controller
    {
               
            private readonly IEventService _service;

            private IMapper _mapperApi;

            public EventController(IEventService eventService, IMapper mapper)
            {
                _service = eventService;

                _mapperApi = mapper;
            }


            //api/events/21
            [HttpGet("(id)")]
            public ActionResult<List<EventOutputModel>> GetEvents()
            {
                var entity = _service.GetEvents();

                var result = _mapperApi.Map<List<EventOutputModel>>(entity);

                if (result == null) return NotFound($"Нет данных");

                return Ok(result);
            }


            //api/events/1
            [HttpGet("{id}")]
            public ActionResult<EventOutputModel> GetEventById(int id)
            {
                var entity = _service.GetEventById(id);

                var result = _mapperApi.Map<EventOutputModel>(entity);

                if (result == null) return NotFound($"Нет данных");

                return Ok(result);
            }

            ////api/events/1
            [HttpPost("{id}/event/client")]
            public ActionResult<EventUpdateClientInputModel> AddEventFromClient([FromBody] EventUpdateClientInputModel eventOutputModel)
            {

                EventModel entity = _mapperApi.Map<EventModel>(eventOutputModel);

                _service.AddEventFromClient(entity);

                return StatusCode(StatusCodes.Status201Created, entity);

            }

            //api/events/1
            [HttpPost("{id}/event/company")]
            public ActionResult<EventUpdateCompanyInputModel> AddEventFromCompany([FromBody] EventUpdateCompanyInputModel eventOutputModel)
            {

                EventModel entity = _mapperApi.Map<EventModel>(eventOutputModel);

                _service.AddEventFromCompany(entity);

                return StatusCode(StatusCodes.Status201Created, entity);

            }

            //api/events/1
            [HttpPut("{id}/event/client")]
            public ActionResult<EventUpdateClientInputModel> UpdateEventFromClient(int id, [FromBody] EventUpdateClientInputModel eventUpdateInputModel)
            {
                EventModel entity = _mapperApi.Map<EventModel>(eventUpdateInputModel);

                _service.UpdateEvent(id, entity);

                return Ok(entity);
            }


            ////api/events/1
            [HttpPut("{id}/event/company")]
            public ActionResult<EventUpdateCompanyInputModel> UpdateEventFromCompany(int id, [FromBody] EventUpdateCompanyInputModel eventUpdateInputModel)
            {
                EventModel entity = _mapperApi.Map<EventModel>(eventUpdateInputModel);

                _service.UpdateEvent(id, entity);

                return Ok(entity);
            }


            //api/events/1/
            [HttpDelete("{id}/event/")]
            public ActionResult<EventUpdateClientInputModel> DeleteEvent(int id)
            {
                _service.DeleteEvent(id);

                return NoContent();
            }
        
    }
}
