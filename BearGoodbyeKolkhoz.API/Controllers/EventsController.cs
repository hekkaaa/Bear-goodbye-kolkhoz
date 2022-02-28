﻿using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BearGoodbyeKolkhozProject.API.Configuration.ExceptionResponse;
using Swashbuckle.AspNetCore.Annotations;

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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CompanyOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [Description("Get events")]
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
        [ProducesResponseType(typeof(CompanyOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [Description("Get event by id")]
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
        [Description("Update event")]
        public ActionResult<EventUpdateInputModel> UpdateEvent(int id, [FromBody] EventUpdateInputModel eventUpdateInputModel)
        {
             EventModel entity = _mapperApi.Map<EventModel>(eventUpdateInputModel);
         
             _service.UpdateEvent(id, entity);
         
             return Ok(entity);
        }
         
         //api/events/
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [Description("Deleted event")]
        [Authorize(Roles = "Admin")]
        public ActionResult<EventUpdateInputModel> DeleteEvent(int id)
        {
             _service.DeleteEvent(id);
         
             return NoContent();
        }
        
    }
}
