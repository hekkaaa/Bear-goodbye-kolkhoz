using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TrainingTests
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
        public void GetTrainingByIdNegativeTests()
        {
            //given
            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.GetTrainingModelById(5));
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
        public void UpdateTrainingByIdNegativeTests()
        {
            //given
            var trainingModel = _testData.GetTrainingModel();
            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.UpdateTraining(5, trainingModel));
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
        public void RecoveryTrainingNegativeTests()
        {
            //given
            var trainingModel = _testData.GetTrainingModel();
            trainingModel.Id = 6666;

            //when
            //then
            Assert.Throws<RepositoryException>(() => _service.RecoveryTraining(trainingModel));
        }
    }
}
