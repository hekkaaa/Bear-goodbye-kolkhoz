﻿using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.ClassroomTestCaseSource;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.UserTestCaseSource;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class ClassroomServiceTests
    {

        private readonly IMapper _mapper;
        private Mock<IClassroomRepository> _classroomRepository;
        private ClassroomTestData _classroomTestData;


        public ClassroomServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
            _classroomRepository = new Mock<IClassroomRepository>();
            _classroomTestData = new ClassroomTestData();
        }

        [Test]
        public void GetClassroomByIdTests()
        {
            //given
            var entity = _classroomTestData.GetEntity();
            var expectedModel = _classroomTestData.GetModel();
            _classroomRepository.Setup(c => c.GetClassroomById(entity.Id)).Returns(entity);

            //when
            ClassroomService service = new ClassroomService(_classroomRepository.Object, _mapper);
            var actual = service.GetClassroomById(entity.Id);

            //then
            Assert.AreEqual(actual.Id, expectedModel.Id);
            Assert.AreEqual(actual.City, expectedModel.City);
            Assert.AreEqual(actual.Address, expectedModel.Address);
            Assert.AreEqual(actual.IsDeleted, expectedModel.IsDeleted);
            _classroomRepository.Verify(c => c.GetClassroomById(entity.Id), Times.Once);
        }

        [Test]
        public void GetClassroomAllTests()
        {
            //given
            var entityList = _classroomTestData.GetEntityList();
            var expectedModelList = _classroomTestData.GetModelList();
            _classroomRepository.Setup(c => c.GetClassroomsAll()).Returns(entityList);

            //when
            ClassroomService service = new ClassroomService(_classroomRepository.Object, _mapper);
            var actual = service.GetClassroomAll();

            //then
            for (int i = 0; i < expectedModelList.Count; i++)
            {
                Assert.AreEqual(actual[i].Id, expectedModelList[i].Id);
                Assert.AreEqual(actual[i].City, expectedModelList[i].City);
                Assert.AreEqual(actual[i].Address, expectedModelList[i].Address);
                Assert.AreEqual(actual[i].IsDeleted, expectedModelList[i].IsDeleted);
            }
            _classroomRepository.Verify(c => c.GetClassroomsAll(), Times.Once);
        }

        [Test]
        public void AddClassroomTests()
        {
            //given
            var entity = _classroomTestData.GetEntity();
            var model = _classroomTestData.GetModel();
            _classroomRepository.Setup(c => c.AddNewClassroom(It.IsAny<Classroom>()));

            //when
            ClassroomService service = new ClassroomService(_classroomRepository.Object, _mapper);
            var actual = service.AddNewClassroom(model);

            //then
            _classroomRepository.Verify(c => c.AddNewClassroom(It.IsAny<Classroom>()), Times.Once);
        }
        
        [Test]
        public void DeleteClassroomTests()
        {
            //given
            var entity = _classroomTestData.GetEntity();
            var model = _classroomTestData.GetModel();
            _classroomRepository.Setup(c => c.GetClassroomById(entity.Id)).Returns(entity);
            _classroomRepository.Setup(c => c.UpdateClassroomInfo(entity, true));

            //when
            ClassroomService service = new ClassroomService(_classroomRepository.Object, _mapper);
            var actual = service.DeleteClassroom(model.Id);

            //then
            _classroomRepository.Verify(c => c.GetClassroomById(entity.Id), Times.Once);
            _classroomRepository.Verify(c => c.UpdateClassroomInfo(entity, true), Times.Once);
        }
        
        [Test]
        public void RestoreClassroomTests()
        {
            //given
            var entity = _classroomTestData.GetEntity();
            var model = _classroomTestData.GetModel();
            _classroomRepository.Setup(c => c.GetClassroomById(entity.Id)).Returns(entity);
            _classroomRepository.Setup(c => c.UpdateClassroomInfo(entity, false));

            //when
            ClassroomService service = new ClassroomService(_classroomRepository.Object, _mapper);
            var actual = service.RestoreClassroom(model.Id);

            //then
            _classroomRepository.Verify(c => c.GetClassroomById(entity.Id), Times.Once);
            _classroomRepository.Verify(c => c.UpdateClassroomInfo(entity, false), Times.Once);
        }
        
        [Test]
        public void UpdateClassroomInfoTests()
        {
            //given
            var entity = _classroomTestData.GetEntity();
            var newEntity = entity;
            newEntity.City = "xxx";
            var model = _classroomTestData.GetModel();
            var newModel = model;
            newModel.City = "xxx";
            _classroomRepository.Setup(c => c.GetClassroomById(entity.Id)).Returns(entity);
            _classroomRepository.Setup(c => c.UpdateClassroomInfo(It.IsAny<Classroom>(), It.IsAny<Classroom>()));

            //when
            ClassroomService service = new ClassroomService(_classroomRepository.Object, _mapper);
            var actual = service.UpdateClassroomInfo(model.Id, newModel);

            //then
            _classroomRepository.Verify(c => c.GetClassroomById(entity.Id), Times.Once);
            _classroomRepository.Verify(c => c.UpdateClassroomInfo(It.IsAny<Classroom>(), It.IsAny<Classroom>()), Times.Once);
        }
    }

}
