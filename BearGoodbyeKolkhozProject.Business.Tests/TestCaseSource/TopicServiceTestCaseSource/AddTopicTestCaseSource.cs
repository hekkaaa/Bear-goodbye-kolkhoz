using BearGoodbyeKolkhozProject.Business.Models;
using System.Collections;


namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TopicServiceTestCaseSource
{
    public class AddTopicTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topic = new TopicModel()
            {
                Id = 1,
                Name = "name",
                IsDeleted = false
            };

            yield return topic;
        }
    }
}
