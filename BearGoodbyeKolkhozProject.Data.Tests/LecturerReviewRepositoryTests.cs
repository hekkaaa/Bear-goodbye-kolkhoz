using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerReviewTestCaseSource;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class LecturerReviewRepositoryTests
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

        [TestCaseSource(typeof(GetLecturerReviewByIdTestCaseSource))]
        public void GetLecturerReviewByIdTest(LecturerReview lecturerReview, LecturerReview expected, int expectedId)
        {
            //given
            _context.LecturerReview.Add(lecturerReview);
            _context.SaveChanges();

            //when
            LecturerReviewRepository lecturerReviewRepository = new LecturerReviewRepository(_context);
            var actual = lecturerReviewRepository.GetLecturerReviewById(expectedId);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetLecturerReviewsByLecturerIdTestCaseSource))]
        public void GetLecturerReviewsByLecturerIdTest(List<LecturerReview> rewiews, List<LecturerReview> expected, int expectedId)
        {
            //given
            _context.LecturerReview.AddRange(rewiews);
            _context.SaveChanges();

            //when
            LecturerReviewRepository lecturerReviewRepository = new LecturerReviewRepository(_context);
            var actual = lecturerReviewRepository.GetLecturerReviewsByLecturerId(expectedId);

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(AddLecturerReviewTestCaseSource))]
        public void AddLecturerReviewTest(LecturerReview review, LecturerReview expected)
        {
            //given

            //when
            LecturerReviewRepository lecturerReviewRepository = new LecturerReviewRepository(_context);
            lecturerReviewRepository.AddLecturerReview(review);

            //then
            var actual = _context.LecturerReview.FirstOrDefault(Lr => Lr.Id == review.Id);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DeleteLecturerReviewByIdTestCaseSource))]
        public void DeleteLecturerReviewByIdTest(LecturerReview review)
        {
            //given
            _context.LecturerReview.Add(review);
            _context.SaveChanges();

            //when
            LecturerReviewRepository lecturerReviewRepository = new LecturerReviewRepository(_context);
            lecturerReviewRepository.ChangeIsDeleted(review, true);

            //then
            var actual = _context.LecturerReview.FirstOrDefault(Lr => Lr.Id == review.Id);
            Assert.AreEqual(actual, null);
        }
    }
}
