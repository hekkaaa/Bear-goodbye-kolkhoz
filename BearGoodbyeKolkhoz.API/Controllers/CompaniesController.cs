using BearGoodbyeKolkhozProject.API.ConfigurationAPI;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModel;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _service;

        public CompaniesController(ICompanyService  companyService)
        {
            _service = companyService;
        }
            

        private CustomMapperApi _mapperApi = new CustomMapperApi();

        //api/companies/21
        [HttpGet("(id)")]
        public ActionResult<List<CompanyOutputModel>> GetCompanies()
        {
            var entity = _service.GetCompanies();

            var result = CustomMapperApi.GetInstance().Map<List<CompanyOutputModel>>(entity);
            
            return Ok(result);
        }

        //api/companies/2
        [HttpGet("{id}")]
        public ActionResult<CompanyOutputModel> GetCompanyById(int id)
        {
            var entity = _service.GetCompanyById(id);

            var result = CustomMapper.GetInstance().Map<CompanyOutputModel>(entity);

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
         public  ActionResult<CompanyInsertInputModel> AddCompany( [FromBody] CompanyInsertInputModel companyInsertInputModel)
         {

            CompanyModel entity = CustomMapperApi.GetInstance().Map<CompanyModel>(companyInsertInputModel);

            _service.AddCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);

            
         }
        //api/companies/
        [HttpPut]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany(int id, [FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel entity = CustomMapperApi.GetInstance().Map<CompanyModel>(companyUpdateInputModel);

            _service.UpdateCompany(id, entity);

            return Ok(entity);

        }
        //api/companies/2/ООО Восток./ True
        [HttpDelete("{id}/company/{isDelete}")]
        public ActionResult DeleteCompany(int id,[FromQuery] bool isDelete)
        {
            var entity = _service.GetCompanyById(id);

            _service.DeleteCompany(id, isDelete);
            
            return NoContent();
        }
    }
}
