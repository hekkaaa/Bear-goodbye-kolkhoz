using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TopicRepositoryTestCaseSource
{
    public class GetTopicByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topic = new Topic()
            {
                Id = 100,
                Name = "name",
                IsDeleted = false,
                Training = new Training()
                {
                    Id = 100,
                    MembersCount = 8,
                    Duration =  18,
                    Price = 1200,
                    IsDeleted = false
                }
            };

            var expected = new Topic()
            {
                Id = 100,
                Name = "name",
                IsDeleted = false,
                Training = topic.Training
            };

            yield return new object[] { topic, expected, 100 };
            //так ведь можно? :)
            yield return new object[] { topic, null, -1 };
        }
    }
}
