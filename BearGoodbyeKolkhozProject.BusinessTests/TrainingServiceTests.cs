using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TrainingServiceTests
    {
        private TrainingService _service;
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

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessMapperProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();

            _trainingRepository = new TrainingRepository(_context);
            _service = new TrainingService(_trainingRepository, mapper);

            _testData = new TestData();

        }

        [Test]
        public void GetTrainingByIdTests()
        {
            //given
            //when
            var act = _service.GetTrainingModelById(2);
            //then
            Assert.IsTrue(act.Id == 2);
            Assert.IsTrue(act.Name == "Нетворк-скиллы");
            Assert.IsNotNull(act.Topics);
            Assert.IsNotNull(act.TrainingReviews);
        }

        [Test]
        public void GetTrainingByIdNegativeTests()
        {
            //given
            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.GetTrainingModelById(5));
        }

        [Test]
        public void GetTrainingsByTopicTests()
        {
            //given
            var topic = new TopicModel { Id = 666, Name = "Gop-stop" };
            var training = _testData.GetTrainingModel();
            training.Topics.Add(topic);
            _service.AddTraining(training);
            //when
            var act = _service.GetTrainingModelByTopic(topic);
            //then
            Assert.IsTrue(act.Count == 1);
            Assert.IsTrue(act[0].Name == training.Name);
            Assert.IsTrue(act[0].Description == training.Description);
        }

        [Test]
        public void GetTrainingByTopicNegativeTests()
        {
            //given
            var topicModel = _testData.GetTopicModel();

            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.GetTrainingModelByTopic(topicModel));
        }

        [Test]
        public void UpdateTrainingByIdTests()
        {
            //given
            var oldTraining = _testData.GetTrainingModel();
            _service.AddTraining(oldTraining);

            var newTraining = new TrainingModel
            {
                Id = oldTraining.Id,
                Name = "kokoko",
                Description = "chotko",
                Duration = 30,
                MembersCount = 30
            };
            //when
            _service.UpdateTraining(oldTraining.Id, newTraining);
            var act = _service.GetTrainingModelById(oldTraining.Id);
            //then
            Assert.IsTrue(act.Name == "kokoko");
            Assert.IsTrue(act.Description == "chotko");
            Assert.IsTrue(act.Duration == 30);
            Assert.IsTrue(act.MembersCount == 30);
            Assert.IsTrue(act.IsDeleted == false);
        }

        [Test]
        public void UpdateTrainingByIdNegativeTests()
        {
            //given
            var trainingModel = _testData.GetTrainingModel();
            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.UpdateTraining(5, trainingModel));
        }

        [Test]
        public void GetTrainingModelsTests()
        {
            //given
            //when
            var act = _service.GetTrainingModels();
            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Count == 3);
        }

        [Test]
        public void GetTrainingModelsNegativeTests()
        {
            //given
            var trainingModel1 = _testData.GetTrainingModel();
            trainingModel1.Id = 1;

            var trainingModel2 = _testData.GetTrainingModel();
            trainingModel2.Id = 2;

            var trainingModel3 = _testData.GetTrainingModel();
            trainingModel3.Id = 3;

            //when
            _service.DeleteTraining(trainingModel1);
            _service.DeleteTraining(trainingModel2);
            _service.DeleteTraining(trainingModel3);

            //then
            Assert.Throws<RepositoryException>(() => _service.GetTrainingModels());
        }

        [Test]
        public void TestToReturnUndeletedTrainings()
        {
            //given
            var training = _testData.GetTrainingModel();
            training.Id = 1;
            //when
            var listBeforeDelete = _service.GetTrainingModels();
            _service.DeleteTraining(training);
            var listAfterDelete = _service.GetTrainingModels();
            //then
            Assert.IsTrue(listBeforeDelete.Count - listAfterDelete.Count == 1);
        }

        [Test]
        public void DeleteTrainingNegativeTests()
        {
            //given
            var trainingModel = _testData.GetTrainingModel();
            trainingModel.Id = 6666;

            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.DeleteTraining(trainingModel));
        }

        [Test]
        public void DeleteAndRestoreTest()
        { 
            //given
            var training = _testData.GetTrainingModel();
            //when
            _service.AddTraining(training);
            _service.DeleteTraining(training);
            var traningBeforeRestore = _service.GetTrainingModelById(training.Id);
            _service.RestoreTraining(training);
            var trainingAfterRestore = _service.GetTrainingModelById(training.Id);
            //then
            Assert.IsTrue(traningBeforeRestore.IsDeleted);
            Assert.IsTrue(!trainingAfterRestore.IsDeleted);   
        }

        [Test]
        public void RestoreTrainingNegativeTests()
        {
            //given
            var trainingModel = _testData.GetTrainingModel();
            trainingModel.Id = 6666;

            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.RestoreTraining(trainingModel));
        }
    }
}
