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
            var act = _service.GetTrainingModelByTopic(topicModel.Id);

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
            Assert.Throws<NotFoundException>(() => _service.GetTrainingModelByTopic(topicModel.Id));
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

        [TestCaseSource(typeof(UpdateTrainingByIdTestCaseSource))]
        public void UpdateTrainingByIdNegativeTests(Training training, TrainingModel trainingModel)
        {
            ///given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainingById(training.Id)).Returns(training);
            trainingRepository.Setup(t => t.UpdateTraining(It.IsAny<Training>()));

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.UpdateTraining(1024, trainingModel));
        }

        [TestCaseSource(typeof(GetTrainingModelsTestCaseSource))]
        public void GetTrainingModelsTests(List<Training> entity)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainings()).Returns(entity);

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            var act = _service.GetTrainingModels();
            
            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Count == 2);
        }

        [TestCaseSource(typeof(DeleteTrainingByIdTestCaseSource))]
        public void DeleteTrainingByIdTests(Training entity)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainingById(entity.Id)).Returns(entity);
            trainingRepository.Setup(t => t.UpdateTraining(entity, true));


            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            _service.DeleteTraining(entity.Id);

            //then
            trainingRepository.Verify(t => t.GetTrainingById(entity.Id), Times.Once);
            trainingRepository.Verify(t => t.UpdateTraining(entity, true), Times.Once);
        }
        
        [TestCaseSource(typeof(DeleteTrainingByIdTestCaseSource))]
        public void RestoreTrainingByIdTests(Training entity)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainingById(entity.Id)).Returns(entity);
            trainingRepository.Setup(t => t.GetTrainingById(entity.Id)).Returns(entity);
            trainingRepository.Setup(t => t.UpdateTraining(entity, true));
            trainingRepository.Setup(t => t.UpdateTraining(entity, false));


            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            _service.DeleteTraining(entity.Id);
            _service.RestoreTraining(entity.Id);

            //then
            trainingRepository.Verify(t => t.GetTrainingById(entity.Id), Times.Exactly(2));
            trainingRepository.Verify(t => t.UpdateTraining(entity, false), Times.Once);
        }


        [TestCaseSource(typeof(UpdateTrainingByIdTestCaseSource))]
        public void DeleteTrainingNegativeTests(Training training, TrainingModel trainingModel)
        {
            ///given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainingById(training.Id)).Returns(training);
            trainingRepository.Setup(t => t.UpdateTraining(training, true));

            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.DeleteTraining(1024));
        }

        [TestCaseSource(typeof(DeleteTrainingByIdTestCaseSource))]
        public void RestoreTrainingByIdNegativeTests(Training entity)
        {
            //given
            Mock<ITrainingRepository> trainingRepository = new Mock<ITrainingRepository>();
            Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
            Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();
            Mock<ITrainingReviewRepository> trainingReviewRepository = new Mock<ITrainingReviewRepository>();

            trainingRepository.Setup(t => t.GetTrainingById(entity.Id)).Returns(entity);
            trainingRepository.Setup(t => t.GetTrainingById(entity.Id)).Returns(entity);
            trainingRepository.Setup(t => t.UpdateTraining(entity, true));
            trainingRepository.Setup(t => t.UpdateTraining(entity, false));


            //when
            TrainingService _service = new TrainingService(trainingRepository.Object, _mapper, clientRepository.Object, trainingReviewRepository.Object, topicRepository.Object);
            _service.DeleteTraining(entity.Id);
            _service.RestoreTraining(entity.Id);

            //then
            Assert.Throws<NotFoundException>(() => _service.RestoreTraining(1024));
            
        }

    }
}
