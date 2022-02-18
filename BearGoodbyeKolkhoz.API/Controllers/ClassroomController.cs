using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [Route("api/classrooms")]
    [ApiController]
    public class ClassroomController : Controller
    {
        private readonly IClassroomService _service;
        private readonly IMapper _mapper;

        public ClassroomController(IClassroomService classroomService, IMapper mapper)
        {
            _service = classroomService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<ClassroomOutputModel> GetClassroomById(int id)
        {
            var model = _service.GetClassroomById(id);
            var res = _mapper.Map<ClassroomOutputModel>(model);

            if (res == null)
            {
                return NotFound($"There is no data for the specified id {id} | Нет данных для указанного идентификатора {id}");
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpGet("all")]
        public ActionResult<List<ClassroomOutputModel>> GetClassroomAll()
        {
            var res = _service.GetClassroomAll();

            if (res == null)
            {
                return NotFound($"The database does not contain any data. | База данных не содержит никаких данных.");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPost("add")]
        public ActionResult<int> AddNewClassroom(ClassroomInsertInputModel newItem)
        {
            var model = _mapper.Map<ClassroomModel>(newItem);
            var res = _service.AddNewClassroom(model);

            if (res == null)
            {
                return NotFound($"Failed to create new user. | Неудалось создать нового пользователя.");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteClassroomById(int id)
        {
            return Ok(_service.DeleteClassroom(id));
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdateClassroom(int id, [FromBody] ClassroomIUpdateInputModel newItem)
        {
            var model = _mapper.Map<ClassroomModel>(newItem);
            var res = _service.UpdateClassroomInfo(id, model);
            return Ok(res);
        }
    }
}
