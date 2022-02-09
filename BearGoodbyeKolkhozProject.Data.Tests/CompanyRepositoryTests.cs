using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using BearGoodbyeKolkhozProject.Data.Tests.TestCase;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class CompanyRepositoryTests
    {
        private ApplicationContext _context;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _context = new ApplicationContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

        }



        [TestCaseSource(typeof(RegistrCompaniesTestCaseSource))]
        public void RegistrCompanyTest(Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(expected);
            //when
            companyRepository.RegistrCompany(expected);
            var actual = _context.Company.FirstOrDefault(c => c.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DeleteCompanyTestCaseSource))]
        public void DeleteCompanyTest(Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(expected);         

            //when
            companyRepository.DeleteCompany(expected);
            var actual = _context.Company.FirstOrDefault(c => c.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);


        }

        [TestCaseSource(typeof(UpdateCompanyTestCaseSource))]
        public void UpdateCompany(Company company, Company updateCompany, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company);
            _context.SaveChanges();
           
            //when
            companyRepository.UpdateCompany(updateCompany);
            var actual = _context.Company.FirstOrDefault(c => c.Id == company.Id);

            //then
            Assert.AreEqual(expected, actual);
        }
     
        
            





        
    }
}