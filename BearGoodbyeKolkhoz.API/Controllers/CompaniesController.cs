using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{

    [ApiController]
    [Route("api/company")]    
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
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<CompanyOutputModel>> GetCompanies()
        {
            var entity = _companyService.GetCompanies();

            var result = _mapperApi.Map<List<CompanyOutputModel>>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/companies/
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<CompanyOutputModel> GetCompanyById(int id)
        {
            var entity = _companyService.GetCompanyById(id);

            var result = _mapperApi.Map<CompanyOutputModel>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public ActionResult<CompanyInsertInputModel> RegistrationCompany([FromBody] CompanyInsertInputModel companyInsertInputModel)
        {

            CompanyModel entity = _mapperApi.Map<CompanyModel>(companyInsertInputModel);

            _companyService.RegistrationCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);


        }
        //api/companies/
        [HttpPut()]
        [Authorize(Roles = "Company")]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany([FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(companyUpdateInputModel);

            _companyService.UpdateCompany(model);

            return Ok(model);

        }
        [HttpPatch("{id}")]
        public ActionResult<CompanyOutputModel> UpdateCompany(int id, bool isDel)
        {
            _companyService.UpdateCompany(id, isDel);

            return NoContent();

        }
        //api/companies/
        [HttpDelete("{id}")]
        public ActionResult<CompanyUpdateInputModel> DeleteCompany(int id)
        {

            _companyService.DeleteCompany(id);

            return NoContent();
        }
       

        [HttpPut("{id}/password")]
        public ActionResult<ChangePasswordInputModel> UpdatePasswordCompanyById(int id, [FromBody] ChangePasswordInputModel newItem)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(newItem);
            _companyService.UpdatePasswordCompany(id, model.Password);
            return Ok(model);
        }
    }

}       
