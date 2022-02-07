using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/training")]
    public class TrainingController : Controller
    {
        private readonly ITrainingService _service;

        public TrainingController(ITrainingService trainingService)
        {
            _service = trainingService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingById(int id)
        {

            var entity = _service.GetTrainingModelById(id);
            var result = CustomMapper.GetInstance().Map<TrainingOutputModel>(entity);

            if (result == null)
            {
                return NotFound($"Лекция номер {id} не найдена");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        public IActionResult GetTrainings()
        {
            var entities = _service.GetTrainingModelsAll();
            return Ok(CustomMapper.GetInstance().Map<List<TrainingOutputModel>>(entities));
        }
    }
}
