using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TopicRepositoryTestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class TopicRepositoryTests
    {
        private ApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            _context = new ApplicationContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestCaseSource(typeof(GetTopicByIdTestCaseSource))]
        public void GetTopicByIdTest(Topic topic, Topic expected, int id)
        {
            //given
            _context.Topic.Add(topic);
            _context.SaveChanges();

            //when
            TopicRepository topicRepository = new TopicRepository(_context);
            var actual = topicRepository.GetTopicById(id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetTopicsTestCaseSource))]
        public void GetTopicsTest(List<Topic> topics, List<Topic> expected)
        {
            //given
            _context.Topic.AddRange(topics);
            _context.SaveChanges();

            //when
            TopicRepository topicRepository = new TopicRepository(_context);
            var actual = topicRepository.GetTopics();

            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetTopicsByTrainingIdTestCaseSource))]
        public void GetTopicsByTrainingIdTest(List<Topic> topics, List<Topic> expected, int triningId)
        {
            //given
            _context.Topic.AddRange(topics);
            _context.SaveChanges();

            //when
            TopicRepository topicRepository = new TopicRepository(_context);
            var actual = topicRepository.GetTopicsByTrainingId(triningId);
            var test = topicRepository.GetTopics();
            //then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(AddTopicTestCaseSource))]
        public void AddTopicTest(Topic topic, Topic expected, int id)
        {
            //given

            //when
            TopicRepository topicRepository = new TopicRepository(_context);
            topicRepository.AddTopic(topic);

            //then
            var actual = _context.Topic.FirstOrDefault(t => t.Id == id);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(UpdateTopicTestCaseSource))]
        public void UpdateTopicByIdTest(Topic topic, Topic updateModel, Topic expected, int id)
        {
            //given
            _context.Topic.Add(topic);
            _context.SaveChanges();

            //when
            TopicRepository topicRepository = new TopicRepository(_context);
            topicRepository.UpdateTopic(updateModel, id);

            //then
            var actual = _context.Topic.FirstOrDefault(t => t.Id == expected.Id);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ChangeDeleteStatusByIdTestCaseSource))]
        public void ChangeDeleteStatusByIdTest(Topic topic, Topic expected, bool isDeleted)
        {
            //given
            _context.Topic.Add(topic);
            _context.SaveChanges();

            //when
            TopicRepository topicRepository = new TopicRepository(_context);
            topicRepository.ChangeDeleteStatus(topic, isDeleted);

            //then
            var actual = _context.Topic.FirstOrDefault(t => t.Id == expected.Id);
            Assert.AreEqual(expected, actual);
        }
    }
}
