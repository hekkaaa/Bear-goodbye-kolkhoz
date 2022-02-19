using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TopicServiceTestCaseSource;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections.Generic;
using NUnit.Framework;
using AutoMapper;
using Moq;
using BearGoodbyeKolkhozProject.Business.Exceptions;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TopicServiceTests
    {
        private readonly IMapper _mapper;

        public TopicServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        }

        [TestCaseSource(typeof(GetTopicByIdTestCaseSource))]
        public void GetTopicByIdTest(Topic topic, TopicModel expected, int id)
        {
            //given
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.GetTopicById(id)).Returns(topic);

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);
            var actual = _service.GetTopicById(id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
            Assert.AreEqual(expected.Lecturer, actual.Lecturer);
            Assert.AreEqual(expected.Client, actual.Client);
            Assert.AreEqual(expected.Training, actual.Training);

            _topicMock.Verify(x => x.GetTopicById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetTopicsTestCaseSource))]
        public void GetTopicsTest(List<Topic> topics, List<TopicModel> expected)
        {
            //given
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.GetTopics()).Returns(topics);

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);
            var actual = _service.GetTopics();

            //then
            Assert.AreEqual(expected.Count, topics.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].IsDeleted, actual[i].IsDeleted);
                Assert.AreEqual(expected[i].Lecturer, actual[i].Lecturer);
                Assert.AreEqual(expected[i].Client, actual[i].Client);
                Assert.AreEqual(expected[i].Training, actual[i].Training);
            }

            _topicMock.Verify(x => x.GetTopics(), Times.Once);
        }

        [TestCaseSource(typeof(AddTopicTestCaseSource))]
        public void AddTopicTest(TopicModel model)
        {
            //given
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.AddTopic(It.IsAny<Topic>()));

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);
            _service.AddTopic(model);

            //then
            _topicMock.Verify(x => x.AddTopic(It.IsAny<Topic>()), Times.Once);
        }

        [TestCaseSource(typeof(UpdateTopicTestCaseSource))]
        public void UpdateTopicTest(TopicModel updateModel, int id)
        {
            //given
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.UpdateTopic(It.IsAny<Topic>(), It.IsAny<int>()));

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);
            _service.UpdateTopic(updateModel, id);

            //then
            _topicMock.Verify(x => x.UpdateTopic(It.IsAny<Topic>(), It.IsAny<int>()), Times.Once);
        }

        [TestCaseSource(typeof(DeleteTopicTestCaseSource))]
        public void DeleteTopicByIdTest(Topic topic,TopicModel model, int id)
        {
            //given
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();

            _topicMock.Setup(lr => lr.GetTopicById(id)).Returns(topic);
            _topicMock.Setup(lr => lr.ChangeDeleteStatus(topic, true));

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);
            _service.DeleteTopic(model);

            //then
            _topicMock.Verify(t => t.GetTopicById(id), Times.Once);
            _topicMock.Verify(t => t.ChangeDeleteStatus(topic, true), Times.Once);
        }

        [TestCaseSource(typeof(DeleteTopicTestCaseSource))]
        public void RcoverTopicByIdTest(Topic topic, TopicModel model, int id)
        {
            //given
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();

            _topicMock.Setup(lr => lr.GetTopicById(id)).Returns(topic);
            _topicMock.Setup(lr => lr.ChangeDeleteStatus(topic, false));

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);
            _service.RecoverTopic(model);

            //then
            _topicMock.Verify(t => t.GetTopicById(id), Times.Once);
            _topicMock.Verify(t => t.ChangeDeleteStatus(topic, false), Times.Once);
        }

        public void GetTopicById_WhenTopicNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.GetTopicById(It.IsAny<int>())).Returns((Topic)null);

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.GetTopicById(It.IsAny<int>()));

            _topicMock.Verify(t => t.GetTopicById(It.IsAny<int>()), Times.Once);
        }

        public void DeleteTopic_WhenTopicNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.GetTopicById(It.IsAny<int>())).Returns((Topic)null);

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.DeleteTopic(It.IsAny<TopicModel>()));

            _topicMock.Verify(t => t.GetTopicById(It.IsAny<int>()), Times.Once);
        }

        public void RecoverTopic_WhenTopicNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            Mock<ITopicRepository> _topicMock = new Mock<ITopicRepository>();
            _topicMock.Setup(lr => lr.GetTopicById(It.IsAny<int>())).Returns((Topic)null);

            //when
            TopicService _service = new TopicService(_mapper, _topicMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.RecoverTopic(It.IsAny<TopicModel>()));

            _topicMock.Verify(t => t.GetTopicById(It.IsAny<int>()), Times.Once);
        }
    }
}