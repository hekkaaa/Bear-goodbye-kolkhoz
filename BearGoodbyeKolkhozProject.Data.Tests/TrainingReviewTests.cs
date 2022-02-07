using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Text.Json;
using Moq;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class TrainingReviewTests
    {

        private ApplicationContext _context;
        private TrainingReviewRepository _trainingReviewRepository;
        private TrainingRepository _trainingRepository;

        private readonly Mock<ITrainingReviewRepository> _mock;


        public TrainingReviewTests()
        {
            _mock = new Mock<ITrainingReviewRepository>();

        }

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Memory-DB")
               .Options;

            _context = new ApplicationContext(options);

            _context.Database.EnsureDeleted();

            _context.Database.EnsureCreated();

            _trainingRepository = new TrainingRepository();
            _trainingReviewRepository = new TrainingReviewRepository(_context);

        }

        public TrainingReview GetTestData() { 
        
            var trainingReview = new TrainingReview
            {
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
            };

            return trainingReview;
        }

        [Test]
        public void DeleteTrainingReviewById()
        {
            var trainingReview = GetTestData();

            _context.TrainingReview.Add(trainingReview);

            _context.SaveChanges();

            var listBeforeDelete = _trainingReviewRepository.GetTrainingReviews();

            _trainingReviewRepository.DeleteTrainingReview(trainingReview.Id);

            var listAfterDelete = _trainingReviewRepository.GetTrainingReviews();

            Assert.IsTrue(listBeforeDelete.Count > listAfterDelete.Count);

            
        }


        [Test]
        public void AddTrainingReview()
        {
            var trainingReview = GetTestData();

            _trainingReviewRepository.AddTrainingReview(trainingReview);

            var testEntity = _trainingReviewRepository.GetTrainingReviewById(trainingReview.Id);

            var testList = _trainingReviewRepository.GetTrainingReviews();

            Assert.IsNotNull(testEntity);
            Assert.IsTrue(testList.Count > 0);
        }

        [Test]
        public void UpdateTrainingReviewById()
        {


            var trainingReview = GetTestData();
            _context.Add(trainingReview);
            _context.SaveChanges();

            var updateTrainingReview = new TrainingReview
            {
                Id = 1,
                Mark = 5,
            };

            _trainingReviewRepository.UpdateTrainingReview(updateTrainingReview);

            Assert.IsTrue(trainingReview.Mark == 5);
            
        }


        [Test]
        public void GetTrainingReviews()
        {

            var a = GetTestData();

            var b = GetTestData(); 

            _context.TrainingReview.Add(a);
            _context.TrainingReview.Add(b);
            _context.SaveChanges();

            var act = _trainingReviewRepository.GetTrainingReviews();

            Assert.IsNotNull(act);
            Assert.IsTrue(act.Count > 0);

        }


        [Test]
        public void GetTrainingReviewById()
        {
            var trainingReview = GetTestData();

            _context.TrainingReview.Add(trainingReview);
            _context.SaveChanges();

            var expected = new TrainingReview
            {
                Id = 1,
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
            };



            var actual = _trainingReviewRepository.GetTrainingReviewById(trainingReview.Id);

            var actualSerilize = JsonSerializer.Serialize(actual);
            var expectedSerilize = JsonSerializer.Serialize(expected);


            Assert.AreEqual(expectedSerilize, actualSerilize);
        }
    }
}