using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TrainingReviewTestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class TrainingReviewTests
    {
        private ApplicationContext _context;
        private TrainingReviewRepository _trainingReviewRepository;
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
            _trainingReviewRepository = new TrainingReviewRepository(_context);
            _testData = new TestData();
        }

        public TrainingReview GetTestData()
        {

            var trainingReview = new TrainingReview
            {
                Text = "??????? ?????!!! ??? ?????????????? ?????? ????? ???????!!! ?????? ????? ?????)))",
                Mark = 10,
            };
            return trainingReview;
        }

        public TrainingReview GetTestDataWithClientTests()
        {
            var trainingReview = new TrainingReview
            {
                Text = "??????? ?????!!! ??? ?????????????? ?????? ????? ???????!!! ?????? ????? ?????)))",
                Mark = 10,
                Client = new Client
                {
                    Name = "Sacha",
                    LastName = "Vygrebyuk",
                    BirthDay = new DateTime(2003, 07, 22),
                    Email = "jjj@jjj.jjj",
                    Password = "********",
                    Gender = Enums.Gender.Male,
                    PhoneNumber = "999999999",
                }
            };

            return trainingReview;
        }

        [Test]
        public void DeleteTrainingReviewByIdTests()
        {
            //given
            var trainingReview = _testData.GetTestTrainingReview();
            _context.TrainingReview.Add(trainingReview);
            _context.SaveChanges();

            //when
            var listBeforeDelete = _trainingReviewRepository.GetTrainingReviews();
            _trainingReviewRepository.DeleteTrainingReview(trainingReview.Id);
            var listAfterDelete = _trainingReviewRepository.GetTrainingReviews();

            //then
            Assert.IsTrue((listBeforeDelete.Count - listAfterDelete.Count) == 1);
        }


        [Test]
        public void AddTrainingReviewTests()
        {
            //given
            var trainingReview = _testData.GetTestTrainingReview();

            //when
            _trainingReviewRepository.AddTrainingReview(trainingReview);
            var entity = _context.TrainingReview.FirstOrDefault(tr => tr.Id == trainingReview.Id);

            //then
            Assert.IsNotNull(entity);
            Assert.IsTrue(trainingReview.Mark == entity.Mark);
            Assert.IsTrue(trainingReview.Text == entity.Text);
        }

        [Test]
        public void UpdateTrainingReviewByIdTests()
        {
            //given
            var trainingReview = _testData.GetTestTrainingReview();
            _context.Add(trainingReview);
            _context.SaveChanges();

            //when
            var updateTrainingReview = new TrainingReview
            {
                Id = 1,
                Mark = 5,
            };
            _trainingReviewRepository.UpdateTrainingReview(updateTrainingReview);

            var trainingReviewAfterUpdate = _context.TrainingReview.FirstOrDefault(tr => tr.Id == trainingReview.Id);

            //then
            Assert.IsTrue(trainingReviewAfterUpdate.Mark == 5);
            Assert.IsTrue(trainingReviewAfterUpdate.Text == null);
        }

        [Test]
        public void GetTrainingReviewsTests()
        {
            //given
            var a = _testData.GetTestTrainingReview();
            var b = _testData.GetTestTrainingReview();
            _context.TrainingReview.Add(a);
            _context.TrainingReview.Add(b);
            _context.SaveChanges();

            //when
            var act = _trainingReviewRepository.GetTrainingReviews();

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Count == 2);
        }

        [Test]
        public void GetTrainingReviewByIdTests()
        {
            //given
            var trainingReview = GetTestDataWithClientTests();
            _context.TrainingReview.Add(trainingReview);
            _context.SaveChanges();

            //when
            var act = _trainingReviewRepository.GetTrainingReviewById(trainingReview.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Id == 1);
            Assert.IsNotNull(act.Client);
        }


        [TestCaseSource(typeof(GetReviewByTrainingIdTestCaseSource))]
        public void GetReviewByTrainingId(int trainingId, List<TrainingReview> reviews, List<TrainingReview> expected)
        {
            //given
            _context.TrainingReview.AddRange(reviews);
            _context.SaveChanges();

            //when
            var actual = _trainingReviewRepository.GetReviewByTrainingId(trainingId);

            //then
            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}