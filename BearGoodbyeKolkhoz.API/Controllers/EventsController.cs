using BearGoodbyeKolkhozProject.API.ConfigurationAPI;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModel;
using BearGoodbyeKolkhozProject.API.Models.OutputModel;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventService _service;

        public EventsController(IEventService eventService)
        {
            _service = eventService;
        }

        private CustomMapperApi _mapperApi = new CustomMapperApi();

        //api/events/21
        [HttpGet("(id)")]
        public ActionResult<List<EventOutputModel>> GetEvents()
        {
            var entity = _service.GetEvents();

            var result = CustomMapperApi.GetInstance().Map<List<EventOutputModel>>(entity);

            return Ok(result);
        }


        //api/events/1
        [HttpGet("{id}")]
        public ActionResult<EventOutputModel> GetEventById(int id)
        {
            var entity = _service.GetEventById(id);

            var result = CustomMapper.GetInstance().Map<EventOutputModel>(entity);

            return Ok(result);
        }

        ////api/events/1
        [HttpPost("{id}/event/client")]        
        public ActionResult<EventOutputModel> AddEventFromClient([FromBody] EventOutputModel eventOutputModel)
        {

            EventModel entity = CustomMapperApi.GetInstance().Map<EventModel>(eventOutputModel);

            _service.AddEventFromClient(entity);

            return StatusCode(StatusCodes.Status201Created, entity);

        }

        //api/events/1
        [HttpPost("{id}/event/company")]
        public ActionResult<EventOutputModel> AddEventFromCompany([FromBody] EventOutputModel eventOutputModel)
        {

            EventModel entity = CustomMapperApi.GetInstance().Map<EventModel>(eventOutputModel);

            _service.AddEventFromCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);

        }

        //api/events/1
        [HttpPut("{id}/event/client")]
        public ActionResult<EventUpdateInputModel> UpdateEventFromClient(int id, [FromBody] EventUpdateInputModel eventUpdateInputModel)
        {
            EventModel entity = CustomMapperApi.GetInstance().Map<EventModel>(eventUpdateInputModel);

            _service.UpdateEventFromClient(id, entity);

            return Ok(entity);
        }


        ////api/events/1
        [HttpPut("{id}/event/company")]
        public ActionResult<EventUpdateInputModel> UpdateEventFromCompany(int id, [FromBody] EventUpdateInputModel eventUpdateInputModel)
        {
            EventModel entity = CustomMapperApi.GetInstance().Map<EventModel>(eventUpdateInputModel);

            _service.UpdateEventFromCompany(id, entity);

            return Ok(entity);
        }

        [HttpPut("{id}/event/")]
        public ActionResult<EventUpdateInputModel> UpdateEvent(int id, bool isDel)
        {
            _service.UpdateEvent(id, isDel);

            return NoContent();

        }


        //api/events/1/
        [HttpDelete("{id}/event/")]
        public ActionResult<EventUpdateInputModel> DeleteEvent(int id)
        {
            _service.DeleteEvent(id);
          
            return NoContent();
        }

    }
}
