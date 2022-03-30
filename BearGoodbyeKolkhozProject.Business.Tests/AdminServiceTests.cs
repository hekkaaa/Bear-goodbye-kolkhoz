using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.AdminServiceTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    
    public class AdminServiceTests
    {
        private IMapper _mapper;
        private Mock<IAdminRepository> _adminRepository;
        private Mock<IUserRepository> _userRepository;
        private AdminTestData _adminTestData;
        private AdminService _service;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _adminRepository = new();
            _adminTestData = new();
            _userRepository = new();
            _service = new AdminService(_adminRepository.Object, _userRepository.Object, _mapper);

        }

        [Test]
        public void GetAdminByIdTests()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var expected = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.GetAdminById(entity.Id)).Returns(entity);
            //when
            var service = new AdminService(_adminRepository.Object, _userRepository.Object, _mapper);
            var actual = service.GetAdminById(entity.Id);
            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Gender, actual.Gender);
            Assert.AreEqual(expected.BirthDay, actual.BirthDay);
            _adminRepository.Verify(x => x.GetAdminById(entity.Id), Times.Once);

        }

        [Test]
        public void GetAdminByIdNegativeTestsIfEntityNotFound()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var expected = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.GetAdminById(entity.Id));
            //when
            //then
            Assert.Throws<NotFoundException>(() => _service.GetAdminById(It.IsAny<int>()));

        }

        [Test]
        public void GetAdminsTests()
        {
            //given
            var entityList = _adminTestData.GetEntityList();
            var expected = _adminTestData.GetModelList();
            _adminRepository.Setup(a => a.GetAdminAll()).Returns(entityList);
            //when
            var actual = _service.GetAdminAll();
            //then
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].LastName, actual[i].LastName);
                Assert.AreEqual(expected[i].Gender, actual[i].Gender);
                Assert.AreEqual(expected[i].BirthDay, actual[i].BirthDay);
            }
        }

        [Test]
        public void GetAdminsNegativeTestsIfEntityNotFound()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var expected = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.GetAdminAll());
            //when
            //then
            Assert.Throws<NotFoundException>(() => _service.GetAdminAll());

        }

        [Test]
        public void AddNewAdminTests()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.AddNewAdmin(It.IsAny<Admin>()));
            //when
            var actual = _service.AddNewAdmin(model);
            //then
            _adminRepository.Verify(l => l.AddNewAdmin(It.IsAny<Admin>()), Times.Once);
        }

        [Test]
        public void AddNewAdminNegativeTestsIfEmailDuplicated()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.AddNewAdmin(It.IsAny<Admin>()));
            _userRepository.Setup(a => a.GetUserByEmail(entity.Email)).Returns(entity);
            //when
            //then
            Assert.Throws<DuplicateException>(() => _service.AddNewAdmin(model));
        }

        [Test]
        public void UpdateAdminInfoTests()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.UpdateAdminInfo(It.IsAny<Admin>(), It.IsAny<Admin>()));
            _adminRepository.Setup(a => a.GetAdminById(entity.Id)).Returns(entity);
            //when
            var actual = _service.UpdateAdminInfo(model.Id, model);
            //then
            _adminRepository.Verify(l => l.UpdateAdminInfo(It.IsAny<Admin>(), It.IsAny<Admin>()));
        } 
        
        [Test]
        public void UpdateAdminInfoNegativeTestsIfEntityNotFound()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.UpdateAdminInfo(It.IsAny<Admin>(), It.IsAny<Admin>()));
            _adminRepository.Setup(a => a.GetAdminById(entity.Id));
            //when
            //then
            Assert.Throws<NotFoundException>(() => _service.GetAdminById(model.Id));
        }

        [Test]
        public void ChangeAdminPasswordTests()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.ChangePasswordAdmin(It.IsAny<string>(), It.IsAny<Admin>()));
            _adminRepository.Setup(a => a.GetAdminById(entity.Id)).Returns(entity);
            //when
            var actual = _service.ChangeAdminPassword(model.Id, "");
            //then
            _adminRepository.Verify(l => l.ChangePasswordAdmin(It.IsAny<string>(), It.IsAny<Admin>()));
        }
        
        [Test]
        public void ChangeAdminPasswordNegativeTestsIfEntityNotFount()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.ChangePasswordAdmin(It.IsAny<string>(), It.IsAny<Admin>()));
            _adminRepository.Setup(a => a.GetAdminById(entity.Id));
            //when
            //then
            Assert.Throws<NotFoundException>(() => _service.GetAdminById(model.Id));
        }


    }
}
