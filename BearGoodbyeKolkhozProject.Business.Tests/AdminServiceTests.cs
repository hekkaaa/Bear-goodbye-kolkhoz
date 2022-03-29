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
        private readonly IMapper _mapper;
        private Mock<IAdminRepository> _adminRepository;
        private Mock<IUserRepository> _userRepository;
        private AdminTestData _adminTestData;
        public AdminServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _adminRepository = new();
            _adminTestData = new();
            _userRepository = new();
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
        public void GetAdminsTests()
        {
            //given
            var entityList = _adminTestData.GetEntityList();
            var expected = _adminTestData.GetModelList();
            _adminRepository.Setup(a => a.GetAdminAll()).Returns(entityList);
            //when
            var service = new AdminService(_adminRepository.Object, _userRepository.Object, _mapper);
            var actual = service.GetAdminAll();
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
        public void AddNewAdminTests()
        {
            //given
            var entity = _adminTestData.GetEntity();
            var model = _adminTestData.GetModel();
            _adminRepository.Setup(a => a.AddNewAdmin(It.IsAny<Admin>()));
            //when
            var service = new AdminService(_adminRepository.Object, _userRepository.Object, _mapper);
            var actual = service.AddNewAdmin(model);
            //then
            _adminRepository.Verify(l => l.AddNewAdmin(It.IsAny<Admin>()), Times.Once);
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
            var service = new AdminService(_adminRepository.Object, _userRepository.Object, _mapper);
            var actual = service.UpdateAdminInfo(model.Id, model);
            //then
            _adminRepository.Verify(l => l.UpdateAdminInfo(It.IsAny<Admin>(), It.IsAny<Admin>()));
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
            var service = new AdminService(_adminRepository.Object, _userRepository.Object, _mapper);
            var actual = service.ChangeAdminPassword(model.Id, "");
            //then
            _adminRepository.Verify(l => l.ChangePasswordAdmin(It.IsAny<string>(), It.IsAny<Admin>()));
        }


    }
}
