using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

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

        [Test]
        public void GetLecturersTest()
        {
            //given
            var fLecturer = new Lecturer
            {
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
            };
            var sLecturer = new Lecturer
            {
                Name = "Slava",
                LastName = "Azarov",
                Password = "asd",
                BirthDay = "12.12.2004",
                Gender = Enums.Gender.Male
            };
            var tLecturer = new Lecturer
            {
                Name = "qwe",
                LastName = "asd",
                Password = "123",
                BirthDay = "11.22.1234",
                Gender = Enums.Gender.Other
            };

            _context.Lecturer.Add(fLecturer);
            _context.Lecturer.Add(sLecturer);
            _context.Lecturer.Add(tLecturer);

            _context.SaveChanges();

            List<Lecturer> expected = new List<Lecturer> { new Lecturer {
                Id = fLecturer.Id,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male}
            , new Lecturer {
                Id = sLecturer.Id,
                Name = "Slava",
                LastName = "Azarov",
                Password = "asd",
                BirthDay = "12.12.2004",
                Gender = Enums.Gender.Male}
            , new Lecturer {
                Id = tLecturer.Id,
                Name = "qwe",
                LastName = "asd",
                Password = "123",
                BirthDay = "11.22.1234",
                Gender = Enums.Gender.Other}};

            var repo = new LecturerRepository(_context);

            //when
            var actual = repo.GetLecturers();

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void AddLecturerTest()
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

            var repo = new LecturerRepository(_context);

            //when
            repo.AddLecturer(lecturer);

            //then
            var a = _context.Lecturer;
        }
    }
}