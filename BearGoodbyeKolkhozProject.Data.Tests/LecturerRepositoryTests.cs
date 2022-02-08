using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource;
using System.Linq;

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

        [TestCaseSource(typeof(GetLecturerByIdTestCaseSource))]
        public void GetLecturerByIdTest(Lecturer lecturer, Lecturer expected)
        {
            //given
            _context.Lecturer.Add(lecturer);
            _context.SaveChanges();

            //when
            Mock<ILecturerRepository> mock = new Mock<ILecturerRepository>();
            mock.Setup((obj) => obj.GetLecturerById(lecturer.Id)).Returns(expected);
            LecturerRepository lecturerRepository = new LecturerRepository(_context);

            var actual = lecturerRepository.GetLecturerById(lecturer.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetLecturersTestCaseSource))]
        public void GetLecturersTest(List<Lecturer> lecturers, List<Lecturer> expected)
        {
            //given
            _context.AddRange(lecturers);
            _context.SaveChanges();

            //when
            Mock<ILecturerRepository> mock = new Mock<ILecturerRepository>();
            mock.Setup((obj) => obj.GetLecturers()).Returns(expected);
            LecturerRepository lecturerRepository = new LecturerRepository(_context);
            
            var actual = lecturerRepository.GetLecturers();

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(AddLecturerTestCaseSource))]
        public void AddLecturerTest(Lecturer expected)
        {
            //given
            Mock<ILecturerRepository> mock = new Mock<ILecturerRepository>();
            mock.Setup((obj) => obj.AddLecturer(expected));
            LecturerRepository lecturerRepository = new LecturerRepository(_context);

            //when
            lecturerRepository.AddLecturer(expected);
            var actual = _context.Lecturer.FirstOrDefault(l => l.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}