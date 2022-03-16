using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class ContactLecturerService : IContactLecturerService
    {
        private readonly IContactLecturerRepository _contactLecturerRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private IMapper _mapper;

        public ContactLecturerService(IContactLecturerRepository contactLecturerRepository, IMapper mapper, ILecturerRepository lecturerRepository)
        {
            _contactLecturerRepository = contactLecturerRepository;
            _lecturerRepository = lecturerRepository;
            _mapper = mapper;
        }

        public void AddContact(int lecturerId, ContactLecturerModel сontactLecturerModel)
        {
            var contact = _mapper.Map<ContactLecturer>(сontactLecturerModel);
            Lecturer lecturer = _lecturerRepository.GetLecturerById(lecturerId);

            if (lecturer is null)
            {
                throw new NotFoundException($"Нет тренера с id = {lecturerId}");
            }

            contact.Lecturer = lecturer;
            _contactLecturerRepository.AddContact(contact);
        }

        public void UpdateContact(int id, ContactLecturerModel сontactLecturerModel)
        {
            var contact = _contactLecturerRepository.GetValueContactLecturerById(id);

            if (contact is null)
            {
                throw new NotFoundException($"Нет контакта с id = {id}");
            }

            _contactLecturerRepository.UpdateContact(contact, _mapper.Map< ContactLecturer>(сontactLecturerModel));

        }
    }
}
