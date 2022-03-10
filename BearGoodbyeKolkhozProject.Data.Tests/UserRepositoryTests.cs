using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.UserTestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class UserRepositoryTests
    {

        private ApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            _context = new ApplicationContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }


        [TestCaseSource(typeof(GetUserByEmailTestCaseSource))]
        public void GetUserByEmailTests(List<Client> user, Client expected)
        {
            //given
            foreach (var item in user)
            {
                _context.Client.Add(item);
            }

            _context.SaveChanges();

            //when
            UserRepository userRepository = new UserRepository(_context);

            var actual = userRepository.GetUserByEmail(user[1].Email);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Gender, actual.Gender);
            Assert.AreEqual(expected.BirthDay, actual.BirthDay);
        }


        [TestCaseSource(typeof(GetUserByIdTestCaseSource))]
        public void GetUserByIdTests(List<Client> user, Client expected)
        {
            foreach (var item in user)
            {
                _context.Client.Add(item);
            }

            _context.SaveChanges();

            //when
            UserRepository userRepository = new UserRepository(_context);

            var actual = userRepository.GetUserById(user[1].Id);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Gender, actual.Gender);
            Assert.AreEqual(expected.BirthDay, actual.BirthDay);
        }

        [TestCaseSource(typeof(ChangeDeleteStatusUserTestCaseSource))]
        public void ChangeDeleteStatusUserTests(Lecturer user, Lecturer expected)
        {

            _context.User.Add(user);
            _context.SaveChanges();

            //when
            UserRepository userRepository = new UserRepository(_context);

            var virtualItem = userRepository.GetUserById(expected.Id);
            bool actual = userRepository.ChangeDeleteStatusUser(virtualItem, false);

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual);
            Assert.AreEqual(expected.IsDeleted, virtualItem.IsDeleted);
        }
    }
}
