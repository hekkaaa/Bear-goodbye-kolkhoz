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
            var training = _testData.GetTestAdmin();
            _context.Add(training);
            _context.SaveChanges();

            //when
            var act = _adminRepository.GetAdminById(training.Id);

            //then
            Assert.IsTrue(training.Id == act.Id);
            Assert.IsNotNull(training);
            Assert.IsNotNull(act.LastName);
            Assert.IsNotNull(act.Gender);
            Assert.IsNotNull(act.BirthDay);
            Assert.IsNotNull(act.Email);

        }

    }
}
