using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class ClassroomTest
    {
        private ApplicationContext _context;
        private ClassroomRepository _adminRepository;
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
            _adminRepository = new ClassroomRepository(_context);
            _testData = new TestData();
        }

        [Test]
        public void GetClassroomByIdTests()
        {
            //given
            var virtualData = _testData.GetTestClassroom();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            var act = _adminRepository.GetClassroomById(virtualData.Id);

            //then
            Assert.IsTrue(virtualData.Id == act.Id);
            Assert.IsNotNull(virtualData);
            Assert.AreEqual(virtualData.MembersCount, act.MembersCount);
            Assert.AreEqual(virtualData.Address, act.Address);
            Assert.AreEqual(virtualData.City, act.City);
        }

        //[Test]
        //public void GetClassroomAllTests()
        //{
        //    //given
        //    var virtualData = _testData.GetTestClassroomAll();

        //    // наполняем тестовый БД подкготовленными данными.
        //    for (int i = 0; i < virtualData.Count; i++)
        //    {
        //        _context.Add(virtualData[i]);
        //    }
        //    _context.SaveChanges();

        //    //when
        //    var act = _adminRepository.GetClassroomsAll();


        //    //then
        //    Assert.AreEqual(virtualData.Count, act.Count);
        //    Assert.IsNotNull(act[0]);

        //    for (int i = 0; i < act.Count; i++)
        //    {
        //        Assert.AreEqual(virtualData[i].Id, act[i].Id);
        //        Assert.AreEqual(virtualData[i].City, act[i].City);
        //        Assert.AreEqual(virtualData[i].Address, act[i].Address);
        //        Assert.AreEqual(virtualData[i].MembersCount, act[i].MembersCount);
        //    }
        //}
        [Test]
        public void AddNewClassroomTests()
        {
            //given
            var virtualData = _testData.GetTestClassroomAddModel();

            //when
            var act = _adminRepository.AddNewClassroom(virtualData);

            //then
            Assert.IsNotNull(act);
            Assert.AreEqual(4, act);
        }

        [Test]
        public void DeleteClassroomByIdTests()
        {
            //given
            var virtualData = _testData.GetTestClassroom();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            var act = _adminRepository.DeleteClassroomById(virtualData);

            //then
            Assert.IsNotNull(act);
            Assert.AreEqual(true, act);
        }

        [Test]
        public void UpdateClassroomTests()
        {
            //given
            var virtualData = _testData.GetTestClassroom();
            _context.Add(virtualData);
            _context.SaveChanges();

            //when
            Classroom newVirtualData = new Classroom();
            {
                newVirtualData.Id = virtualData.Id;
                newVirtualData.Address = "Моисеева 90";
                newVirtualData.City = "Сургут";
                newVirtualData.MembersCount = 10;

            }
            var act = _adminRepository.UpdateClassroomInfo(newVirtualData, virtualData);
            var postAct = _adminRepository.GetClassroomById(newVirtualData.Id);

            //then
            Assert.IsNotNull(act);
            Assert.IsTrue(act);
            Assert.AreEqual(newVirtualData.Address, postAct.Address);
            Assert.AreEqual(newVirtualData.MembersCount, postAct.MembersCount);
            Assert.AreEqual(newVirtualData.City, postAct.City);
        }

    }
}
