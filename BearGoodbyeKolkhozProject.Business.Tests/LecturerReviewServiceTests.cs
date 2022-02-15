using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
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
        private readonly Mock<ILecturerReviewRepository> _lecturerReviewRepositoryMock;
        private readonly LecturerReviewService _service;
        private readonly IMapper _mapper;

        public LecturerReviewServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _lecturerReviewRepositoryMock = new Mock<ILecturerReviewRepository>();
            _service = new LecturerReviewService(_mapper, _lecturerReviewRepositoryMock.Object);
        }

        [TestCaseSource(typeof(GetLecturerReviewModelByIdTestCaseSource))]
        public void GetLecturerReviewModelByIdTest(LecturerReview review, LecturerReviewModel expected, int id)
        {
            //given
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(id)).Returns(review);

            //when
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
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviews()).Returns(reviews);

            //when
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
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewsByLecturerId(lecturerId)).Returns(reviews);

            //when
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
        public void AddLecturerReviewTest(LecturerReview review, LecturerReviewModel expected)
        {
            //given
            _lecturerReviewRepositoryMock.Setup(lr => lr.AddLecturerReview(review));

            //when
            _service.AddLecturerReview(expected);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.AddLecturerReview(review), Times.Once);
        }

        //[TestCaseSource(typeof(DeleteLecturerReviewByIdTestCaseSource))]
        [TestCase(1)]
        public void DeleteLecturerReviewByIdTest(int id)
        {
            //given

            _lecturerReviewRepositoryMock.Setup(lr => lr.DeleteLecturerReviewById(id));
            //_lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(id)).Returns(review);

            //when
            _service.DeleteLecturerReviewById(id);

            //then
            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(id), Times.Once);
            _lecturerReviewRepositoryMock.Verify(x => x.DeleteLecturerReviewById(id), Times.Once);
        }
    }
}