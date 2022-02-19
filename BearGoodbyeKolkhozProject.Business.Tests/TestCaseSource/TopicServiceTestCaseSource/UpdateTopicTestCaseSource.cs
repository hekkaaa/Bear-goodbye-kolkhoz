using BearGoodbyeKolkhozProject.Business.Models;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TopicServiceTestCaseSource
{
    public class UpdateTopicTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var updateModel = new TopicModel()
            {
                Id = 1,
                Name = "qwert",
                IsDeleted = false
            };

            yield return new object[] { updateModel, 1 };
        }
    }
}
