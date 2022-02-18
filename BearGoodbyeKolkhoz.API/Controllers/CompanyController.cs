using AutoMapper;
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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _serviceCom;

        private IContactLecturerService _serviceLec;

        private IMapper _mapperApi;

        public CompanyController(ICompanyService companyService, IContactLecturerService contactLecturerService, IMapper mapper)
        {
            _serviceCom = companyService;

            _serviceLec = contactLecturerService;

            _mapperApi = mapper;
        }


        //api/companies/21
        [HttpGet("(id/companies/)")]
        public ActionResult<List<CompanyOutputModel>> GetCompanies()
        {
            var entity = _serviceCom.GetCompanies();

            var result = _mapperApi.Map<List<CompanyOutputModel>>(entity);

            return Ok(result);
        }

        //api/companies/2
        [HttpGet("{id}")]
        public ActionResult<CompanyOutputModel> GetCompanyById(int id)
        {
            var entity = _serviceCom.GetCompanyById(id);

            var result = _mapperApi.Map<CompanyOutputModel>(entity);

            return Ok(result);
        }

        //api/companies/
        [HttpPost()]
        public ActionResult<CompanyInsertInputModel> RegistrCompany([FromBody] CompanyInsertInputModel companyInsertInputModel)
        {

            CompanyModel entity = _mapperApi.Map<CompanyModel>(companyInsertInputModel);

            _serviceCom.RegistrCompany(entity);

            return StatusCode(StatusCodes.Status201Created, entity);


        }
        //api/companies/
        [HttpPut("{id}")]
        public ActionResult<CompanyUpdateInputModel> UpdateCompany([FromBody] CompanyUpdateInputModel companyUpdateInputModel)
        {
            CompanyModel model = _mapperApi.Map<CompanyModel>(companyUpdateInputModel);

            _serviceCom.UpdateCompany(model);

            return Ok(model);

        }
        [HttpPut("{id}/company/")]
        public ActionResult<CompanyOutputModel> UpdateCompany(int id, bool isDel)
        {
            _serviceCom.UpdateCompany(id, isDel);

            return NoContent();

        }
        //api/companies/2/ООО Восток./ True
        [HttpDelete("{id}/company/")]
        public ActionResult<CompanyUpdateInputModel> DeleteCompany(int id)
        {

            _serviceCom.DeleteCompany(id);

            return NoContent();
        }

        //api/contactlecturer/
        [HttpPost("{LecturerId}")]
        public ActionResult<ContactLecturerInsertInputModel> AddValue([FromBody] ContactLecturerInsertInputModel contactLecturerInsertInputModel)
        {
            

            ContactLecturerModel entity = _mapperApi.Map<ContactLecturerModel>(contactLecturerInsertInputModel);

            _serviceLec.AddValue(entity);

            return StatusCode(StatusCodes.Status201Created, entity);


        }
    }
}
