using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TrainingReviewSeviceTests
    {
        private TrainingReviewService _service;
        private IMapper _mapper;


        [SetUp]
        public void Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        }


        [TestCaseSource(typeof(GetTrainingReviewByIdTestCaseSource))]
        public void GetTrainingReviewModelByIdTests(TrainingReview entity, TrainingReviewModel expected, int id)
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.GetTrainingReviewById(id)).Returns(entity);
            //when
            TrainingReviewService _service = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);
            var act = _service.GetTrainingReviewModelById(id);
            //then
            Assert.IsTrue(expected.Id == act.Id);
            Assert.IsTrue(expected.Text == act.Text);
            Assert.IsTrue(expected.Mark == act.Mark);
        }

        [TestCaseSource(typeof(UpdateTrainingReviewTestCaseSource))]
        public void UpdateTrainingReviewTests(TrainingReview original, TrainingReviewModel update)
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.GetTrainingReviewById(original.Id)).Returns(original);
            _trainingReviewRepository.Setup(tr => tr.UpdateTrainingReview(It.IsAny<TrainingReview>()));

            //when
            TrainingReviewService trainingReviewService = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);
            trainingReviewService.UpdateTrainingReview(original.Id, update);

            //then
            _trainingReviewRepository.Verify(tr => tr.UpdateTrainingReview(It.IsAny<TrainingReview>()), Times.Once);
        }

        [TestCaseSource(typeof(UpdateTrainingReviewTestCaseSource))]
        [Test]
        public void UpdateTrainingReviewNegativeTests(TrainingReview original, TrainingReviewModel update)
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.UpdateTrainingReview(It.IsAny<TrainingReview>()));

            //when
            TrainingReviewService trainingReviewService = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);

            //then
            Assert.Throws<BusinessException>(() => trainingReviewService.UpdateTrainingReview(666, update));
        }

        [TestCaseSource(typeof(GetTrainingReviewByIdTestCaseSource))]
        [Test]
        public void GetTrainingReviewByIdTests(TrainingReview trainingReview, TrainingReviewModel expected, int id)
        {

            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.GetTrainingReviewById(id)).Returns(trainingReview);

            //when
            _service = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);
            var act = _service.GetTrainingReviewModelById(id);
            //then
            Assert.IsTrue(act.Mark == expected.Mark);
            Assert.IsTrue(act.Text == expected.Text);
        }

        [Test]
        public void GetTrainingReviewByIdNegativeTests()
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.GetTrainingReviewById(It.IsAny<int>()));
            //when
            TrainingReviewService trainingReviewService = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);

            //then
            Assert.Throws<BusinessException>(() => trainingReviewService.GetTrainingReviewModelById(666));
        }

        [TestCaseSource(typeof(GetTrainingReviewsTestCaseSource))]
        public void GetTrainingReviewModelsTests(List<TrainingReview> trainingReviews, List<TrainingReviewModel> expected)
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.GetTrainingReviews()).Returns(trainingReviews);

            //when
            _service = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);
            var act = _service.GetTrainingReviewModels();

            //then
            Assert.IsTrue(act[0].Mark == expected[0].Mark);
            Assert.IsTrue(act[0].Text == expected[0].Text);
            Assert.IsTrue(act[1].Mark == expected[1].Mark);
            Assert.IsTrue(act[1].Text == expected[1].Text);
        }

        [TestCaseSource(typeof(DeleteTrainingReviewByIdTestCaseSource))]
        public void DeleteTrainingReviewTests(TrainingReview trainingReview, int id)
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.GetTrainingReviewById(id)).Returns(trainingReview);
            _trainingReviewRepository.Setup(tr => tr.DeleteTrainingReview(id));

            //when
            _service = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);
            _service.DeleteTrainingReview(id);
            //then
            _trainingReviewRepository.Verify(tr => tr.GetTrainingReviewById(id), Times.Once);
            _trainingReviewRepository.Verify(tr => tr.DeleteTrainingReview(id), Times.Once);

        }

        [Test]
        public void DeleteTrainingReviewNegativeTests()
        {
            //given
            Mock<ITrainingReviewRepository> _trainingReviewRepository = new Mock<ITrainingReviewRepository>();
            _trainingReviewRepository.Setup(tr => tr.DeleteTrainingReview(It.IsAny<int>()));
            //when
            TrainingReviewService trainingReviewService = new TrainingReviewService(_trainingReviewRepository.Object, _mapper);

            //then
            Assert.Throws<BusinessException>(() => trainingReviewService.DeleteTrainingReview(666));
        }

    }
}