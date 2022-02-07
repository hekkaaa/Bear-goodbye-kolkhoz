using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        [Test]
        public void AddTrainingReviewById()
        {
            var trainingReview = new TrainingReview
            {
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
            };

            _mock.Setup(m => m.AddTrainingReview(It.IsAny<TrainingReview>()));

            Assert.AreSame(expected, act);
        }
        
        public void DeleteTrainingReviewById()
        {
            var trainingReview = new TrainingReview
            {
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
            };

            _context.TrainingReview.Add(trainingReview);
            _context.SaveChanges();

            Assert.AreSame(expected, act);
        }
         public void UpdateTrainingReviewById()
        {
            

            Assert.AreSame(expected, act);
        }
        
        public void GetTrainingReviews()
        {
            

            Assert.AreSame(expected, act);
        }


        [Test]
        public void GetTrainingReviewById()
        {
            var trainingReview = new TrainingReview
            {
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
            };

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