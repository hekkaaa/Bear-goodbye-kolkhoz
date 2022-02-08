using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using BearGoodbyeKolkhozProject.Data.Tests.Mock;
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

            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            
        }



        [TestCaseSource(typeof(AddCompaniesTestCaseSource))]
        public void AddCompanyTest(Company expected )
        {
            MockCompany mockCompany = new MockCompany();

            //given
            Mock<ICompanyRepository> mock = new Mock<ICompanyRepository>();
            mock.Setup((obj) => obj.AddCompany(expected));
            CompanyRepository _companyRepository = new CompanyRepository(_context);

            //when
            _companyRepository.AddCompany(expected);
            var actual = _context.Company.FirstOrDefault(c => c.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        public class AddCompaniesTestCaseSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var company = new Company
                {
                    Id = 1,
                    Name = "OOO Ivan",
                    Email = "Test1@mail.ru",
                    PhoneNumber = "123456789",
                    Tin = 123234,
                    Password = "1234"

                };

                yield return new object[] { company };
            }
        }
       


    }
}