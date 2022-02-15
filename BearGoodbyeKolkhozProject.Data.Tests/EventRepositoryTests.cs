﻿using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using BearGoodbyeKolkhozProject.Data.Tests.TestCase;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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

    }
}