﻿

using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class DeleteTrainingReviewByIdTestCaseSource : IEnumerable
    {
        IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        public IEnumerator GetEnumerator()
        {

            var entity = new TrainingReview
            {
                Id = 666,
                Mark = 666,
                Text = "xxx",
            };
            
            int id = 666;
         
            yield return new object[] { entity, id };

        }
    }
}
