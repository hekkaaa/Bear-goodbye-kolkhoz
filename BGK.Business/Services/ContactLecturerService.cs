using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class ContactLecturerService : IContactLecturerService
    {
        private readonly IContactLecturerRepository _contactLecturerRepository;

        private IMapper _mapper;

        public ContactLecturerService(IContactLecturerRepository contactLecturerRepository, IMapper mapper)
        {
            _contactLecturerRepository = contactLecturerRepository;
            _mapper = mapper;
        }

        public void AddContactLecturerValue(ContactLecturerModel сontactLecturerModel)
        {
            var mappedLecturer = new ContactLecturerModel { Value = сontactLecturerModel.Value };

            _contactLecturerRepository.AddContact(_mapper.Map<ContactLecturer>(mappedLecturer));
        }

        public void UpdateContactLecturerValue(ContactLecturerModel сontactLecturerModel)
        {
            var contactLecturer = _contactLecturerRepository.GetValueContactLecturerById(сontactLecturerModel.Id);

            if (contactLecturer == null)
                throw new BusinessException("Такой значения не существует.");

            var mappedLecturer = new ContactLecturerModel { Value = сontactLecturerModel.Value };

            //_contactLecturerRepository.UpdateContact(_mapper.Map<ContactLecturer>(mappedLecturer));

        }
    }
}
