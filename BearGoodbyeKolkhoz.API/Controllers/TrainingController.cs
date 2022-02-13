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

        [HttpGet("id/{id}")]
        public IActionResult GetTrainingById(int id)
        {

            var model = _service.GetTrainingModelById(id);
            var result = _mapper.Map<TrainingOutputModel>(model);
            return Ok(result);

        }

        [HttpGet("all")]
        public IActionResult GetTrainings()
        {
            var models = _service.GetTrainingModels();
            return Ok(_mapper.Map<List<TrainingOutputModel>>(models));
        }

        [HttpGet("topic/{topic}")]
        public IActionResult GetTrainingsByTopic(TopicInputModel topicInputModel)
        {
            var model = _service.GetTrainingModelByTopic(_mapper.Map<TopicModel>(topicInputModel));
            return Ok(_mapper.Map<TrainingOutputModel>(model));
        }
    }
}
