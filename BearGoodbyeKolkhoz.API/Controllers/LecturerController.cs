using Microsoft.AspNetCore.Mvc;
using BearGoodbyeKolkhozProject.API.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Interfaces;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        private readonly ILecturerService _service;
        private ICustomMapper _mapper;

        public LecturerController(ILecturerService lecturerService, ICustomMapper mapper)
        {
            _service = lecturerService;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<List<LecturerOutputModel>> GetLecturers()
        {
            var lecturers = _service.GetLecturers();
            var result = _mapper.GetInstance().Map<List<LecturerOutputModel>>(lecturers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<LecturerOutputModel> GetLecturerById(int id)
        {
            var entity = _service.GetLecturerById(id);
            var result = _mapper.GetInstance().Map<LecturerOutputModel>(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLecturerById(int id)
        {
            _service.DeleteLecturerById(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult LecturerRegistration([FromBody] LecturerRegistrationInputModel model)
        {
            LecturerModel entity = _mapper.GetInstance().Map<LecturerModel>(model);
            _service.RegistrationLecturer(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLecturer([FromBody] LecturerUpdateInputModel model, int id)
        {
            var entity = _mapper.GetInstance().Map<LecturerModel>(model);
            _service.UpdateLecturer(id, entity);
            return NoContent();
        }

        // вот тута хзхз
        [HttpPost("{id}")]
        public ActionResult AddTraining(int id, int trainingId)
        {
            _service.AddTraining(id, trainingId);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}