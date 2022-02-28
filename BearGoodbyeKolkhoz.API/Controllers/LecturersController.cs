using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
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

        [HttpPatch("{id}")]
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

        [HttpPost()]
        
        public ActionResult LecturerRegistration([FromBody] LecturerRegistrationInputModel model)
        {
            LecturerModel entity = _mapper.Map<LecturerModel>(model);
            _service.RegistrationLecturer(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLecturer(int id, [FromBody] UpdateInputModel model)
        {
            var entity = _mapper.Map<LecturerModel>(model);
            _service.UpdateLecturer(id, entity);
            return NoContent();
        }

        [HttpPost("add-training")]
        public ActionResult AddTraining(int id, int trainingId)
        {
            _service.AddTraining(id, trainingId);
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/contactlecturer/
        [HttpPost("{LecturerId}")]
        public ActionResult<ContactLecturerInsertInputModel> AddContactLecturerValueApi    // Данный метод позволяет компании ставить оценку Лектору за проведенное мероприятие
            ([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            ContactLecturerModel model = _mapper.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _contactLecturerService.AddContactLecturerValue(model);

            return StatusCode(StatusCodes.Status201Created, model);
        }

        //api/contactlecturer/
        [HttpPut("{LecturerId}")]
        public ActionResult<ContactLecturerInsertInputModel> UpdateContactLecturerValueApi   // Данный метод позволяет компании изменить оценку Лектору за проведенное мероприятие
            ([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            ContactLecturerModel entity = _mapper.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _contactLecturerService.UpdateContactLecturerValue(entity);

            return Ok(entity);


        }
    }
}