using AutoMapper;
using BearGoodbyeKolkhozProject.API.Extensions;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/lecturer")]
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
        [AllowAnonymous]
        public ActionResult<List<LecturerOutputModel>> GetLecturers()
        {
            var lecturers = _service.GetLecturers();
            var result = _mapper.Map<List<LecturerOutputModel>>(lecturers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<LecturerOutputModel> GetLecturerById(int id)
        {
            var entity = _service.GetLecturerById(id);
            var result = _mapper.Map<LecturerOutputModel>(entity);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin, Lecturer")]
        public ActionResult DeleteLecturerById(int id)
        {
            _service.DeleteLecturerById(id);
            return NoContent();
        }

        [HttpPatch("{id}/recover")]
        [Authorize(Roles = "Admin")]
        public ActionResult RecoverLecturerById(int id)
        {
            _service.RecoverLecturerById(id);
            return NoContent();
        }

        [HttpPost()]
        [AllowAnonymous]
        public ActionResult LecturerRegistration([FromBody] RegistrationInputModel model)
        {
            LecturerModel entity = _mapper.Map<LecturerModel>(model);
            _service.RegistrationLecturer(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Lecturer")]
        public ActionResult UpdateLecturer(int id, [FromBody] UpdateInputModel model)
        {
            var entity = _mapper.Map<LecturerModel>(model);
            _service.UpdateLecturer(id, entity);
            return NoContent();
        }

        [HttpPost("add-training")]
        [Authorize(Roles = "Lecturer")]
        public ActionResult AddTraining(int id, int trainingId)
        {
            _service.AddTraining(id, trainingId);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("delete_training/{id}")]
        [Authorize(Roles = "Lecturer, Admin")]
        public ActionResult DeleteTraining(int id)
        {
            int lecturerId = HttpContext.GetUserIdFromToken();
            _service.DeleteTraining(lecturerId, id);

            return NoContent();
        }

        [HttpPost("{LecturerId}")]
        [Authorize(Roles = "Lecturer")]
        public ActionResult<ContactLecturerInsertInputModel> AddContactLecturerValueApi
            ([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            ContactLecturerModel model = _mapper.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _contactLecturerService.AddContactLecturerValue(model);

            return StatusCode(StatusCodes.Status201Created, model);
        }

        [HttpPut("{LecturerId}")]
        [Authorize(Roles = "Lecturer")]
        public ActionResult<ContactLecturerInsertInputModel> UpdateContactLecturerValueApi
            ([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            ContactLecturerModel entity = _mapper.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _contactLecturerService.UpdateContactLecturerValue(entity);

            return Ok(entity);
        }
    }
}