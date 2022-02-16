using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class Tests
    {
        private TrainingReviewService _service;
        private ApplicationContext _context;
        private TrainingReviewRepository _trainingRepository;
        private TestData _testData;
        private IMapper _mapper;


        [SetUp]
        public void Setup()
        {
            //var options = new DbContextOptionsBuilder<ApplicationContext>()
            //   .UseInMemoryDatabase(databaseName: "Memory-DB")
            //   .Options;
            //_context = new ApplicationContext(options);
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));

        }


        [TestCaseSource(typeof (GetTrainingReviewByIdTestCaseSource))]
        public void GetTrainingReviewModelByIdTests(TrainingReview trainingReviewModel, TrainingReviewModel expected, int id)
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(lr => lr.GetTrainingReviewById(id)).Returns(trainingReviewModel);
            //when
            TrainingReviewService _service = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);
            var act = _service.GetTrainingReviewModelById(id);
            //then
            Assert.IsTrue(expected.Id == act.Id);
            Assert.IsTrue(expected.Text == act.Text);
            Assert.IsTrue(expected.Mark == act.Mark);
        }

        [Test]
        public void UpdateTrainingReviewTests()
        {
            //given
            var oldTR = _testData.GetTrainingReviewModel();
            var id = _service.AddTrainingReview(oldTR);

            var newTR = new TrainingReviewModel
            {
                Id = id,
                Mark = 666,
                Text = "test"
            };
            //when
            _service.UpdateTrainingReview(id, newTR);
            var act = _service.GetTrainingReviewModelById(id);
            //then
            Assert.IsTrue(act.Mark == newTR.Mark);
            Assert.IsTrue(act.Text == newTR.Text);
        }

        [Test]
        public void UpdateTrainingReviewNegativeTests()
        {
            //given
            var trainingReviewModel = _testData.GetTrainingReviewModel();
            //when
            //then
            Assert.Throws<BusinessException>(() => _service.UpdateTrainingReview(666, trainingReviewModel));
        }

        [Test]
        public void GetTrainingReviewByIdTests()
        {
            //given
            var tr = _testData.GetTrainingReviewModel();
            var id = _service.AddTrainingReview(tr);

            //when
            var act = _service.GetTrainingReviewModelById(id);
            //then
            Assert.IsTrue(act.Mark == tr.Mark);
            Assert.IsTrue(act.Text == tr.Text);
        }

        [Test]
        public void GetTrainingReviewByIdNegativeTests()
        {
            //given
            //when
            //then
            Assert.Throws<BusinessException>(() => _service.GetTrainingReviewModelById(666));
        }

        [Test]
        public void GetTrainingReviewModelsTests()
        {
            //given
            var tr1 = _testData.GetTrainingReviewModel();
            var tr2 = _testData.GetTrainingReviewModel();
            var tr3 = _testData.GetTrainingReviewModel();
            tr1.Training = null;
            tr2.Training = null;
            tr3.Training = null;
            _service.AddTrainingReview(tr1);
            _service.AddTrainingReview(tr2);
            _service.AddTrainingReview(tr3);
            //when
            var act = _service.GetTrainingReviewModels();
            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act.Count == 3);
        }

        [Test]
        public void DeleteTrainingReviewTests()
        {
            //given
            var tr = _testData.GetTrainingReviewModel();
            var id = _service.AddTrainingReview(tr);
            //when
            var listBeforeDelete = _service.GetTrainingReviewModels();
            _service.DeleteTrainingReview(id);
            var listAfterDelete = _service.GetTrainingReviewModels();
            //then
            Assert.IsTrue(listBeforeDelete.Count - listAfterDelete.Count == 1);
        }

        [Test]
        public void DeleteTrainingReviewNegativeTests()
        {
            //given
            var trainingReviewModel = _testData.GetTrainingReviewModel();
            trainingReviewModel.Id = 666;

            //when
            //then
            Assert.Throws<BusinessException>(() => _service.DeleteTrainingReview(666));

        }

    }
}