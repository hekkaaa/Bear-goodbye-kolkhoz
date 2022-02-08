using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class CompanyRepositoryTests
    {
        private ApplicationContext _context;

        private CompanyRepository _companyRepository;
        

        private readonly Mock<ICompanyRepository> _mock;

        public CompanyRepositoryTests()
        {
            _mock = new Mock<ICompanyRepository>();

        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _context = new ApplicationContext(options);

            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _companyRepository = new CompanyRepository(_context);
        }

        [Test]
        public void AddCompanyTest()
        {
            //given 
            var company = new Company
            {
                Name = "ООО Трико",
                Email = "Trico@mail.ru",
                Tin = 881672145,
                Password = "12345",
                PhoneNumber = "89650436534"

            };
       

            var repo = new CompanyRepository(_context);
            //when 
            repo.AddCompany(company);
            //then
            var com = _context.Company;
        }

        [Test]
        public void GetCompaniesTest()
        {
            //given 
            List<Company> expected = new List<Company> { new Company {

                Name = "ООО Трико",
                Email = "Trico@mail.ru",
                Tin = 881672145,
                Password = "12345",
                PhoneNumber = "89650436534"}
            , new Company{
                Name = "ООО Nica",
                Email = "Nicao@gmail.com",
                Tin = 88000000,
                Password = "qwe",
                PhoneNumber = "+79650436534"}
            };


            var repo = new CompanyRepository(_context);

            //when 
            var actual = repo.GetCompanies();

            //then 
            CollectionAssert.AreEqual(expected, actual);






        }


    }
}