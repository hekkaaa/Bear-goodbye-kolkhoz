using AutoMapper;
using BearGoodbyeKolkhozProject.API.Configuration.ExceptionResponse;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BearGoodbyeKolkhozProject.API.Controllers
{

    [ApiController]
    [Route("api/companies")]
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
        [ProducesResponseType(typeof(List<CompanyOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [SwaggerOperation("Show list Companies. Roles: Admin")]
        public ActionResult<List<CompanyOutputModel>> GetCompanies()
        {
            var entity = _companyService.GetCompanies();

            var result = _mapperApi.Map<List<CompanyOutputModel>>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/companies/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Company")]
        [ProducesResponseType(typeof(CompanyOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get company by id. Roles: Company")]

        public ActionResult<CompanyOutputModel> GetCompanyById(int id)
        {
            var entity = _companyService.GetCompanyById(id);

            var result = _mapperApi.Map<CompanyOutputModel>(entity);

            if (result == null) return NotFound($"Нет данных");

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
        [AllowAnonymous]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Add one company. Roles: AllowAnonymous")]

        public ActionResult<int> RegistrationCompany([FromBody] CompanyInsertInputModel companyInsertInputModel)
        {

            CompanyModel entity = _mapperApi.Map<CompanyModel>(companyInsertInputModel);

            var res = _companyService.RegistrationCompany(entity);

            return StatusCode(StatusCodes.Status201Created, res);


        }
        //api/companies/
        [HttpPut()]
        [Authorize(Roles = "Company")]
        [ProducesResponseType(typeof(CompanyOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Update Company. Roles: Company")]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany([FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(companyUpdateInputModel);

            _companyService.UpdateCompany(model);

            return Ok(model);

        }
   
        [HttpPut("{id}/password")]
        [Authorize(Roles = "Admin,Company")]
        [ProducesResponseType(typeof(CompanyOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        [SwaggerOperation("Update password Company by id. Roles: Admin,Company")]

        public ActionResult<ChangePasswordInputModel> UpdatePasswordCompanyById(int id, [FromBody] ChangePasswordInputModel newItem)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(newItem);
            _companyService.UpdatePasswordCompany(id, model.Password);
            return Ok(model);
        }
    }

}
