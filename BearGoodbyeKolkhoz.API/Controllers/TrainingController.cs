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
        public IActionResult GetTrainingById(int id)
        {
            var model = _service.GetTrainingModelById(id);
            var result = _mapper.Map<TrainingOutputModel>(model);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            var models = _service.GetTrainingModels();
            return Ok(_mapper.Map<List<TrainingOutputModel>>(models));
        }

        [HttpGet("by-topic/{topic}")]
        public IActionResult GetTrainingsByTopic(TopicInputModel topicInputModel)
        {
            var model = _service.GetTrainingModelByTopic(_mapper.Map<TopicModel>(topicInputModel));
            return Ok(_mapper.Map<TrainingOutputModel>(model));
        }

        [HttpPatch("{id}/new-topic")]
        public IActionResult AddTopicToTraning(int id, int topicId)
        {
            _service.AddTopicToTraining(id, topicId);
            return Ok("Новый интерес у лекции успешно добавлен");
        }

        [HttpPatch("{id}/new-review")]
        public IActionResult AddReviewToTraining(int id, [FromBody] TrainingReviewInsertInputModel trainingReview)
        {
            _service.AddReviewToTraining(id, _mapper.Map<TrainingReviewModel>(trainingReview));
            return Ok("Новый обзор на лекцию успешно добавлен");
        }

        [HttpPatch("{id}/edit")]
        public IActionResult UpdateTopic(int id, TrainingUpdateInputModel trainingUpdateInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingUpdateInputModel);
            _service.UpdateTraining(id, training);

            return Ok("Лекция успешно обновлена");
        }

        [HttpPost("new")]
        public IActionResult AddTraining([FromBody] TrainingInsertInputModel trainingInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingInputModel);
            _service.AddTraining(training);
            return Ok("Лекция успешно добавлена");
        }

        [HttpPatch("{id}/delete")]
        public IActionResult DeleteTraining(int id)
        {
            _service.DeleteTraining(id);
            return Ok("Лекция успешно удалена");
        }

    }
}
