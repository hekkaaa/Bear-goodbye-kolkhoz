﻿using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
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
        public void DeleteCompanyTest(Company company, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company);
            _context.SaveChanges();

            //when
            companyRepository.DeleteCompany(company.Id);
            var actual = _context.Company.FirstOrDefault(c => c.Id == company.Id);

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
            var actual = _context.Company.FirstOrDefault(c => c.Name == company.Name);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
