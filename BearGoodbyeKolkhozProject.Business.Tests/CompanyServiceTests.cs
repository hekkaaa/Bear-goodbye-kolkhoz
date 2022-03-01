using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class CompanyServiceTests
    {
        private CompanyService _service;
        private ApplicationContext _context;
        private CompanyRepository _companyRepository;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;
            _context = new ApplicationContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _companyRepository = new CompanyRepository(_context);
            _service = new CompanyService(_companyRepository, mapper);

        }


        [Test]
        public void GetCompanyByIdTests()
        {
            //given
            var company = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false
            };

            _service.RegistrationCompany(company);
            //when

            var actual = _service.GetCompanyById(1);

            //then
            Assert.IsTrue(actual.Id == company.Id);
            Assert.IsNotNull(company);
            Assert.AreEqual(actual.Name, company.Name);
            Assert.AreEqual(actual.Email, company.Email);
            Assert.AreEqual(actual.PhoneNumber, company.PhoneNumber);
            Assert.AreEqual(actual.Tin, company.Tin);
            Assert.AreEqual(actual.Password, company.Password);
            Assert.AreEqual(actual.IsDeleted, company.IsDeleted);

        }

        [Test]
        public void UpdateCompanyTests()
        {
            //given
            var company = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false
            };

            _service.RegistrationCompany(company);

            var updateCompany = new CompanyModel
            {
                Id = 1,
                Name = "OOO Zara",
                PhoneNumber = "7654321",
                Tin = 1321234,
                IsDeleted = true
            };

            var expected = new CompanyModel
            {
                Id = 1,
                Name = "OOO Zara",
                PhoneNumber = "7654321",
                Tin = 1321234,
                IsDeleted = true
            };
            //when
            _service.UpdateCompany(updateCompany);

            var actual = _service.GetCompanyById(updateCompany.Id);
            //then
            Assert.IsTrue(actual.Id == expected.Id);
            Assert.IsNotNull(company);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.PhoneNumber, expected.PhoneNumber);
            Assert.AreEqual(actual.Tin, expected.Tin);

        }

        [Test]
        public void DeleteCompanyTest()
        {
            //given
            var company = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false
            };

            _service.RegistrationCompany(company);


            CompanyModel expected = null;


            //when
            _service.DeleteCompany(company.Id);

            var actual = _context.Company.FirstOrDefault(c => c.Id == company.Id); ;
            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateCompanyIsDelTest()
        {
            //given
            var company = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false
            };

            _service.RegistrationCompany(company);

            var updateCompany = new CompanyModel
            {
                Id = 1,
                IsDeleted = true
            };

            var expected = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = true
            };
            //when
            _service.UpdateCompany(updateCompany.Id, updateCompany.IsDeleted);

            var actual = _service.GetCompanyById(updateCompany.Id);
            //then
            Assert.IsTrue(actual.Id == expected.Id);
            Assert.IsNotNull(company);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.PhoneNumber, expected.PhoneNumber);
            Assert.AreEqual(actual.Tin, expected.Tin);
        }

        [Test]
        public void UpdatePasswordCompanyTest()
        {
            //given
            var company = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false
            };

            _service.RegistrationCompany(company);

            var upPass = new CompanyModel
            {
                Id = 1,
                Password = "8989qwe",
            };

            var expected = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "8989qwe",
                IsDeleted = true
            };
            //when
            _service.UpdatePasswordCompany(upPass.Id, upPass.Password);

            var actual = _service.GetCompanyById(company.Id);
            //then
            Assert.IsTrue(actual.Id == expected.Id);
            Assert.IsNotNull(company);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.PhoneNumber, expected.PhoneNumber);
            Assert.AreEqual(actual.Tin, expected.Tin);
        }

        [Test]
        public void GetCompaniesTest()
        {
            //given

            var company1 = new CompanyModel
            {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false
            };

            _service.RegistrationCompany(company1);


            var company2 = new CompanyModel
            {
                Id = 2,
                Name = "OOO Anna",
                Email = "rrr@mail",
                PhoneNumber = "123qwe7",
                Tin = 12334344,
                Password = "4321",
                IsDeleted = false
            };

            _service.RegistrationCompany(company2);

            var company3 = new CompanyModel
            {
                Id = 3,
                Name = "OOO Topor",
                Email = "rty@mail",
                PhoneNumber = "12346666",
                Tin = 12365767,
                Password = "78678768",
                IsDeleted = false
            };

            _service.RegistrationCompany(company3);

            List<CompanyModel> expected = new List<CompanyModel> { new CompanyModel {
                Id = 1,
                Name = "OOO Ivan",
                Email = "qwe@mail",
                PhoneNumber = "1234567",
                Tin = 123234,
                Password = "1234",
                IsDeleted = false}
            , new CompanyModel{
                Id = 2,
                Name = "OOO Anna",
                Email = "rrr@mail",
                PhoneNumber = "123qwe7",
                Tin = 12334344,
                Password = "4321",
                IsDeleted = false}

            , new CompanyModel {
                Id = 3,
                Name = "OOO Topor",
                Email = "rty@mail",
                PhoneNumber = "12346666",
                Tin = 12365767,
                Password = "78678768",
                IsDeleted = false}
            };


            //when
            var actual = _service.GetCompanies();

            //then

            Assert.IsTrue(expected.Count == actual.Count);
            Assert.IsNotNull(actual);

        }
    }
}
