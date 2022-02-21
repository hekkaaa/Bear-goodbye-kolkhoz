using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/training")]
    public class TrainingController : Controller
    {
        private readonly ITrainingService _service;
        private IMapper _mapper;

        public TrainingController(ITrainingService trainingService, IMapper mapper)
        {
            _service = trainingService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult GetTrainingById(int id)
        {
            var model = _service.GetTrainingModelById(id);
            var result = _mapper.Map<TrainingOutputModel>(model);
            return Ok(result);
        }

        [HttpGet]
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
        public ActionResult AddTopicToTraning(int id, int topicId)
        {
            _service.AddTopicToTraining(id, topicId);
            return Ok("Новый интерес у тренинга успешно добавлен");
        }

        [HttpPost("{id}/review")]
        public ActionResult AddReviewToTraining(int id, [FromBody] TrainingReviewInsertInputModel trainingReview)
        {
            _service.AddReviewToTraining(id, trainingReview.ClientId, _mapper.Map<TrainingReviewModel>(trainingReview));
            //дописать после мерджа получение айди клиента из токена
            return Ok("Новый обзор на тренинг успешно добавлен");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTraining(int id, [FromBody] TrainingUpdateInputModel trainingUpdateInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingUpdateInputModel);
            _service.UpdateTraining(id, training);

            return Ok("Тренинг успешно обновлен");
        }

        [HttpPost]
        public ActionResult AddTraining([FromBody] TrainingInsertInputModel trainingInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingInputModel);
            _service.AddTraining(training);
            return Ok("Тренинг успешно добавлен");
        }

        [HttpPatch("{id}")]
        public ActionResult DeleteTraining(int id)
        {
            _service.DeleteTraining(id);
            return Ok("Тренинг успешно удален");
        }

        [HttpPost("test")]
        public ActionResult TestEmail()
        {
            _service.SendEmail();
            return Ok();
        }
    }
}
