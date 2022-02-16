﻿

using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class AddTrainingReviewTestCaseSource : IEnumerable
    {
        IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        public IEnumerator GetEnumerator()
        {
            var trainingReviewModel = new TrainingReviewModel
            {
              Id = 666,
              Mark = 666,
              Text = "xxx",
            };

            yield return new object[] { trainingReviewModel };

        }
    }
}
