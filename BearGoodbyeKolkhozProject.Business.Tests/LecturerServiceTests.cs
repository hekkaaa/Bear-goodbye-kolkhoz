using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class LecturerServiceTests
    {

        private readonly IMapper _mapper;
        private Mock<ILecturerRepository> _lecturerRepository;
        private Mock<IUserRepository> _uesrRepository;
        private Mock<ITrainingRepository> _trainingRepository;

        public LecturerServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _lecturerRepository = new Mock<ILecturerRepository>();

        }

        [TestCaseSource(typeof(GetLecturerModelByIdCaseSource))]
        public void GetLecturerModelByIdTest(Lecturer entity, LecturerModel expected, int id)
        {
            //given
            _lecturerRepository.Setup(l => l.GetLecturerById(id)).Returns(entity);

            //when
            LecturerService _service = new LecturerService(_lecturerRepository.Object, _uesrRepository.Object, _trainingRepository.Object, _mapper);
            var actual = _service.GetLecturerById(id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Gender, actual.Gender);
            Assert.AreEqual(expected.BirthDay, actual.BirthDay);
            _lecturerRepository.Verify(x => x.GetLecturerById(id), Times.Once);

        }

        [TestCaseSource(typeof(GetLecturersTestCaseSource))]
        public void GetLecturersTests()
        {
            //given


            //when


            //then


        }
    }
}
