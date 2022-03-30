using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.EventTestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class EventRepositoryTests
    {
        private ApplicationContext _context;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _context = new ApplicationContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            ;
        }


        [TestCaseSource(typeof(AddEventTestCaseSource))]
        public void AddEventTest(Event expected)
        {
            //given
            EventRepository eventRepository = new EventRepository(_context);
            _context.Event.Add(expected);


            //when
            eventRepository.AddEvent(expected);
            var actual = _context.Event.FirstOrDefault(e => e.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }



        [TestCaseSource(typeof(DeleteEventTestCaseSource))]
        public void DeleteEventTest(Event even, Event expected)
        {
            //given
            EventRepository eventRepository = new EventRepository(_context);
            _context.Event.Add(even);
            _context.SaveChanges();

            //when
            eventRepository.UpdateEvent(even);
            var actual = _context.Event.FirstOrDefault(c => c.Id == even.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetCompletedEventsByLecturerTestCaseSource))]
        public void GetCompletedEventsByLecturerIdTest(Lecturer lecturer
            , List<Event> events
            , DateTime date
            , List<Event> expected)
        {
            //given
            EventRepository eventRepository = new EventRepository(_context);
            _context.Event.AddRange(events);
            _context.SaveChanges();

            //when
            var actual = eventRepository.GetCompletedEventsByLecturer(lecturer, date);

            //then
            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAttendedEventsByClientTestCaseSource))]
        public void GetAttendedEventsByClientTest(Client client
            , List<Event> events
            , DateTime date
            , List<Event> expected)
        {
            EventRepository eventRepository = new EventRepository(_context);
            _context.Event.AddRange(events);
            _context.SaveChanges();

            //when
            var actual = eventRepository.GetAttendedEventsByClient(client, date);

            //then
            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(PartialUpdateEventTestCaseSource))]
        public void PartialUpdateEventTest(
            List<Training> mockTraining,
            Client mockUser,
            List<Lecturer> mockLector,
            List<Classroom> mockClassrom, 
            Event expected)
        {
            //given
            TrainingRepository trainingRepository = new TrainingRepository(_context);
            ClientRepository clientRepository = new ClientRepository(_context);
            EventRepository eventRepository = new EventRepository(_context);
            LecturerRepository lecturerRepository = new LecturerRepository(_context);
            ClassroomRepository classroomRepository = new ClassroomRepository(_context);

            
            var idTraning = trainingRepository.AddTraining(mockTraining[0]);
            var idLecturer = lecturerRepository.AddLecturer(mockLector[0]); 
            var idClient = clientRepository.AddClient(mockUser);
            var idClassroom = classroomRepository.AddNewClassroom(mockClassrom[0]);

            _context.Event.Add(new Event 
            {
                IsDeleted=false,
                StartDate = new DateTime(1999, 12, 12),
                Training = trainingRepository.GetTrainingById(idTraning),
                Lecturer = lecturerRepository.GetLecturerById(idLecturer),
                Classroom = classroomRepository.GetClassroomById(idClassroom),
            });

            _context.SaveChanges(); // id 1.

            var singUpEvent = eventRepository.GetEventById(1); // id 1 назначается по умолчанию.
            var itemClient = clientRepository.GetClientById(idClient);
            eventRepository.SignUp(itemClient, singUpEvent);

            var oldEvent = eventRepository.GetEventById(singUpEvent.Id);

            //when
            
            idTraning = trainingRepository.AddTraining(mockTraining[1]);
            idLecturer = lecturerRepository.AddLecturer(mockLector[1]);
            idClassroom = classroomRepository.AddNewClassroom(mockClassrom[1]);

            Event newEvent = new Event()
            {
                StartDate = expected.StartDate,
                Classroom = classroomRepository.GetClassroomById(idClassroom),
                Training = trainingRepository.GetTrainingById(idTraning),
                Lecturer = lecturerRepository.GetLecturerById(idLecturer)
            };
            eventRepository.PartialUpdateEvent(oldEvent, newEvent);

            var actual = _context.Event.FirstOrDefault(c => c.Id == oldEvent.Id);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.Classroom.Id, actual.Classroom.Id);
            Assert.AreEqual(expected.Training.Id, actual.Training.Id);
            Assert.AreEqual(expected.Lecturer.Id, actual.Lecturer.Id);
        }
    }
}
