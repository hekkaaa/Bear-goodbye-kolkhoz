using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPut("{id}/password")]
        public ActionResult<bool> ChangePasswordAdminById(int id, [FromBody] AdminChangePasswordInputModel newItem)
        {
            var model = _mapper.Map<AdminModel>(newItem);
            var res = _service.ChangeAdminPassword(id, model);
            return Ok(res);
        }
    }
}
