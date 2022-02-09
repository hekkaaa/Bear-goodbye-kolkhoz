using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


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
            //when
            _context.Training.Add(training);
            _context.SaveChanges();

            var listBeforeDelete = _trainingRepository.GetTrainings();
            _trainingRepository.DeleteTraining(training.Id);
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
        }

        [Test]
        public void UpdateTrainingTests()
        {
            //given
            var oldTraining = _testData.GetTestTraining();
            

            //when
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

            _trainingRepository.UpdateTraining(newTraining);

            //then
            Assert.IsTrue(oldTraining.Name == "kokoko");
            Assert.IsTrue(oldTraining.Description == "chotko");
            Assert.IsTrue(oldTraining.Duration == 30);
            Assert.IsTrue(oldTraining.MembersCount == 30);
            Assert.IsTrue(oldTraining.IsDeleted == false);
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

            //when
            _context.Add(training);
            _context.SaveChanges();
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

            //when
            _context.Add(training);
            _context.SaveChanges();
            var act = _trainingRepository.GetTrainingsByTopic(topic);

            //then
            Assert.AreEqual(act[0], training);
        }
    }
}
