using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.LecturerReviewTestCaseSource
{
    public class AddLecturerReviewTestCaseSource : IEnumerable
    {
        IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));

        public IEnumerator GetEnumerator()
        {
            var client = new Client
            {
                Id = 111,
                Name = "qwe123",
                LastName = "321ewq",
                Gender = Gender.Male,
                BirthDay = "11.11.2000",
                Email = "123qwe@mail.com",
                PhoneNumber = "77777777777",
                Password = "qwe!23",
                IsDeleted = false
            };

            var lecturer = new Lecturer()
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                BirthDay = "12.12.1999",
                Gender = Gender.Male,
            };

            var reviewModel = new LecturerReviewModel()
            {
                Id = 200,
                Text = "ewq",
                Mark = 4,
                Client = _mapper.Map<ClientModel>(client),
                LecturerModel = _mapper.Map<LecturerModel>(lecturer)
            };

            yield return new object[] { reviewModel };
        }
    }
}
