﻿using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        private IContactLecturerService _contactLecturerService;

        private IMapper _mapperApi;

        public CompaniesController(ICompanyService companyService, IContactLecturerService contactLecturerService, IMapper mapper)
        {
            _companyService = companyService;

            _contactLecturerService = contactLecturerService;

            _mapperApi = mapper;
        }


        //api/companies/
        [HttpGet("(id/companies/)")]
        public ActionResult<List<CompanyOutputModel>> GetCompanies()
        {
            var entity = _companyService.GetCompanies();

            var result = _mapperApi.Map<List<CompanyOutputModel>>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/companies/
        [HttpGet("{id}")]
        public ActionResult<CompanyOutputModel> GetCompanyById(int id)
        {
            var entity = _companyService.GetCompanyById(id);

            var result = _mapperApi.Map<CompanyOutputModel>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
        public ActionResult<CompanyInsertInputModel> RegistrationCompany([FromBody] CompanyInsertInputModel companyInsertInputModel)
        {

            CompanyModel entity = _mapperApi.Map<CompanyModel>(companyInsertInputModel);

            _companyService.RegistrationCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);


        }
        //api/companies/
        [HttpPut()]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany([FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(companyUpdateInputModel);

            _companyService.UpdateCompany(model);

            return Ok(model);

        }
        [HttpPut("{id}/company/")]
        public ActionResult<CompanyOutputModel> UpdateCompany(int id, bool isDel)
        {
            _companyService.UpdateCompany(id, isDel);

            return NoContent();

        }
        //api/companies/
        [HttpDelete("{id}/company/")]
        public ActionResult<CompanyUpdateInputModel> DeleteCompany(int id)
        {

            _companyService.DeleteCompany(id);

            return NoContent();
        }

        //api/contactlecturer/
        [HttpPost("{LecturerId}")]
        public ActionResult<ContactLecturerInsertInputModel> AddContactLecturerValueApi    // Данный метод позволяет компании ставить оценку Лектору за проведенное мероприятие
            ([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            ContactLecturerModel entity = _mapperApi.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _contactLecturerService.AddContactLecturerValue(entity);

            return StatusCode(StatusCodes.Status201Created, entity);
        }

        //api/contactlecturer/
        [HttpPut("{LecturerId}")]
        public ActionResult<ContactLecturerInsertInputModel> UpdateContactLecturerValueApi   // Данный метод позволяет компании изменить оценку Лектору за проведенное мероприятие
            ([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            ContactLecturerModel entity = _mapperApi.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _contactLecturerService.UpdateContactLecturerValue(entity);

            return Ok(entity);


        }
    }
}
