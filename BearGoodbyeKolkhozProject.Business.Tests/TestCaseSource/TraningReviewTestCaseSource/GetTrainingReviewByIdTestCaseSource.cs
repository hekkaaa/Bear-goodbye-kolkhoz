using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class GetTrainingReviewByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            var entity = new TrainingReview
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

            yield return new object[] { entity, expected, id };

        }
    }
}
