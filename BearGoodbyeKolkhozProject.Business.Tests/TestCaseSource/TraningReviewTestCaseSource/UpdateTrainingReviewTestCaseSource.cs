using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class UpdateTrainingReviewTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            var trainingReviewModel = new TrainingReview
            {
                Id = 666,
                Mark = 666,
                Text = "xxx",
            };

            var updateModel = new TrainingReviewModel
            {
                Mark = 5,
                Text = "hren",
            };

            yield return new object[] { trainingReviewModel, updateModel };

        }
    }
}
