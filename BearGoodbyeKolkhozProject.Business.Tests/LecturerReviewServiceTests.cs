using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.LecturerReviewTestCaseSource;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections.Generic;
using NUnit.Framework;
using AutoMapper;
using Moq;

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
        public void DeleteLecturerReviewByIdTest(int id, LecturerReview review)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();

            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(id)).Returns(review);
            _lecturerReviewRepositoryMock.Setup(lr => lr.ChangeIsDeleted(review, true));

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            _service.DeleteLecturerReviewById(id);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(id), Times.Once);
            _lecturerReviewRepositoryMock.Verify(x => x.ChangeIsDeleted(review, true), Times.Once);
        }

        [TestCaseSource(typeof(DeleteLecturerReviewByIdTestCaseSource))]
        public void RecoverLecturerReviewByIdTest(int id, LecturerReview review)
        {
            //given
            Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();

            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(id)).Returns(review);
            _lecturerReviewRepositoryMock.Setup(lr => lr.ChangeIsDeleted(review, false));

            //when
            LecturerReviewService _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
            _service.RecoverLecturerReviewById(id);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(id), Times.Once);
            _lecturerReviewRepositoryMock.Verify(x => x.ChangeIsDeleted(review, false), Times.Once);
        }
    }
}