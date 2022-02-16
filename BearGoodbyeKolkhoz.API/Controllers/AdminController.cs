﻿using AutoMapper;
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
    }
}
