﻿using Microsoft.AspNetCore.Mvc;
using BearGoodbyeKolkhozProject.API.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Interfaces;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : Controller
    {
        private readonly ILecturerService _service;

        public LecturerController(ILecturerService lecturerService)
        {
            _service = lecturerService;
        }

        [HttpGet()]
        public ActionResult<List<LecturerOutputModel>> GetLecturers()
        {
            var entity = _service.GetLecturers();
            var result = CustomMapper.GetInstance().Map<List<LecturerOutputModel>>(entity);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<LecturerOutputModel> GetLecturerById(int id)
        {
            var entity = _service.GetLecturerById(id);
            var result = CustomMapper.GetInstance().Map<LecturerOutputModel>(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLecturerById(int id)
        {
            _service.DeleteLecturerById(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult LecturerRegistration(LecturerRegistrationInputModel model)
        {
            LecturerModel entity = CustomMapper.GetInstance().Map<LecturerModel>(model);
            _service.RegistrationLecturer(entity);
            return StatusCode(StatusCodes.Status201Created, entity);
        }

        [HttpPost]
        public ActionResult AddTraining(int id, int trainingId)
        {
            _service.AddTraining(id, trainingId);
            return Ok();
        }
    }
}