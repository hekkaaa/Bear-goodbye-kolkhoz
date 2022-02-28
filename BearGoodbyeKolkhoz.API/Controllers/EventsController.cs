using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
         public ActionResult<List<EventOutputModel>> GetEvents()
         {
             var entity = _service.GetEvents();
         
             var result = _mapperApi.Map<List<EventOutputModel>>(entity);
         
             if (result == null) return NotFound($"Нет данных");
         
             return Ok(result);
         }
         
         //api/events/
         [HttpGet("{id}")]
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
        public ActionResult<EventUpdateInputModel> UpdateEvent(int id, [FromBody] EventUpdateInputModel eventUpdateInputModel)
        {
             EventModel entity = _mapperApi.Map<EventModel>(eventUpdateInputModel);
         
             _service.UpdateEvent(id, entity);
         
             return Ok(entity);
        }
         
         //api/events/
         [HttpDelete("{id}")]
         [Authorize(Roles = "Admin")]
        public ActionResult<EventUpdateInputModel> DeleteEvent(int id)
        {
             _service.DeleteEvent(id);
         
             return NoContent();
        }
        
    }
}
