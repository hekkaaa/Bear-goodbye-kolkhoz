using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TopicRepositoryTestCaseSource
{
    public class UpdateTopicTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topic = new Topic()
            {
                Id = 102,
                Name = "qwertyui",
                IsDeleted = false,
                Training = new Training()
                {
                    Id = 101,
                    MembersCount = 10,
                    Duration = 20,
                    Price = 1000,
                    IsDeleted = false
                }
            };

            var updateModel = new Topic()
            {
                Id = 102,
                Name = "123",
                IsDeleted = true,
                Training = topic.Training
            };

            var expected = new Topic()
            {
                Id = 102,
                Name = "123",
                IsDeleted = false,
                Training = updateModel.Training
            };

            yield return new object[] { topic, updateModel, expected };
            //yield return new object[] { topic, topic, topic };
        }
    }
}
