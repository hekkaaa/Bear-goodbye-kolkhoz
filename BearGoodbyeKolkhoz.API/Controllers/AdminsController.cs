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

    [Route("api/admins")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [SwaggerTag("The controller can be used after authentication/authorization under the role of Admin")]

    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        private readonly ITrainingReviewService _trainingReviewService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper, ITrainingReviewService trainingReviewService)
        {
            _service = adminService;
            _mapper = mapper;
            _trainingReviewService = trainingReviewService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdminOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Show info Admin")]
        public ActionResult<AdminOutputModel> GetAdminById(int id)
        {
            var model = _service.GetAdminById(id);
            var res = _mapper.Map<AdminOutputModel>(model);

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
        [ProducesResponseType(typeof(List<AdminOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation(Summary = "Show list of all Admins")]
        public ActionResult<List<AdminOutputModel>> GetAdminAll()
        {
            var res = _service.GetAdminAll();

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
        [ProducesResponseType(typeof(UserCreateOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Add new Admin")]
        public ActionResult<UserCreateOutputModel> AddNewAdmin(AdminInsertInputModel newItem)
        {
            var model = _mapper.Map<AdminModel>(newItem);
            var res = _service.AddNewAdmin(model);

            if (res == null)
            {
                return NotFound($"Failed to create new user. | Неудалось создать нового пользователя.");
            }
            else
            {
                return StatusCode(StatusCodes.Status201Created, new UserCreateOutputModel { createId = res });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Edit info Admin")]
        public ActionResult<bool> UpdateAdmin(int id, [FromBody] AdminUpdateInputModel newItem)
        {
            var model = _mapper.Map<AdminModel>(newItem);
            var res = _service.UpdateAdminInfo(id, model);
            return Ok(res);
        }

        [HttpPatch("{id}/password")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Edit password")]
        public ActionResult<bool> ChangePasswordAdminById(int id, [FromBody] ChangePasswordInputModel newItem)
        {
            var res = _service.ChangeAdminPassword(id, newItem.Password);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionOutputModel), StatusCodes.Status503ServiceUnavailable)]
        [SwaggerOperation("Delete TrainingReview")]
        public ActionResult<bool> DeleteTrainingReviewById(int id)
        {
            return Ok(_trainingReviewService.DeleteTrainingReview(id));
        }
    }
}
