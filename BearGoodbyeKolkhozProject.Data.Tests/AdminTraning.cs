using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class AdminTraning
    {
        private ApplicationContext _context;
        private AdminRepository _adminRepository;
        private TestData _testData;

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Memory-DB")
               .Options;
            _context = new ApplicationContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _adminRepository = new AdminRepository(_context);
            _testData = new TestData();
        }


        [Test]
        public void GetAdminByIdTests()
        {
            //given
            var virtualData = _testData.GetTestAdmin();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            var act = _adminRepository.GetAdminById(virtualData.Id);

            //then
            Assert.IsTrue(virtualData.Id == act.Id);
            Assert.IsNotNull(virtualData);
            Assert.AreEqual(virtualData.LastName, act.LastName);
            Assert.AreEqual(virtualData.Gender, act.Gender);
            Assert.AreEqual(virtualData.BirthDay, act.BirthDay);
            Assert.AreEqual(virtualData.Email, act.Email);

        }

    }
}
