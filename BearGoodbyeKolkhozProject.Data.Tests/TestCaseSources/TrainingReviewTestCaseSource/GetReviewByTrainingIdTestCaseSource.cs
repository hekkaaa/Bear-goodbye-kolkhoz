using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections.Generic;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TrainingReviewTestCaseSource
{
    public class GetReviewByTrainingIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Training training = new Training()
            {
                Id = 1
            };

            Client client = new Client()
            {
                Id = 1,
                Email = "qqq@mail.ru",
                Password = "qqq"
            };

            TrainingReview first = new TrainingReview()
            {
                Id = 1,
                Client = client,
                Training = training,
                Text = "лорем ипсум",
                Mark = 5
            };

            TrainingReview second = new TrainingReview()
            {
                Id = 2,
                Client = client,
                Training = training,
                Text = "тут рыбатекст",
                Mark = 4
            };

            List<TrainingReview> reviews = new List<TrainingReview>()
            {
                first,
                second,
                new TrainingReview()
                {
                    Id = 3,
                    Client = client,
                    Training = new Training()
                    {
                        Id = 2
                    },
                    Text = "тут рыбатекст2",
                    Mark = 5
                }
            };

            List<TrainingReview> expected = new List<TrainingReview>()
            {
                first,
                second
            };

            yield return new object[] { 1, reviews, expected };
        }
    }
}
