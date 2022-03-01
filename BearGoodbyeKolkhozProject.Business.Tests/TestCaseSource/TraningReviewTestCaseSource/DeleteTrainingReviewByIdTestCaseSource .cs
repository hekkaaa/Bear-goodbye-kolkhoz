using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TraningTestCaseSource
{
    public class DeleteTrainingReviewByIdTestCaseSource : IEnumerable
    {
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
