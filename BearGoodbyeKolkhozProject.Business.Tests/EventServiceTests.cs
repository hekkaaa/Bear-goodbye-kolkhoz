using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventServiceTestCaseSource;
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
        private ApplicationContext  _context;

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

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;
            _context = new ApplicationContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _eventRepository = new EventRepository(_context);
            _service = new EventService(_eventRepository, _trainingRepo, _clientRepo, _lecturerRepository, _classroomRepo, _companyRepo, mapper);
            _eventRepository = new EventRepository(_context);
            _clientRepo = new ClientRepository(_context);
            _classroomRepo = new ClassroomRepository(_context);
            _trainingRepo = new TrainingRepository(_context);
            _lecturerRepository = new LecturerRepository(_context);
        }


        [Test]
        public void GetEventByIdTests()
        {
            //given
            var even = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),
                Company = new CompanyModel
                {
                    Id = 3,
                    Name = "OOO Ivan",
                    Email = "qwe@mail.ru",
                    PhoneNumber = "123456789",
                    Tin = 123234,
                    Password = "1234"
                },

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
            Assert.IsTrue(actual.Id == even.Id);
            Assert.IsNotNull(even);
            Assert.AreEqual(actual.StartDate, even.StartDate);

        }


        [Test]
        public void GetEventsTests()
        {
            //given
            var even = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),

            };

            _service.AddEvent(even);

            var even1 = new EventModel
            {
                Id = 2,
                StartDate = new DateTime(2012, 04, 04),

            };

            _service.AddEvent(even1);

            var even2 = new EventModel
            {
                Id = 3,
                StartDate = new DateTime(2010, 05, 05),

            };

            _service.AddEvent(even2);

            //when

            var actual = _service.GetEvents();

            List<EventModel> expected = new List<EventModel> { new EventModel {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),

            }
            ,new EventModel
            {
                Id = 2,
                StartDate = new DateTime(2012, 04, 04),
            }
            ,new EventModel
            {
                Id = 3,
                StartDate = new DateTime(2010, 05, 05),
            } };

            //when
            var act = _service.GetEvents();

            //then

            Assert.IsTrue(expected.Count == act.Count);
            Assert.IsNotNull(act);

        }


        [TestCaseSource(typeof(UpdateEventReviewTestCaseSource))]
        public void UpdateEvenTests(
            List<Training> mockTraining,
            Client mockUser,
            List<Lecturer> mockLector,
            List<Classroom> mockClassrom,
            EventModel newUpdateEvent,
            Event expected)
        {
            //given

            _context.Client.Add(mockUser);
            _context.Classroom.AddRange(mockClassrom);
            _context.Training.AddRange(mockTraining);
            _context.Lecturer.AddRange(mockLector);
            _context.SaveChanges();

            _context.Event.Add(new Event
            {
                Id = 1,
                IsDeleted = false,
                StartDate = new DateTime(1999, 12, 12),
                Training = _trainingRepo.GetTrainingById(mockTraining[0].Id),
                Lecturer = _lecturerRepository.GetLecturerById(mockLector[0].Id),
                Classroom = _classroomRepo.GetClassroomById(mockClassrom[0].Id),
            });
            _context.SaveChanges();

            var singUpEvent = _eventRepository.GetEventById(1); // id 1 назначается по умолчанию.
            Client itemClient = _clientRepo.GetClientById(mockUser.Id);

            _eventRepository.SignUp(itemClient, singUpEvent);

            ////when
            newUpdateEvent.Classroom = new ClassroomModel { Id = 2 };
            newUpdateEvent.Training = new TrainingModel { Id = 2 };
            newUpdateEvent.Lecturer = new LecturerModel { Id = 1 };

            EventModel AAAA = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 07, 06),
                Classroom = new ClassroomModel { Id = 2 },
                Lecturer = new LecturerModel { Id = 2 },
                Training = new TrainingModel { Id = 2 },
            };
            _context.SaveChanges();

            //var ts = _service.UpdateEvent(1, AAAA);

            var actual = _service.GetEventById(newUpdateEvent.Id);

            //then
            Assert.IsTrue(actual.Id == expected.Id);
            Assert.IsNotNull(actual);
           

        }

        [Test]
        public void DeleteEventNegativeTest()
        {
            //given
            var even = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),

            };

            _service.AddEvent(even);

            //when

            //then
            Assert.Throws<NotFoundException>(()=> _service.DeleteEvent(even.Id));
    
        }
    }
}
