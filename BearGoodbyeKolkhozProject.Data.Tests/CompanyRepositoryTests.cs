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


        [TestCaseSource(typeof(GetCompanyByIdTestCaseSource))]
        public void GetCompanyByIdTest(Company company, Company expected)
        {
            //given
            _context.Company.Add(company);

            //when
            CompanyRepository _companyRepository = new CompanyRepository(_context);

            var actual = _companyRepository.GetCompanyById(company.Id);

            //then
           
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.Tin, actual.Tin);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }


        [TestCaseSource(typeof(GetCompaniesTestCaseSource))]
        public void GetCompaniesTest(List<Company> companies, List<Company> expected)
        {
            CompanyRepository companyRepository = new CompanyRepository(_context);
            //given
            _context.AddRange(companies);
            _context.SaveChanges();

            //when
            var actual = companyRepository.GetCompanies();

            //then

            Assert.IsTrue(expected.Count == actual.Count);
            Assert.IsNotNull(expected);
        }


        [TestCaseSource(typeof(RegistrCompaniesTestCaseSource))]
        public void RegistrCompanyTest(Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(expected);
            //when
            companyRepository.RegistrationCompany(expected);
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
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.Tin, actual.Tin);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);


        }

        [TestCaseSource(typeof(UpdateCompanyTestCaseSourceTwo))]
        public void UpdateCompanyTestTwo(Company company, Company updateCompany, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company);
            _context.SaveChanges();

            //when
            companyRepository.UpdateCompany(updateCompany.Id, updateCompany.IsDeleted);
            var actual = _context.Company.FirstOrDefault(c => c.Id == company.Id);

            _context.SaveChanges();
            //then
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.Tin, actual.Tin);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);


        }

        [TestCaseSource(typeof(ChangePasswordCompanyTestCaseSource))]

        public void ChangePasswordCompanyTest(Company company, string Password, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company);
            _context.SaveChanges();

            //when
            companyRepository.ChangePasswordCompany(Password, company);
            var actual = _context.Company.FirstOrDefault(c => c.Id == company.Id);
            _context.SaveChanges();


            //then
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.Tin, actual.Tin);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }

        [TestCaseSource(typeof(LoginTestCaseSource))]

        public void LodinTest(Company company, string login, Company expected)
        {
            //given
            CompanyRepository companyRepository = new CompanyRepository(_context);
            _context.Company.Add(company);
            _context.SaveChanges();

            //when

            companyRepository.Login(login);
            var actual = _context.Company.FirstOrDefault(c => c.Email == company.Email);
            _context.SaveChanges();

            //then

            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.Tin, actual.Tin);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);


        }
    }
}
