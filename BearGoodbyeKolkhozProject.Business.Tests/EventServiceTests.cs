using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventServiceTestCaseSource;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventTestCaseSource;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class EventServiceTests
    {
        private readonly IMapper _mapper;
        private Mock<IEventRepository> _eventRepository;
        private Mock<ILecturerRepository> _lecturerRepository;
        private Mock<ITrainingRepository> _trainingRepository;
        private Mock<IClassroomRepository> _classroomRepository;
        private Mock<ICompanyRepository> _companyRepository;
        private Mock<IClientRepository> _clientRepository;
        private EventTestData _eventTestData;
        public EventServiceTests()
        {
            _eventRepository = new();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _eventTestData = new();
            _lecturerRepository = new();
            _trainingRepository = new();
            _classroomRepository = new();
            _companyRepository = new();
            _clientRepository = new();
        }


        [SetUp]
        public void Setup()
        {
                      
        }


        [Test]
        public void GetEventByIdTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var expected = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.GetEventById(1)).Returns(entity);

            //when
            var service = new 
                EventService(
                _eventRepository.Object,
                _trainingRepository.Object, 
                _clientRepository.Object,
                _lecturerRepository.Object,
                _classroomRepository.Object,
                _companyRepository.Object,
                _mapper);
            var actual = service.GetEventById(1);

            //then
            Assert.IsNotNull(actual.Training);
            Assert.IsNotNull(actual.Classroom);
            Assert.IsNotNull(actual.Lecturer);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.StartDate, expected.StartDate);

            _eventRepository.Verify(x => x.GetEventById(1), Times.Once);

        }


        [Test]
        public void GetEventsTests()
        {
            
            //given
            var entity = _eventTestData.GetEntityList();
            var expected = _eventTestData.GetModelList();
            _eventRepository.Setup(er => er.GetEvents()).Returns(entity);

            //when
            var service = new
                EventService(
                _eventRepository.Object,
                _trainingRepository.Object,
                _clientRepository.Object,
                _lecturerRepository.Object,
                _classroomRepository.Object,
                _companyRepository.Object,
                _mapper);
            var actual = service.GetEvents();

            //then
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }

        }

        [Test]
        public void UpdateEvenTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var model = _eventTestData.GetModel();
            var lecturer = _eventTestData.GetLecturer();
            var training = _eventTestData.GetTraining();
            var classroom = _eventTestData.GetClassroom();
            _eventRepository.Setup(er => er.GetEventById(entity.Id)).Returns(entity);
            _lecturerRepository.Setup(l => l.GetLecturerById(1)).Returns(lecturer);
            _trainingRepository.Setup(tr => tr.GetTrainingById(1)).Returns(training);
            _classroomRepository.Setup(cr => cr.GetClassroomById(1)).Returns(classroom);
            _eventRepository.Setup(er => er.PartialUpdateEvent(It.IsAny<Event>(), It.IsAny<Event>()));
            
            //when
            var service = new
                EventService(
                _eventRepository.Object,
                _trainingRepository.Object,
                _clientRepository.Object,
                _lecturerRepository.Object,
                _classroomRepository.Object,
                _companyRepository.Object,
                _mapper);
            var actual = service.UpdateEvent(entity.Id, model);

            //then
            _eventRepository.Verify(l => l.GetEventById(entity.Id), Times.Once);
            _eventRepository.Verify(l => l.PartialUpdateEvent(It.IsAny<Event>(), It.IsAny<Event>()), Times.Once);
        }

        //[Test]
        //public void DeleteEventNegativeTest()
        //{
        //    //given
        //    var even = new EventModel
        //    {
        //        Id = 1,
        //        StartDate = new DateTime(2022, 03, 03),

        //    };

        //    _service.AddEvent(even);

        //    //when

        //    //then
        //    Assert.Throws<NotFoundException>(()=> _service.DeleteEvent(even.Id));

        //}
    }
}
