using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[conroller]")]
    public class CompanyController : Controller
    {       
        //api/Company/2
         [HttpGet("{id}")]
         public ActionResult<Company> GetCompanyById(int id)
         {
            return Ok();
         }

         [HttpPost]
         public ActionResult<Company> AddCompany(int id)
         {
            return StatusCode(StatusCodes.Status201Created, new Company());
         }
        
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            return NoContent();
        }
    }
}
