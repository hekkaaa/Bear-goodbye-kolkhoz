

using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class GetTrainingReviewsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            var trainingReviews = new List<TrainingReview>
            {
               new TrainingReview()
               {
                Id = 1,
                Mark = 666,
                Text = "xxx",
               },
               new TrainingReview()
               {
                   Id = 2,
                   Mark = 42,
                   Text = "khhh",
               }

            };
            var expected = new List<TrainingReviewModel>
            {
               new TrainingReviewModel()
               {
                Id = 1,
                Mark = 666,
                Text = "xxx",
               },
               new TrainingReviewModel()
               {
                   Id = 2,
                   Mark = 42,
                   Text = "khhh",
               }

            };

            yield return new object[] { trainingReviews, expected};

        }
    }
}
