using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModel;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[conroller]")]
    public class CompaniesController : Controller
    {
        private readonly CompanyService _service;
        //api/Company/2
        [HttpGet("{id}")]
         //public ActionResult<CompanyOutputModel> GetCompanyById(int id) Не доделал
         //{
         //   var entity = _service.GetCompanyById(id);

         //   var result = CustomMapper.GetInstance().Map<CompanyOutputModel>(entity);

         //   return Ok(result);
         //}

         [HttpPost]
         public ActionResult<CompanyOutputModel> AddCompany(int id)
         {
            return StatusCode(StatusCodes.Status201Created, new CompanyModel());
         }
        
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            return NoContent();
        }
    }
}
