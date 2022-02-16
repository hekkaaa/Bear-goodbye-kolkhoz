using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSourse;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        //[TestCaseSource(typeof(GetCompanyByIdTestCaseSource))]
        //public void GetCompanyByIdTest(Company company1, Company expected1)
        //{
        //    //given
        //    _context.Company.Add(company1);
        //    _context.SaveChanges();

        //    //when
        //    CompanyRepository _companyRepository = new CompanyRepository(_context);

        //    var actual1 = _companyRepository.GetCompanyById(company1.Id);

        //    //then
        //    Assert.AreEqual(expected1, actual1);
        //}


        //[TestCaseSource(typeof(GetCompaniesTestCaseSource))]
        //public void GetCompaniesTest(List<Company> companies, List<Company> expected)
        //{
        //    CompanyRepository companyRepository = new CompanyRepository(_context);
        //    //given
        //    _context.AddRange(companies);
        //    _context.SaveChanges();

        //    //when
        //    var actual = companyRepository.GetCompanies();

        //    //then
        //    Assert.AreEqual(expected, actual);
        //}


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
        public void DeleteCompanyTest(Company company1, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company1);
            _context.SaveChanges();

            //when
            companyRepository.DeleteCompany(company1.Id);
            var actual = _context.Company.FirstOrDefault(c => c.Id == company1.Id);

            //then
            Assert.AreEqual(expected, actual);


        }

        [TestCaseSource(typeof(UpdateCompanyTestCaseSource))]
        public void UpdateCompanyTest(Company company2, Company updateCompany2, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company2);
            _context.SaveChanges();

            //when
            companyRepository.UpdateCompany(updateCompany2);
            var actual = _context.Company.FirstOrDefault(c => c.Id == company2.Id);

            _context.SaveChanges();
            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
