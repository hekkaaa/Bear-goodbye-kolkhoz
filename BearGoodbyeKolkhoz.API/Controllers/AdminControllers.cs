using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminControllers : Controller
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public AdminControllers(IAdminService adminService, IMapper mapper)
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
    }
}
