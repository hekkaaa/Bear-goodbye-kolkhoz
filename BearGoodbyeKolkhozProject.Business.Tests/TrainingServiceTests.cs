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

        //[Test]
        //public void GetTrainingByIdNegativeTests()
        //{
        //    //given
        //    //when
        //    //then
        //    Assert.Throws<RepositoryException>(() => _service.GetTrainingModelById(5));
        //}

        //[Test]
        //public void GetTrainingsByTopicTests()
        //{
        //    //given
        //    var topic = new TopicModel { Id = 666, Name = "Gop-stop" };
        //    var training = _testData.GetTrainingModel();
        //    training.Topics.Add(topic);
        //    _service.AddTraining(training);
        //    //when
        //    var act = _service.GetTrainingModelByTopic(topic);
        //    //then
        //    Assert.IsTrue(act.Count == 1);
        //    Assert.IsTrue(act[0].Name == training.Name);
        //    Assert.IsTrue(act[0].Description == training.Description);
        //}

        //[Test]
        //public void GetTrainingByTopicNegativeTests()
        //{
        //    //given
        //    var topicModel = _testData.GetTopicModel();

        //    //when
        //    //then
        //    Assert.Throws<RepositoryException>(() => _service.GetTrainingModelByTopic(topicModel));
        //}

        //[Test]
        //public void UpdateTrainingByIdTests()
        //{
        //    //given
        //    var oldTraining = _testData.GetTrainingModel();
        //    _service.AddTraining(oldTraining);

        //    var newTraining = new TrainingModel
        //    {
        //        Id = oldTraining.Id,
        //        Name = "kokoko",
        //        Description = "chotko",
        //        Duration = 30,
        //        MembersCount = 30
        //    };
        //    //when
        //    _service.UpdateTraining(oldTraining.Id, newTraining);
        //    var act = _service.GetTrainingModelById(oldTraining.Id);
        //    //then
        //    Assert.IsTrue(act.Name == "kokoko");
        //    Assert.IsTrue(act.Description == "chotko");
        //    Assert.IsTrue(act.Duration == 30);
        //    Assert.IsTrue(act.MembersCount == 30);
        //    Assert.IsTrue(act.IsDeleted == false);
        //}

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
