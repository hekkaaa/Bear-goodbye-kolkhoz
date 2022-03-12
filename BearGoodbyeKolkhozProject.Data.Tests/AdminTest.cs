using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class AdminTest
    {
        private ApplicationContext _context;
        private AdminRepository _adminRepository;
        private TestData _testData;

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Memory-DB")
               .Options;
            _context = new ApplicationContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _adminRepository = new AdminRepository(_context);
            _testData = new TestData();
        }


        [Test]
        public void GetAdminByIdTests()
        {
            //given
            var virtualData = _testData.GetTestAdmin();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            var act = _adminRepository.GetAdminById(virtualData.Id);

            //then
            Assert.IsTrue(virtualData.Id == act.Id);
            Assert.IsNotNull(virtualData);
            Assert.AreEqual(virtualData.LastName, act.LastName);
            Assert.AreEqual(virtualData.Gender, act.Gender);
            Assert.AreEqual(virtualData.BirthDay, act.BirthDay);
            Assert.AreEqual(virtualData.Email, act.Email);
        }

        [Test]
        public void AddNewAdminTests()
        {
            //given
            var virtualData = _testData.AddTestAdmin();

            //when
            var act = _adminRepository.AddNewAdmin(virtualData);

            //then
            Assert.IsNotNull(act);
            Assert.AreEqual(2, act);

        }

        [Test]
        public void UpdateAdminTests()
        {
            //given
            var virtualData = _testData.GetTestAdmin();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            Admin newVirtualData = new Admin();
            {
                newVirtualData.Id = virtualData.Id;
                newVirtualData.Name = "Генрих";
                newVirtualData.LastName = "Ардамонов";
                newVirtualData.Gender = Enums.Gender.Male;
                newVirtualData.BirthDay = new DateTime(1780, 12, 02);

            }
            var act = _adminRepository.UpdateAdminInfo(newVirtualData, virtualData);
            var postAct = _adminRepository.GetAdminById(newVirtualData.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act);
            Assert.AreEqual(newVirtualData.Name, postAct.Name);
            Assert.AreEqual(newVirtualData.LastName, postAct.LastName);
            Assert.AreEqual(newVirtualData.Gender, postAct.Gender);
        }

        [Test]
        public void ChangePasswordAdminTests()
        {
            //given
            var virtualData = _testData.GetTestAdmin();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            Admin newVirtualData = new Admin();
            newVirtualData.Password = "newssss111";

            var act = _adminRepository.ChangePasswordAdmin(newVirtualData.Password, virtualData);
            var postAct = _adminRepository.GetAdminById(virtualData.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act);
            Assert.AreEqual(newVirtualData.Password, postAct.Password);
        }

    }
}
