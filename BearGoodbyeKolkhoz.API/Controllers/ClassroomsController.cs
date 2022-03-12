using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [Route("api/classrooms")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [SwaggerTag("The controller can be used after authentication/authorization under the role of Admin.")]
    public class ClassroomsController : Controller
    {
        private readonly IClassroomService _service;
        private readonly IMapper _mapper;

        public ClassroomsController(IClassroomService classroomService, IMapper mapper)
        {
            _service = classroomService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClassroomOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show info Classroom")]
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
        [HttpGet]
        [ProducesResponseType(typeof(List<ClassroomOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show List info classroom")]
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

        [HttpPost]
        [ProducesResponseType(typeof(CreateOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Add new Classroom")]
        public ActionResult<int> AddNewClassroom(ClassroomInsertInputModel newItem)
        {
            var model = _mapper.Map<ClassroomModel>(newItem);
            var res = _service.AddNewClassroom(model);

            if (res == null)
            {
                return NotFound($"Failed to create new location. | Не удалось создать новое место.");
            }
            else
            {
                return StatusCode(StatusCodes.Status201Created, new CreateOutputModel { createId = res });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Delete Classroom")]
        public ActionResult<bool> DeleteClassroomById(int id)
        {
            return Ok(_service.DeleteClassroom(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Delete Classroom")]
        public ActionResult<bool> UpdateClassroom(int id, [FromBody] ClassroomIUpdateInputModel newItem)
        {
            var model = _mapper.Map<ClassroomModel>(newItem);
            var res = _service.UpdateClassroomInfo(id, model);
            return Ok(res);
        }
    }
}
