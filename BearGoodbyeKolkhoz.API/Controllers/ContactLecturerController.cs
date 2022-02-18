﻿using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContactLecturerController : Controller
    {
        private readonly IContactLecturerService _service;

        private IMapper _mapperApi;

        public ContactLecturerController(IContactLecturerService contactLecturerService, IMapper mapper)
        {
            _service = contactLecturerService;

            _mapperApi = mapper;
        }
        //api/contactlecturer/
        [HttpPost()]
        public ActionResult<ContactLecturerInsertInputModel> AddValue([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {

            ContactLecturerModel entity = _mapperApi.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _service.AddValue(entity);

            return StatusCode(StatusCodes.Status201Created, entity);


        }
    }
}
