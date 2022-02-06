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

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Test]
        public void GetLecturerByIdTest()
        {
            //given
                var lecturer = new Lecturer
                {
                    Name = "Roma",
                    LastName = "Azarov",
                    Password = "qwe",
                    BirthDay = "12.12.1999",
                    Gender = Enums.Gender.Male,
                };

            _context.Lecturer.Add(lecturer);
            _context.SaveChanges();

            var expected = new Lecturer
            {
                Id = lecturer.Id,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
            };

            var repo = new LecturerRepository(_context);

            //when
            var actual = repo.GetLecturerById(lecturer.Id);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}