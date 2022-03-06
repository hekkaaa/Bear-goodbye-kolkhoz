using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
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
        private LecturerRepository _lecturerRepo;
        private ClassroomRepository _classroomRepo;
        private CompanyRepository _companyRepo;

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
            _service = new EventService(_eventRepository, _trainingRepo, _clientRepo, _lecturerRepo, _classroomRepo, _companyRepo, mapper);

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


        [Test]
        public void UpdateEvenTests()
        {
            //given
            var even = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),

            };

            _service.AddEvent(even);

            var eventUpdate = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 04),
            };

            //when
            _service.UpdateEvent(eventUpdate.Id, eventUpdate);

            var expected = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 04),
            };

            var actual = _service.GetEventById(eventUpdate.Id);
            //then
            Assert.IsTrue(actual.Id == expected.Id);
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.StartDate, expected.StartDate);

        }

        [Test]
        public void DeleteEventTest()
        {
            //given
            var even = new EventModel
            {
                Id = 1,
                StartDate = new DateTime(2022, 03, 03),

            };

            _service.AddEvent(even);

            //when

            _service.DeleteEvent(even.Id);

            EventModel expected = null;

            var actual = _context.Event.FirstOrDefault(e => e.Id == even.Id); 
            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
