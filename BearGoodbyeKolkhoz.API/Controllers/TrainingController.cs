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

        [HttpPatch("{trainingNewTopicInputModel.id}/new-topic")]
        public IActionResult AddTopicToTraning(TopicInputModel topicInputModel, TrainingNewTopicInputModel trainingNewTopicInputModel)
        {
            trainingNewTopicInputModel.Topics.Add(topicInputModel);
            var training = _mapper.Map<TrainingModel>(trainingNewTopicInputModel);
            _service.UpdateTraining(trainingNewTopicInputModel.Id, training);
            return Ok("Новый интерес у лекции успешно добавлен");
        }

        [HttpPatch("{trainingNewTopicInputModel.id}/new-topic")]
        public IActionResult AddReviewToTraining(TrainingReviewInputModel trainingReviewInputModel, TrainingNewReviewInputModel trainingNewReviewInputModel)
        {
            trainingNewReviewInputModel.TrainingReviews.Add(trainingReviewInputModel);
            var training = _mapper.Map<TrainingModel>(trainingNewReviewInputModel);
            _service.UpdateTraining(trainingNewReviewInputModel.Id, training);
            return Ok("Новый обзор на лекцию успешно добавлен");
        }

        [HttpPatch("{trainingUpdateInputModel.id}/edit")]
        public IActionResult UpdateTopic(TrainingUpdateInputModel trainingUpdateInputModel)
        {
            var training = _mapper.Map<TrainingModel>(trainingUpdateInputModel);
            _service.UpdateTraining(trainingUpdateInputModel.Id, training);
            return Ok("Лекция успешно обновлена");
        }
    }
}
