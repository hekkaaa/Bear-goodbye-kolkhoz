﻿using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/[conroller]")]
    public class CompanyController : Controller
    {       
        
         [HttpGet("{id}")]
         public ActionResult GetCompanyById(int id)
         {
            return NoContent();
         }

         [HttpPost]
         public ActionResult AddCompany()
         {
            return NoContent();
        }
        
    }
}
