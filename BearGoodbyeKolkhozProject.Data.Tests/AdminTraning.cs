using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class AdminTraning
    {
        [SetUp]
        public void Setup()
        {

            //var options = new DbContextOptionsBuilder<ApplicationContext>()
            //   .UseInMemoryDatabase(databaseName: "Memory-DB")
            //   .Options;
            //_context = new ApplicationContext(options);
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();
            //_trainingRepository = new TrainingRepository(_context);
            //_testData = new TestData();
        }


        [Test]
        public void GetAdminByIdTests()
        {

            Assert.AreEqual(1, 2);

        }

    }
}
