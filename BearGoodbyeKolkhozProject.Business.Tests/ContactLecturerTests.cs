using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.ContactLecturerTestCaseSource;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class ContactLecturerTests
    {
        private readonly IMapper _mapper;

        public ContactLecturerTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        }

        [TestCaseSource(typeof(AddContactTestCaseSource))]
        public void AddContact(int id, Lecturer lecturer, ContactLecturerModel model)
        {
            //given
            Mock<IContactLecturerRepository> _contactLecturerRepositoryMock = new Mock<IContactLecturerRepository>();
            Mock<ILecturerRepository> _lecturerRepositoryMock = new Mock<ILecturerRepository>();

            _lecturerRepositoryMock.Setup(lr => lr.GetLecturerById(It.IsAny<int>())).Returns(lecturer);
            _contactLecturerRepositoryMock.Setup(cl => cl.AddContact(It.IsAny<ContactLecturer>()));

            //when
            ContactLecturerService _service = new ContactLecturerService(_contactLecturerRepositoryMock.Object , _mapper, _lecturerRepositoryMock.Object);
            _service.AddContact(id, model);

            //then
            _lecturerRepositoryMock.Verify(x => x.GetLecturerById(It.IsAny<int>()), Times.Once);
            _contactLecturerRepositoryMock.Verify(x => x.AddContact(It.IsAny<ContactLecturer>()), Times.Once);
        }

        [Test]
        public void AddContact_WhenLecturerNotFoundInDataBase_ShouldThrowNotFoundException()
        {
            //given
            Mock<ILecturerRepository> _lecturerRepositoryMock = new Mock<ILecturerRepository>();
            Mock<IContactLecturerRepository> _contactLecturerRepositoryMock = new Mock<IContactLecturerRepository>();

            _lecturerRepositoryMock.Setup(lr => lr.GetLecturerById(It.IsAny<int>())).Returns((Lecturer)null);
            _contactLecturerRepositoryMock.Setup(cl => cl.AddContact(It.IsAny<ContactLecturer>()));



            //when
            ContactLecturerService _service = new ContactLecturerService(_contactLecturerRepositoryMock.Object, _mapper, _lecturerRepositoryMock.Object);


            //then
            Assert.Throws<NotFoundException>(() => _service.AddContact(It.IsAny<int>(), It.IsAny<ContactLecturerModel>()));

            _lecturerRepositoryMock.Verify(x => x.GetLecturerById(It.IsAny<int>()), Times.Once);
        }

        [TestCaseSource(typeof(UpdateContactTestCaseSource))]
        public void UpdateContact(int id, ContactLecturerModel model, ContactLecturer contact)
        {
            //given
            Mock<IContactLecturerRepository> _contactLecturerRepositoryMock = new Mock<IContactLecturerRepository>();
            Mock<ILecturerRepository> _lecturerRepositoryMock = new Mock<ILecturerRepository>();

            _contactLecturerRepositoryMock.Setup(cl => cl.UpdateContact(It.IsAny<ContactLecturer>(), It.IsAny<ContactLecturer>()));
            _contactLecturerRepositoryMock.Setup(cl => cl.GetValueContactLecturerById(id)).Returns(contact);
            //when
            ContactLecturerService _service = new ContactLecturerService(_contactLecturerRepositoryMock.Object, _mapper, _lecturerRepositoryMock.Object);
            _service.UpdateContact(id, model);

            //then
            _contactLecturerRepositoryMock.Verify(x => x.UpdateContact(It.IsAny<ContactLecturer>(), It.IsAny<ContactLecturer>()), Times.Once);
        }
    }
}
