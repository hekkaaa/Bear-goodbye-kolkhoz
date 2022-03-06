using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSourse;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.EventTestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            eventRepository.DeleteEvent(even);
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
    }
}
