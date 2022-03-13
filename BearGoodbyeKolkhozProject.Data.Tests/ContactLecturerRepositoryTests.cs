using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.ContactLecturerTestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    internal class ContactLecturerRepositoryTests
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
        }

        [TestCaseSource(typeof(AddContactTestCaseSource))]
        public void AddContact(ContactLecturer expected, int id)
        {
            //given
            ContactLecturerRepository contactLecturerRepository = new ContactLecturerRepository(_context);

            //when
            contactLecturerRepository.AddContact(expected);
            var actual = _context.ContactLecturer.FirstOrDefault(c => c.Id == id);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
