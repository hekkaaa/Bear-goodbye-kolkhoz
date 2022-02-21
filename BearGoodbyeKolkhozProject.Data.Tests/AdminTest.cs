using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
        public void GetAdminAllTests()
        {
            //given
            var preVirtualData = _testData.GetTestAdminAll();
            List<Entities.Admin> postVirtualData = new List<Entities.Admin>();

            // наполняем тестовый БД подкготовленными данными.
            for (int i = 0; i < preVirtualData.Count; i++)
            {
                if (!preVirtualData[i].IsDeleted)
                {   // исключаем данные с IsDeleted = true
                    _context.Add(preVirtualData[i]);
                    postVirtualData.Add(preVirtualData[i]);
                }
            }
            _context.SaveChanges();

            //when
            var act = _adminRepository.GetAdminAll();


            //then
            Assert.AreEqual(2, act.Count);
            Assert.IsNotNull(act[0]);

            for (int i = 0; i < act.Count; i++)
            {
                Assert.AreEqual(postVirtualData[i].Id, act[i].Id);
                Assert.AreEqual(postVirtualData[i].Name, act[i].Name);
                Assert.AreEqual(postVirtualData[i].BirthDay, act[i].BirthDay);
                Assert.AreEqual(postVirtualData[i].Email, act[i].Email);
                Assert.AreEqual(postVirtualData[i].Gender, act[i].Gender);
                Assert.AreEqual(postVirtualData[i].Password, act[i].Password);
                Assert.AreEqual(postVirtualData[i].IsDeleted, act[i].IsDeleted);
            }
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
            Assert.AreEqual(1, act);
        }

        [Test]
        public void DeleteAdminByIdTests()
        {
            //given
            var virtualData = _testData.GetTestAdmin();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            var act = _adminRepository.DeleteAdminById(virtualData.Id);
            var postAct = _adminRepository.GetAdminById(virtualData.Id);

            //then
            Assert.IsNotNull(act);
            Assert.AreEqual(true, act);
            Assert.AreEqual(true, postAct.IsDeleted);
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
                newVirtualData.BirthDay = "02-12-1780";

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

            var act = _adminRepository.ChangePasswordAdmin(newVirtualData.Password, newVirtualData);
            var postAct = _adminRepository.GetAdminById(virtualData.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act);
            Assert.AreEqual(newVirtualData.Password, postAct.Password);
        }

        [Test]
        public void RecoverAdminByIdTests()
        {
            //given
            var virtualData = _testData.GetTestAdmin();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            var act = _adminRepository.RecoverAdminById(virtualData.Id);
            var postAct = _adminRepository.GetAdminById(virtualData.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act);
            Assert.AreEqual(true, postAct.IsDeleted);
        }

    }
}
