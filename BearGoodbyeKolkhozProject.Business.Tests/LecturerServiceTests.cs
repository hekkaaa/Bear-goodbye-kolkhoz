using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class LecturerServiceTests
    {

        private readonly IMapper _mapper;
        private Mock<ILecturerRepository> _lecturerRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<ITrainingRepository> _trainingRepository;


        public LecturerServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _lecturerRepository = new Mock<ILecturerRepository>();
            _userRepository = new Mock<IUserRepository>();
            _trainingRepository = new Mock<ITrainingRepository>();

        }

        [TestCaseSource(typeof(GetLecturerModelByIdCaseSource))]
        public void GetLecturerModelByIdTest(Lecturer entity, LecturerModel expected, int id)
        {
            //given
            _lecturerRepository.Setup(l => l.GetLecturerById(id)).Returns(entity);

            //when
            LecturerService _service = new LecturerService(_lecturerRepository.Object, _userRepository.Object, _trainingRepository.Object, _mapper);
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
        public void GetLecturersTests(List<Lecturer> lecturers, List<LecturerModel> expected)
        {
            //given
            _lecturerRepository.Setup(l => l.GetLecturers()).Returns(lecturers);

            //when
            LecturerService _service = new LecturerService(_lecturerRepository.Object, _userRepository.Object, _trainingRepository.Object, _mapper);
            var actual = _service.GetLecturers();

            //then
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i<expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].LastName, actual[i].LastName);
                Assert.AreEqual(expected[i].Gender, actual[i].Gender);
                Assert.AreEqual(expected[i].BirthDay, actual[i].BirthDay);
            }
        }

        [Test]
        public void AddLecturerTests()
        {
            //given
            var lecturerModel = new LecturerModel()
            {
                Id = 112,
                Name = "fff",
                LastName = "fff",
                BirthDay = DateTime.Now,
                Email = "l",
                Gender = Data.Enums.Gender.Male,
                Password = "hyi"
            };
            _lecturerRepository.Setup(l => l.AddLecturer(It.IsAny<Lecturer>()));


            //when
            LecturerService _service = new LecturerService(_lecturerRepository.Object, _userRepository.Object, _trainingRepository.Object, _mapper);
            _service.RegistrationLecturer(lecturerModel);

            //then
            _lecturerRepository.Verify(l => l.AddLecturer(It.IsAny<Lecturer>()), Times.Once);
        }

        [Test]
        public void DeleteLecturerTests()
        {
            //given
            var lecturer = new Lecturer()
            {
                Id = 112,
                Name = "fff",
                LastName = "fff",
                BirthDay = DateTime.Now,
                Email = "l",
                Gender = Data.Enums.Gender.Male,
                Password = "hyi"
            };
            _lecturerRepository.Setup(l => l.GetLecturerById(lecturer.Id)).Returns(lecturer);
            _lecturerRepository.Setup(l => l.UpdateLecturer(lecturer, true));

            //when
            LecturerService _service = new LecturerService(_lecturerRepository.Object, _userRepository.Object, _trainingRepository.Object, _mapper);
            _service.DeleteLecturer(lecturer.Id);

            //then
            _lecturerRepository.Verify(l => l.GetLecturerById(lecturer.Id), Times.Once);
            _lecturerRepository.Verify(l => l.UpdateLecturer(lecturer, true), Times.Once);
        }
    }
}
