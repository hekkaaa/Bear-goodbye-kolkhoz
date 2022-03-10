using AutoMapper;
using BearGoodbyeKolkhozProject.API.Configuration.ExceptionResponse;
using BearGoodbyeKolkhozProject.API.Extensions;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/lecturers")]
    public class LecturersController : Controller
    {
        private readonly ILecturerService _service;
        private IContactLecturerService _contactLecturerService;
        private IMapper _mapper;


        public LecturersController(ILecturerService lecturerService, IMapper mapper, IContactLecturerService contactLecturerService)
        {
            _contactLecturerService = contactLecturerService;
            _service = lecturerService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<LecturerOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show list of all Lecturer. Roles: Admin")]
        public ActionResult<List<LecturerOutputModel>> GetLecturers()
        {
            var lecturers = _service.GetLecturers();
            var result = _mapper.Map<List<LecturerOutputModel>>(lecturers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LecturerOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show info Lecturer. Roles: AllowAnonymous")]

        public ActionResult<LecturerOutputModel> GetLecturerById(int id)
        {
            var entity = _service.GetLecturerById(id);
            var result = _mapper.Map<LecturerOutputModel>(entity);
            return Ok(result);
        }

        [HttpGet("trainings")]
        [Authorize(Roles = "Lecturer")]
        [ProducesResponseType(typeof(List<TrainingOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show list trainings for Lecturer. Roles: Lecturer")]
        
        public ActionResult<List<TrainingOutputModel>> GetTrainingByLecturerId()
        {
            int id = HttpContext.GetUserIdFromToken();
            var trainings = _service.GetTrainingByLecturerId(id);

            return Ok(trainings);
        }

        [HttpPost()]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserCreateOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Registration new Lecturer. Roles: AllowAnonymous")]
        public ActionResult<UserCreateOutputModel> LecturerRegistration([FromBody] RegistrationInputModel model)
        {
            LecturerModel entity = _mapper.Map<LecturerModel>(model);
            var res = _service.RegistrationLecturer(entity);
            return StatusCode(StatusCodes.Status201Created, new UserCreateOutputModel{ createId = res });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Lecturer")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Edit info Lecturer. Roles: Lecturer")]
        public ActionResult UpdateLecturer(int id, [FromBody] UpdateInputModel model)
        {
            var entity = _mapper.Map<LecturerModel>(model);
            _service.UpdateLecturer(id, entity);
            return NoContent();
        }

        [HttpPost("training/{trainingId}")]
        [Authorize(Roles = "Lecturer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Add traning Lector. Roles: Lecturer")]
        public ActionResult<bool> AddTraining(int trainingId)
        {
            int id = HttpContext.GetUserIdFromToken();
            var res = _service.AddTraining(id, trainingId);
           
            return StatusCode(StatusCodes.Status201Created, res);
        }

        [HttpDelete("delete_training/{id}")]
        [Authorize(Roles = "Lecturer, Admin")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Delete Traning. Roles: Lecturer, Admin")]

        public ActionResult DeleteTraining(int id)
        {
            int lecturerId = HttpContext.GetUserIdFromToken();
            _service.DeleteTraining(lecturerId, id);

            return NoContent();
        }
    }
}