using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TrainingTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TrainingServiceTests
    {
        private IMapper _mapper;
        private TrainingService _service;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        }

        [TestCaseSource(typeof(GetTrainingByIdTestCaseSource))]
        public void GetTrainingByIdTests(Training entity, TrainingModel expected, int id)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            trainingRepository.Setup(t => t.GetTrainingById(id)).Returns(entity);
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            var act = _service.GetTrainingModelById(id);

            //then
            Assert.IsTrue(act.Id == expected.Id);
            Assert.IsTrue(act.Name == expected.Name);
            Assert.IsTrue(act.Description == expected.Description);
            Assert.IsTrue(act.Duration == expected.Duration);
            Assert.IsTrue(act.MembersCount == expected.MembersCount);
            Assert.IsTrue(act.Topics.Count == 1);
        }

        [TestCaseSource(typeof(GetTrainingByIdTestCaseSource))]
        public void GetTrainingByIdNegativeTests(Training entity, TrainingModel expected, int id)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            id = 1024;
            trainingRepository.Setup(t => t.GetTrainingById(id)).Returns(entity);
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.GetTrainingModelById(5));
        }

        [TestCaseSource(typeof(GetTrainingByTopicTestCaseSource))]
        public void GetTrainingsByTopicTests(List<Training> entity, TrainingModel expected, TopicModel topicModel, Topic topicEntity )
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            topicRepository.Setup(t => t.GetTopicById(topicEntity.Id)).Returns(topicEntity);
            trainingRepository.Setup(t => t.GetTrainingsByTopic(topicEntity)).Returns(entity);

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            var act = _service.GetTrainingModelByTopic(topicModel);

            //then
            Assert.IsTrue(act.Count == 2);
            Assert.IsTrue(act[0].Name == expected.Name);
            Assert.IsTrue(act[0].Description == expected.Description);
        }

        [TestCaseSource(typeof(GetTrainingByTopicTestCaseSource))]
        public void GetTrainingByTopicNegativeTests(List<Training> entity, TrainingModel expected, TopicModel topicModel, Topic topicEntity)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            topicRepository.Setup(t => t.GetTopicById(42)).Returns(topicEntity);
            trainingRepository.Setup(t => t.GetTrainingsByTopic(topicEntity)).Returns(entity);

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.GetTrainingModelByTopic(topicModel));
        }

        [TestCaseSource(typeof(UpdateTrainingByIdTestCaseSource))]
        public void UpdateTrainingByIdTests(Training training, TrainingModel trainingModel)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainingById(training.Id)).Returns(training);
            trainingRepository.Setup(t => t.UpdateTraining(It.IsAny<Training>()));

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            _service.UpdateTraining(training.Id, trainingModel);

            //then
            trainingRepository.Verify(tr => tr.UpdateTraining(It.IsAny<Training>()), Times.Once);
        }

        //[Test]
        //public void UpdateTrainingByIdNegativeTests()
        //{
        //    //given
        //    var trainingModel = _testData.GetTrainingModel();
        //    //when
        //    //then
        //    Assert.Throws<RepositoryException>(() => _service.UpdateTraining(5, trainingModel));
        //}

        //[Test]
        //public void GetTrainingModelsTests()
        //{
        //    //given
        //    //when
        //    var act = _service.GetTrainingModels();
        //    //then
        //    Assert.IsNotNull(act);
        //    Assert.IsTrue(act.Count == 3);
        //}

        //[Test]
        //public void GetTrainingModelsNegativeTests()
        //{
        //    //given
        //    var trainingModel1 = _testData.GetTrainingModel();
        //    trainingModel1.Id = 1;

        //    var trainingModel2 = _testData.GetTrainingModel();
        //    trainingModel2.Id = 2;

        //    var trainingModel3 = _testData.GetTrainingModel();
        //    trainingModel3.Id = 3;

        //    //when
        //    _service.DeleteTraining(trainingModel1);
        //    _service.DeleteTraining(trainingModel2);
        //    _service.DeleteTraining(trainingModel3);

        //    //then
        //    Assert.Throws<RepositoryException>(() => _service.GetTrainingModels());
        //}

        //[Test]
        //public void TestToReturnUndeletedTrainings()
        //{
        //    //given
        //    var training = _testData.GetTrainingModel();
        //    training.Id = 1;
        //    //when
        //    var listBeforeDelete = _service.GetTrainingModels();
        //    _service.DeleteTraining(training);
        //    var listAfterDelete = _service.GetTrainingModels();
        //    //then
        //    Assert.IsTrue(listBeforeDelete.Count - listAfterDelete.Count == 1);
        //}

        //[Test]
        //public void DeleteTrainingNegativeTests()
        //{
        //    //given
        //    var trainingModel = _testData.GetTrainingModel();
        //    trainingModel.Id = 6666;

        //    //when
        //    //then
        //    Assert.Throws<RepositoryException>(() => _service.DeleteTraining(trainingModel));
        //}

        //[Test]
        //public void DeleteAndRestoreTest()
        //{
        //    //given
        //    var training = _testData.GetTrainingModel();
        //    //when
        //    _service.AddTraining(training);
        //    _service.DeleteTraining(training);
        //    var traningBeforeRestore = _service.GetTrainingModelById(training.Id);
        //    _service.RestoreTraining(training);
        //    var trainingAfterRestore = _service.GetTrainingModelById(training.Id);
        //    //then
        //    Assert.IsTrue(traningBeforeRestore.IsDeleted);
        //    Assert.IsTrue(!trainingAfterRestore.IsDeleted);
        //}

        //[Test]
        //public void RestoreTrainingNegativeTests()
        //{
        //    //given
        //    var trainingModel = _testData.GetTrainingModel();
        //    trainingModel.Id = 6666;

        //    //when
        //    //then
        //    Assert.Throws<RepositoryException>(() => _service.RestoreTraining(trainingModel));
        //}
    }
}
