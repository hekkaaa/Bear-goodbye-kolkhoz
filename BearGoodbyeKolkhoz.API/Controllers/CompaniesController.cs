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

            var result = CustomMapperApi.GetInstance().Map<CompanyOutputModel>(entity);

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
         public  ActionResult<CompanyInsertInputModel> RegistrCompany( [FromBody] CompanyInsertInputModel companyInsertInputModel)
         {

            CompanyModel entity = CustomMapperApi.GetInstance().Map<CompanyModel>(companyInsertInputModel);

            _service.RegistrCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);

            
         }
        //api/companies/
        [HttpPut]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany([FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel model = CustomMapperApi.GetInstance().Map<CompanyModel>(companyUpdateInputModel);

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
