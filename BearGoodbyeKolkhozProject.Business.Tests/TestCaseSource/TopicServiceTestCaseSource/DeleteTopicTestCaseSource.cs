using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TopicServiceTestCaseSource
{
    public class DeleteTopicTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topic = new Topic()
            {
                Id = 1,
                Name = "name",
                IsDeleted = false
            };

            var model = new TopicModel()
            {
                Id = 1,
                Name = "name",
                IsDeleted = false
            };

            yield return new object[] { topic, model, 1 };
        }
    }
}
