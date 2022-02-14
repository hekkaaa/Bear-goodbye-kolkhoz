using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddValue(ContactLecturerModel сontactLecturerModel)
        {
            var mappedLecturer = new ContactLecturerModel { Value = сontactLecturerModel.Value };

            _contactLecturerRepository.AddValue(_mapper.Map<ContactLecturer>(mappedLecturer));
        }
    }
}
