using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;

        private IMapper _mapperApi;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _service = companyService;

            _mapperApi = mapper;
        }


        //api/companies/21
        [HttpGet("(id/companies/)")]
        public ActionResult<List<CompanyOutputModel>> GetCompanies()
        {
            var entity = _service.GetCompanies();

            var result = _mapperApi.Map<List<CompanyOutputModel>>(entity);

            return Ok(result);
        }

        //api/companies/2
        [HttpGet("{id}")]
        public ActionResult<CompanyOutputModel> GetCompanyById(int id)
        {
            var entity = _service.GetCompanyById(id);

            var result = _mapperApi.Map<CompanyOutputModel>(entity);

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
        public ActionResult<CompanyInsertInputModel> RegistrCompany([FromBody] CompanyInsertInputModel companyInsertInputModel)
        {

            CompanyModel entity = _mapperApi.Map<CompanyModel>(companyInsertInputModel);

            _service.RegistrCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);


        }
        //api/companies/
        [HttpPut("{id}")]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany([FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(companyUpdateInputModel);

            _service.UpdateCompany(model);

            return Ok(model);

        }
        [HttpPut("{id}/company/")]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany(int id, bool isDel)
        {
            _service.UpdateCompany(id, isDel);

            return NoContent();

        }
        //api/companies/2/ООО Восток./ True
        [HttpDelete("{id}/company/")]
        public ActionResult<CompanyUpdateInputModel> DeleteCompany(int id)
        {

            _service.DeleteCompany(id);

            return NoContent();
        }
    }
}
