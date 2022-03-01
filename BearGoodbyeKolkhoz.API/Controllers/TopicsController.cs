using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/topic")]
    [Authorize(Roles = "Admin")]
    [SwaggerTag("This controller allows you to manipulate topics and everything related to it.")]
    public class TopicsController : Controller
    {
        private readonly ITopicService _service;
        private IMapper _mapper;

        public TopicsController(ITopicService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get topic by ID. Roles: Admin")]
        [ProducesResponseType(typeof(TopicOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult GetTopicById(int id)
        {
            var model = _service.GetTopicById(id);
            var result = _mapper.Map<TopicOutputModel>(model);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation("Get all topics. Roles: Admin")]
        [ProducesResponseType(typeof(List<TopicOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult GetTopics()
        {
            var models = _service.GetTopics();
            return Ok(_mapper.Map<List<TopicOutputModel>>(models));
        }

        [HttpPost]
        [SwaggerOperation("Add new topic. Roles: Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult AddTopic([FromBody] TopicInputModel topicInputModel)
        {
            var topic = _mapper.Map<TopicModel>(topicInputModel);
            _service.AddTopic(topic);
            return Ok("Новая тема успешно добавлена");
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update topic. Roles: Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult UpdateTopic(int id, [FromBody] TopicUpdateInputModel topicUpdate)
        {
            var topic = _mapper.Map<TopicModel>(topicUpdate);
            _service.UpdateTopic(topic, id);

            return Ok("Тема успешно обновлена");
        }

        [HttpPatch("{id}")]
        [SwaggerOperation("Delete topic by ID. Roles: Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult DeleteTraining(int id)
        {
            var topic = _service.GetTopicById(id);
            _service.DeleteTopic(topic);
            return NoContent();
        }

    }
}
