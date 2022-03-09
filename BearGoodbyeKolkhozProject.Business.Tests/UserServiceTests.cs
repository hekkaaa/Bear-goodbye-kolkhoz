using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.UserTestCaseSource;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class UserServiceTests
    {   
        private ApplicationContext _context;
        private IMapper _mapper;
        private UserService _userService;
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

            _context = new ApplicationContext(options);
            _userRepository = new UserRepository(_context);
            _userService = new UserService(_userRepository, _mapper);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        

        [TestCaseSource(typeof(DeleteUserByIdTestCaseSource))]
        public void GetUserByEmailTests(List<Client> user, Client expected)
        {
            //given
            foreach(var client in user)
            {
                _context.Client.Add(client);
            }
            
            _context.SaveChanges();

            //when
            UserService userService = new UserService(_userRepository, _mapper);
            var actual = userService.DeleteUserById(expected.Id);

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual);
        }

        [TestCaseSource(typeof(DeleteUserByIdTestCaseSource))]
        public void GetUserByEmailNotFoundExceptionNegativeTests(List<Client> user, Client expected)
        {
            //given
            foreach (var client in user)
            {
                _context.Client.Add(client);
            }

            _context.SaveChanges();

            //when
            UserService userService = new UserService(_userRepository, _mapper);

            //then
            Assert.Throws<NotFoundException>(() => userService.DeleteUserById(12));
        }

        [TestCaseSource(typeof(DeleteUserByIdTestCaseSource))]
        public void GetUserByEmailDuplicateExceptionNegativeTests(List<Client> user, Client expected)
        {
            //given
            foreach (var client in user)
            {
                _context.Client.Add(client);
            }

            _context.SaveChanges();

            //when
            UserService userService = new UserService(_userRepository, _mapper);

            //then
            Assert.Throws<DuplicateException>(() => userService.DeleteUserById(1));
        }

        [TestCaseSource(typeof(RecoverUserByEmailTestCaseSource))]
        public void RecoverUserByEmailTests(List<Client> user, Client expected)
        {
            //given
            foreach (var client in user)
            {
                _context.Client.Add(client);
            }

            _context.SaveChanges();

            //when
            UserService userService = new UserService(_userRepository, _mapper);
            var actual = userService.RecoverUserByEmail(expected.Email);

            //then
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual);
        }

        [TestCaseSource(typeof(RecoverUserByEmailTestCaseSource))]
        public void RecoverUserByEmailNotFoundExceptionNegativeTests(List<Client> user, Client expected)
        {
            //given
            foreach (var client in user)
            {
                _context.Client.Add(client);
            }

            _context.SaveChanges();

            //when
            UserService userService = new UserService(_userRepository, _mapper);

            //then
            Assert.Throws<NotFoundException>(()=> userService.RecoverUserByEmail("Deacoder221s@ya.ru"));
        }

        [TestCaseSource(typeof(RecoverUserByEmailTestCaseSource))]
        public void RecoverUserByEmailDuplicateExceptionNegativeTests(List<Client> user, Client expected)
        {
            //given
            foreach (var client in user)
            {
                _context.Client.Add(client);
            }

            _context.SaveChanges();

            //when
            UserService userService = new UserService(_userRepository, _mapper);

            //then
            Assert.Throws<DuplicateException>(() => userService.RecoverUserByEmail("barakuda22new@mail.ru"));
        }
    }
}
