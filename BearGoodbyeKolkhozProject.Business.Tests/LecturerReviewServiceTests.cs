using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.LecturerReviewTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;

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
            // ��� ����� ��������� ������ ����������� ������ ������� ����� � ��� ���������� � ����� ������
            // �� ������ ������� �� ���� ������ ������ �� ��� �����, ��� ��� �������� ��� ��������� ����������������?
            _lecturerReviewRepositoryMock.Setup(lr => lr.GetLecturerReviewById(id)).Returns(review);

            //when
            var actual = _service.GetLecturerReviewModelById(id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Mark, actual.Mark);
            Assert.AreEqual(expected.Client, actual.Client);

            // ��� ����� ��������� ��� ����� ������ ������� ������ ����������� ����������� ���� ���?
            _lecturerReviewRepositoryMock.Verify(x => x.GetLecturerReviewById(id), Times.Once);
        }
    }
}