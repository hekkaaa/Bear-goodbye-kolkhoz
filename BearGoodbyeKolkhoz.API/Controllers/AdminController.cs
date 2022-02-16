using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _service = adminService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]

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
        public ActionResult<int> AddNewAdmin(AdminInsertInputModel newItem)
        {
            var model = _mapper.Map<AdminModel>(newItem);
            var res = _service.AddNewAdmin(model);

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
        public ActionResult<bool> DeleteAdminById(int id)
        {
            return Ok(_service.DeleteAdmin(id));
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdateAdmin(int id, [FromBody] AdminUpdateInputModel newItem)
        {
            var model = _mapper.Map<AdminModel>(newItem);
            var res = _service.UpdateAdminInfo(id, model);
            return Ok(res);
        }

        //api/admins/{id}/classroom
        [HttpDelete("{id}/classroom")]
        public ActionResult DeleteClassromById(int id)
        {
            // заглушка для удаления classroom
            return Ok();
        }

        [HttpPut("{id}/classroom")]
        public ActionResult UpdateClassroomById(AdminInsertInputModel newItem)
        {
            // заглушка для изменения classroom
            return Ok();
        }

        //api/admins/{id}/traning
        [HttpDelete("{id}/traning")]
        public ActionResult DeleteTraningById(int id)
        {
            // заглушка для удаления traning
            return Ok();
        }

        [HttpPut("{id}/traning")]
        public ActionResult UpdateTraningById(AdminInsertInputModel newItem)
        {
            // заглушка для изменения traning
            return Ok();
        }

        [HttpPut("{id}/lector/skills")]
        public ActionResult UpdateSkillLectorById(int id)
        {
            // заглушка для изменения скилов lector
            return Ok();
        }

        [HttpPut("{id}/user/ban")]
        public ActionResult BanUserById(int id)
        {
            // заглушка для бана негодяев
            return Ok();
        }

        [HttpPut("{id}/event/update")]
        public ActionResult UpdateEventById(int id/*какой то инпут обьект*/)
        {
            // заглушка для редактирования эвентов
            return Ok();
        }

    }
}
