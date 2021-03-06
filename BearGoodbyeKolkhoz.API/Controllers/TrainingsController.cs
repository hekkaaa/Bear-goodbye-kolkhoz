using AutoMapper;
using BearGoodbyeKolkhozProject.API.Extensions;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/trainings")]
    [SwaggerTag("This controller allows you to manipulate trainings and everything related to it.")]
    public class TrainingsController : Controller
    {
        private readonly ITrainingService _service;
        private readonly IEventService _eventService;
        private readonly ITrainingReviewService _trainingReviewService;
        private IMapper _mapper;

        public TrainingsController(ITrainingService trainingService, ITrainingReviewService trainingReviewService, IEventService eventService, IMapper mapper)
        {
            _service = trainingService;
            _eventService = eventService;
            _trainingReviewService = trainingReviewService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Client, Lector, Company")]
        [SwaggerOperation("Get training by ID. Roles: Admin, Client, Lector, Company")]
        [ProducesResponseType(typeof(TrainingOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult GetTrainingById(int id)
        {
            var model = _service.GetTrainingModelById(id);
            var result = _mapper.Map<TrainingOutputModel>(model);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation("Get all trainings. Roles: all")]
        [ProducesResponseType(typeof(List<TrainingOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult GetTrainings()
        {
            var models = _service.GetTrainingModels();
            return Ok(_mapper.Map<List<TrainingOutputModel>>(models));
        }

        [HttpGet("by-topic/{topicId}")]
        [SwaggerOperation("Get training by topic (hashtag). Input topic id. Roles: all")]
        [ProducesResponseType(typeof(List<TrainingOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult GetTrainingsByTopic(int topicId)
        {
            var model = _service.GetTrainingModelByTopic(topicId);
            return Ok(_mapper.Map<TrainingOutputModel>(model));
        }

        [HttpPost("{id}/topic/{topicId}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Add topic to training. Roles: Admin")]
        [ProducesResponseType(typeof(string),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult AddTopicToTraning(int id, int topicId)
        {
            _service.AddTopicToTraining(id, topicId);
            return StatusCode(StatusCodes.Status201Created, "Новый интерес у тренинга успешно добавлен");
        }

        [HttpPost("{id}/review")]
        [Authorize(Roles = "Client")]
        [SwaggerOperation("Add review to training. Roles: client")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult AddReviewToTraining(int id, [FromBody] TrainingReviewInsertInputModel trainingReview)
        {

            var clientId = HttpContext.GetUserIdFromToken();

            _service.AddReviewToTraining(id, clientId, _mapper.Map<TrainingReviewModel>(trainingReview));
            return Ok("Новый обзор на тренинг успешно добавлен");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Update training. Roles: Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult UpdateTraining(int id, [FromBody] TrainingUpdateInputModel trainingUpdateInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingUpdateInputModel);
            _service.UpdateTraining(id, training);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Add new training. Roles: Admin")]
        [ProducesResponseType(typeof(string),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult AddTraining([FromBody] TrainingInsertInputModel trainingInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingInputModel);

            return StatusCode(StatusCodes.Status201Created, _service.AddTraining(training));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Soft delete training. Roles: Admin")]
        [ProducesResponseType(typeof(bool),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<bool> DeleteTraining(int id)
        {
            var res = _service.DeleteTraining(id);
            return Ok(res);
        }

        [HttpPost("{id}/signup")]
        [Authorize(Roles = "Client, Company")]
        [SwaggerOperation("Sign up for training. Roles: Client, Company")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        public ActionResult<bool> SignUp(int id)
        {
            var clientId = HttpContext.GetUserIdFromToken();
            var res = _eventService.SignUp(id, clientId);

            return Ok(res);
        }

        [HttpGet("{id}/reviews")]
        [AllowAnonymous]
        [SwaggerOperation("Get all training reviews. Roles: AllowAnonymous")]
        public ActionResult<List<TrainingReviewOutputModel>> GetReviewes(int id)
        {
            List<TrainingReviewModel> reviews = _trainingReviewService.GetReviewsByTrainingId(id);
            return Ok(_mapper.Map<List<TrainingReviewOutputModel>>(reviews));
        }

    }
}
