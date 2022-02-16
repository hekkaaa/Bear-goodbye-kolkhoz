

using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class GetTrainingReviewByIdTestCaseSource : IEnumerable
    {
        IMapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessMapperProfile>()));
        public IEnumerator GetEnumerator()
        {

            var trainingReviewModel = new TrainingReview
            {
                Id = 666,
                Mark = 666,
                Text = "xxx",
            };
            
            var expected = new TrainingReviewModel
            {
                Id = 666,
                Mark = 666,
                Text = "xxx",
            };

            int id = 666;
         
            yield return new object[] { trainingReviewModel, expected, id };

        }
    }
}
