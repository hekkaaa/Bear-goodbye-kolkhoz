using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventServiceTestCaseSource;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventTestCaseSource;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class EventServiceTests
    {
        private ApplicationContext _context;

        private EventService _service;
        private ClientService _serviceClient;
        private TrainingService _trainingService;

        private EventRepository _eventRepository;
        private TrainingRepository _trainingRepo;
        private ClientRepository _clientRepo;
        private LecturerRepository _lecturerRepository;
        private ClassroomRepository _classroomRepo;
        private CompanyRepository _companyRepo;

        private IMapper _mapper;
        private Mock<IEventRepository> _eventRepository;
        private Mock<ILecturerRepository> _lecturerRepository;
        private Mock<ITrainingRepository> _trainingRepository;
        private Mock<IClassroomRepository> _classroomRepository;
        private Mock<ICompanyRepository> _companyRepository;
        private Mock<IClientRepository> _clientRepository;
        private EventTestData _eventTestData;
        private EventService _eventService;
      
        [SetUp]
        public void Setup()
        {
            _eventRepository = new();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _eventTestData = new();
            _lecturerRepository = new();
            _trainingRepository = new();
            _classroomRepository = new();
            _companyRepository = new();
            _clientRepository = new();
            _eventService = new EventService(
                 _eventRepository.Object,
                 _trainingRepository.Object,
                 _clientRepository.Object,
                 _lecturerRepository.Object,
                 _classroomRepository.Object,
                 _companyRepository.Object,
                 _mapper);
        }


        [Test]
        public void GetEventByIdTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var expected = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.GetEventById(1)).Returns(entity);

                Classroom = new ClassroomModel
                {
                    Id = 5,
                    MembersCount = 10,
                    City = "Санк-Петербург",
                    Address = "ул.Вавилова,д.6,оф.17",
                    IsDeleted = false
                },
                Lecturer = new LecturerModel
                {
                    Name = "Семен",
                    Email = "qwe@mail.ru",
                    LastName = "Семенов",
                    BirthDay = new DateTime(1993, 03, 03),
                    Gender = Data.Enums.Gender.Male,
                    Password = "12345"

                },
            };

            _service.AddEvent(even);

            //when

            var actual = _service.GetEventById(1);

            //then
            Assert.IsNotNull(actual.Training);
            Assert.IsNotNull(actual.Classroom);
            Assert.IsNotNull(actual.Lecturer);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.StartDate, expected.StartDate);

            _eventRepository.Verify(x => x.GetEventById(1), Times.Once);
        }

        [Test]
        public void GetEventByIdNegativeIfEntityNotFoundTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var expected = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.GetEventById(1));

            //when

            //then
            Assert.Throws<NotFoundException>(() => _eventService.GetEventById(entity.Id));
        }

        [Test]
        public void GetEventsTests()
        {

            //given
            var entity = _eventTestData.GetEntityList();
            var expected = _eventTestData.GetModelList();
            _eventRepository.Setup(er => er.GetEvents()).Returns(entity);

            //when
            var actual = _eventService.GetEvents();

            //then
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }

        [Test]
        public void UpdateEventTests()
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
            _eventService.UpdateEvent(entity.Id, model);

            //then
            _eventRepository.Verify(l => l.GetEventById(entity.Id), Times.Once);
            _eventRepository.Verify(l => l.PartialUpdateEvent(It.IsAny<Event>(), It.IsAny<Event>()), Times.Once);
        }
        
        [Test]
        public void UpdateEventNegativeIfEntityNotFoundTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var model = _eventTestData.GetModel();
            var lecturer = _eventTestData.GetLecturer();
            var training = _eventTestData.GetTraining();
            var classroom = _eventTestData.GetClassroom();
            _eventRepository.Setup(er => er.GetEventById(entity.Id));
            _lecturerRepository.Setup(l => l.GetLecturerById(1)).Returns(lecturer);
            _trainingRepository.Setup(tr => tr.GetTrainingById(1)).Returns(training);
            _classroomRepository.Setup(cr => cr.GetClassroomById(1)).Returns(classroom);
            _eventRepository.Setup(er => er.PartialUpdateEvent(It.IsAny<Event>(), It.IsAny<Event>()));

            //when

            //then
            Assert.Throws<NotFoundException>(() => _eventService.GetEventById(entity.Id));
        }

        [Test]
        public void AddEventTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var model = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.AddEvent(It.IsAny<Event>()));

            //when
            _eventService.AddEvent(model);

            //then
            _eventRepository.Verify(l => l.AddEvent(It.IsAny<Event>()), Times.Once);
        }

        [Test]
        public void DeleteEventTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var model = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.GetEventById(entity.Id)).Returns(entity);
            _eventRepository.Setup(er => er.UpdateEvent(It.IsAny<Event>(), true));

            //when
            _eventService.DeleteEvent(model.Id);

            //then
            Assert.IsTrue(actual.Id == expected.Id);
            Assert.IsNotNull(actual);


        }

        [Test]
        public void RestoreEventTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var model = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.GetEventById(entity.Id)).Returns(entity);
            _eventRepository.Setup(er => er.UpdateEvent(It.IsAny<Event>(), false));

            //when
            _eventService.RestoreEvent(model.Id);

            //then
            _eventRepository.Verify(er => er.UpdateEvent(It.IsAny<Event>(), false), Times.Once);
        }

        [Test]
        public void RestoreEventNegativeIfEntityNotFoundTests()
        {
            //given
            var entity = _eventTestData.GetEntity();
            var model = _eventTestData.GetModel();
            _eventRepository.Setup(er => er.GetEventById(entity.Id));
            _eventRepository.Setup(er => er.UpdateEvent(It.IsAny<Event>(), true));

            //when

            //then
            Assert.Throws<NotFoundException>(() => _service.DeleteEvent(even.Id));

        }


    }
}
