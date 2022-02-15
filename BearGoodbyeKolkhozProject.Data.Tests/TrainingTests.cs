using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;


namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class TrainingTests
    {


        private ApplicationContext _context;
        private TrainingRepository _trainingRepository;
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
            _trainingRepository = new TrainingRepository(_context);
            _testData = new TestData();
        }

        [Test]
        public void DeleteTrainingTests()
        {
            //given
            var training = _testData.GetTestTraining();
            _context.Training.Add(training);
            _context.SaveChanges();

            //when
            var listBeforeDelete = _trainingRepository.GetTrainings();
            _trainingRepository.UpdateTraining(training, true);
            var listAfterDelete = _trainingRepository.GetTrainings();

            //then 
            Assert.IsTrue(listBeforeDelete.Count - listAfterDelete.Count == 1);
            Assert.IsTrue(training.IsDeleted);
        }
        
        [Test]
        public void AddTrainingTests()
        {
            //given
            var training = _testData.GetTestTraining();

            //when
            _trainingRepository.AddTraining(training);
            var entity = _context.Training.FirstOrDefault(t => t.Id == training.Id);

            //then
            Assert.IsNotNull(entity);
            Assert.IsTrue(training.Name == entity.Name);
            Assert.IsTrue(training.Price == entity.Price);
            Assert.IsTrue(training.IsDeleted == entity.IsDeleted);
        }

        [Test]
        public void UpdateTrainingTests()
        {
            //given
            var oldTraining = _testData.GetTestTraining();
            _context.Add(oldTraining);
            _context.SaveChanges();
            var newTraining = new Training
            {
                Id = oldTraining.Id,
                Name = "kokoko",
                Description = "chotko",
                Duration = 30,
                MembersCount = 30
            };

            //when
            _trainingRepository.UpdateTraining(newTraining);
            var trainingAfterUpdate = _context.Training.FirstOrDefault(tr => tr.Id == oldTraining.Id);


            //then
            Assert.IsTrue(trainingAfterUpdate.Name == "kokoko");
            Assert.IsTrue(trainingAfterUpdate.Description == "chotko");
            Assert.IsTrue(trainingAfterUpdate.Duration == 30);
            Assert.IsTrue(trainingAfterUpdate.MembersCount == 30);
            Assert.IsTrue(trainingAfterUpdate.IsDeleted == false);
        }

        [Test]
        public void GetTrainingsTests()
        {
            //given

            //when
            var act = _trainingRepository.GetTrainings();

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Count == 3);
        }

        [Test]
        public void GetTrainingByIdTests()
        {
            //given
            var training = _testData.GetTestTraining();
            _context.Add(training);
            _context.SaveChanges();

            //when
            var act = _trainingRepository.GetTrainingById(training.Id);

            //then
            Assert.IsTrue(training.Id == act.Id);
            Assert.IsNotNull(training.Topics);
            Assert.IsNotNull(training.TrainingReviews);
        }

        [Test]
        public void GetTrainingByTopicTests()
        {   //given
            var training = _testData.GetTestTraining();
            var topic = _testData.GetTestTopic();
            _context.Add(training);
            _context.SaveChanges();

            //when
            var act = _trainingRepository.GetTrainingsByTopic(topic);

            //then
            Assert.AreEqual(act[0], training);
        }
    }
}
