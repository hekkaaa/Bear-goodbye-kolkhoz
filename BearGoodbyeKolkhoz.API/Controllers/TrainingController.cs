using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BearGoodbyeKolkhozProject.API.Extensions;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/training")]

    public class TrainingController : Controller
    {
        private readonly ITrainingService _service;
        private readonly IEventService _eventService;
        private IMapper _mapper;

        public TrainingController(ITrainingService trainingService, IEventService eventService, IMapper mapper)
        {
            _service = trainingService;
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Client, Lector, Company")]
        public ActionResult GetTrainingById(int id)
        {
            var model = _service.GetTrainingModelById(id);
            var result = _mapper.Map<TrainingOutputModel>(model);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetTrainings()
        {
            var models = _service.GetTrainingModels();
            return Ok(_mapper.Map<List<TrainingOutputModel>>(models));
        }

        [HttpGet("by-topic/{topicInputModel.Name}")]
        public ActionResult GetTrainingsByTopic(TopicInputModel topicInputModel)
        {
            var model = _service.GetTrainingModelByTopic(_mapper.Map<TopicModel>(topicInputModel));
            return Ok(_mapper.Map<TrainingOutputModel>(model));
        }

        [HttpPost("{id}/topic/{topicId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTopicToTraning(int id, int topicId)
        {
            _service.AddTopicToTraining(id, topicId);
            return Ok("Новый интерес у тренинга успешно добавлен");
        }

        [HttpPost("{id}/review")]
        [Authorize(Roles = "Client")]
        public ActionResult AddReviewToTraining(int id, [FromBody] TrainingReviewInsertInputModel trainingReview)
        {
            var clientId = HttpContext.GetUserIdFromToken();

            _service.AddReviewToTraining(id, clientId, _mapper.Map<TrainingReviewModel>(trainingReview));
            
            return Ok("Новый обзор на тренинг успешно добавлен");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateTraining(int id, [FromBody] TrainingUpdateInputModel trainingUpdateInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingUpdateInputModel);
            _service.UpdateTraining(id, training);

            return Ok("Тренинг успешно обновлен");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddTraining([FromBody] TrainingInsertInputModel trainingInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingInputModel);
            _service.AddTraining(training);
            return Ok("Тренинг успешно добавлен");
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTraining(int id)
        {
            _service.DeleteTraining(id);
            return Ok("Тренинг успешно удален");
        }

        [HttpPost("{id}/signup")]
        [Authorize(Roles = "Client, Company")]
        public ActionResult<bool> SugnUp(int id)
        {
            var clientId = HttpContext.GetUserIdFromToken();
            var res = _eventService.SignUp(id, clientId);

            return Ok(res);
        }
    }
}
