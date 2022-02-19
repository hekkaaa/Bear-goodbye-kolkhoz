using Microsoft.AspNetCore.Mvc;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Interface;
using AutoMapper;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturersController : Controller
    {
        private readonly ILecturerService _service;
        private IMapper _mapper;

        public LecturersController(ILecturerService lecturerService, IMapper mapper)
        {
            _service = lecturerService;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<List<LecturerOutputModel>> GetLecturers()
        {
            var lecturers = _service.GetLecturers();
            var result = _mapper.Map<List<LecturerOutputModel>>(lecturers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<LecturerOutputModel> GetLecturerById(int id)
        {
            var entity = _service.GetLecturerById(id);
            var result = _mapper.Map<LecturerOutputModel>(entity);
            return Ok(result);
        }

        [HttpPatch("{id}/delete")]
        public ActionResult DeleteLecturerById(int id)
        {
            _service.DeleteLecturerById(id);
            return NoContent();
        }

        [HttpPatch("{id}/recover")]
        public ActionResult RecoverLecturerById(int id)
        {
            _service.RecoverLecturerById(id);
            return NoContent();
        }

        [HttpPost("/registration")]
        public ActionResult LecturerRegistration([FromBody] LecturerRegistrationInputModel model)
        {
            LecturerModel entity = _mapper.Map<LecturerModel>(model);
            _service.RegistrationLecturer(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLecturer(int id, [FromBody] LecturerUpdateInputModel model)
        {
            var entity = _mapper.Map<LecturerModel>(model);
            _service.UpdateLecturer(id, entity);
            return NoContent();
        }

        [HttpPost("{id}/training")]
        public ActionResult AddTraining(int id, int trainingId)
        {
            _service.AddTraining(id, trainingId);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}