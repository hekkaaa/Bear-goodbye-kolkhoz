using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class LecturerRepositoryTests
    {
        private ApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            _context = new ApplicationContext(options);
        }

        [Test]
        public void GetLecturersTest()
        {
            //given
            _context.Lecturer.Add(
                new Lecturer
                {
                    Name = "Roma",
                    LastName = "Azarov"

                });
            var repo = new LecturerRepository(_context);
        }
    }
}