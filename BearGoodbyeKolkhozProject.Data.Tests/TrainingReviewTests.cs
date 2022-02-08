using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Text.Json;
using Moq;
using System.Linq;

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
        
        public TrainingReview GetTestDataWithClientTests() 
        {
            var trainingReview = new TrainingReview
            {
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
                Client = new Client
                {
                    Name = "Sacha",
                    LastName = "Vygrebyuk",
                    BirthDay = "22.07.2003",
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
            var trainingReview = GetTestData();

            //when
            _context.TrainingReview.Add(trainingReview);
            _context.SaveChanges();
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
            var trainingReview = GetTestData();

            //when
            _trainingReviewRepository.AddTrainingReview(trainingReview);
            var entity = _context.TrainingReview.FirstOrDefault(tr => tr.Id == trainingReview.Id);

            //then
            Assert.IsNotNull(entity);
        }

        [Test]
        public void UpdateTrainingReviewByIdTests()
        {
            //given
            var trainingReview = GetTestData();

            //when
            _context.Add(trainingReview);
            _context.SaveChanges();
            var updateTrainingReview = new TrainingReview
            {
                Id = 1,
                Mark = 5,
            };
            _trainingReviewRepository.UpdateTrainingReview(updateTrainingReview);

            //then
            Assert.IsTrue(trainingReview.Mark == 5);
            Assert.IsTrue(trainingReview.Text == null);
            Assert.IsTrue(trainingReview.Id == 1);
        }

        [Test]
        public void GetTrainingReviewsTests()
        {
            //given
            var a = GetTestData();
            var b = GetTestData(); 

            //when
            _context.TrainingReview.Add(a);
            _context.TrainingReview.Add(b);
            _context.SaveChanges();
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

            //when
            _context.TrainingReview.Add(trainingReview);
            _context.SaveChanges();
            var act = _trainingReviewRepository.GetTrainingReviewById(trainingReview.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Id == 1);
            Assert.IsTrue(act.Client.Name == "Sacha");
        }


        
    }
}