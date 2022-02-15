﻿using AutoMapper;
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

            var review = new LecturerReview()
            {
                Id = 200,
                Text = "ewq",
                Mark = 4,
                Client = client
            };

            var expected = new LecturerReviewModel()
            {
                Id = 200,
                Text = "ewq",
                Mark = 4,
                Client = _mapper.Map<ClientModel>(client)
            };

            yield return new object[] { review, expected };
        }
    }
}
