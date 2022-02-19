using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.LecturerReviewTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class LecturerReviewServiceTests
    {
        private readonly IMapper _mapper;

        public LecturerReviewServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        }

        [TestCaseSource(typeof(GetLecturerReviewModelByIdTestCaseSource))]
        public void GetLecturerReviewModelByIdTest(LecturerReview review, LecturerReviewModel expected, int id)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(id)).Returns(review);

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            var actual = _service.GetLecturerReviewModelById(id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Mark, actual.Mark);
            Assert.AreEqual(expected.Client, actual.Client);

            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetLecturerReviewsTestCaseSource))]
        public void GetLecturerReviewsTest(List<LecturerReview> reviews, List<LecturerReviewModel> expected)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviews()).Returns(reviews);

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            var actual = _service.GetLecturerReviews();

            //then
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Text, actual[i].Text);
                Assert.AreEqual(expected[i].Mark, actual[i].Mark);
                Assert.AreEqual(expected[i].Client, actual[i].Client);
            }
        }

        [TestCaseSource(typeof(GetLecturerReviewsByLecturerIdTestCaseSource))]
        public void GetLecturerReviewsByLecturerIdTest(List<LecturerReview> reviews
            , List<LecturerReviewModel> expected
            , int lecturerId)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewsByLecturerId(lecturerId)).Returns(reviews);

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            var actual = _service.GetLecturerReviewsByLecturerId(lecturerId);

            //then
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Text, actual[i].Text);
                Assert.AreEqual(expected[i].Mark, actual[i].Mark);
                Assert.AreEqual(expected[i].Client, actual[i].Client);
            }
        }

        [TestCaseSource(typeof(AddLecturerReviewTestCaseSource))]
        public void AddLecturerReviewTest(LecturerReviewModel reviewModel)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.AddLecturerReview(It.IsAny<LecturerReview>()));

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            _service.AddLecturerReview(reviewModel);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.AddLecturerReview(It.IsAny<LecturerReview>()), Times.Once);
        }

        //[TestCase(1)]
        [TestCaseSource(typeof(DeleteLecturerReviewByIdTestCaseSource))]
        public void DeleteLecturerReviewByIdTest(LecturerReview review)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();

            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(review.Id)).Returns(review);
            _lecturerReviewRepositoryMock.Setup(lr => lr.ChangeIsDeleted(review, true));

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            _service.DeleteLecturerReviewById(review.Id);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(review.Id), Times.Once);
            _lecturerReviewRepositoryMock.Verify(x => x.ChangeIsDeleted(review, true), Times.Once);
        }

        [TestCaseSource(typeof(DeleteLecturerReviewByIdTestCaseSource))]
        public void RecoverLecturerReviewByIdTest(LecturerReview review)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();

            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(review.Id)).Returns(review);
            _lecturerReviewRepositoryMock.Setup(lr => lr.ChangeIsDeleted(review, false));

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            _service.RecoverLecturerReviewById(review.Id);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(review.Id), Times.Once);
            _lecturerReviewRepositoryMock.Verify(x => x.ChangeIsDeleted(review, false), Times.Once);
        }

        [Test]
        public void GetLecturerReviewModelById_WhenTopicNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(It.IsAny<int>())).Returns((LecturerReview)null);

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.GetLecturerReviewModelById(It.IsAny<int>()));

            _lecturerReviewRepositoryMock.Verify(lr => lr.GetLecturerReviewById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void DeleteLecturerReviewById_WhenTopicNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(It.IsAny<int>())).Returns((LecturerReview)null);

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.DeleteLecturerReviewById(It.IsAny<int>()));

            _lecturerReviewRepositoryMock.Verify(lr => lr.GetLecturerReviewById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void RecoverLecturerReviewById_WhenTopicNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(It.IsAny<int>())).Returns((LecturerReview)null);

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);

            //then
            Assert.Throws<NotFoundException>(() => _service.RecoverLecturerReviewById(It.IsAny<int>()));

            _lecturerReviewRepositoryMock.Verify(lr => lr.GetLecturerReviewById(It.IsAny<int>()), Times.Once);
        }
    }
}