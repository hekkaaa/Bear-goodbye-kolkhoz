using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TopicRepositoryTestCaseSource
{
    internal class ChangeDeleteStatusByIdTestCaseSource : IEnumerable
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

            var expected = new Topic()
            {
                Id = 102,
                Name = "qwertyui",
                IsDeleted = true,
                Training = topic.Training
            };

            var expected1 = new Topic()
            {
                Id = 102,
                Name = "qwertyui",
                IsDeleted = false,
                Training = topic.Training
            };

            yield return new object[] { topic, expected, true };
            yield return new object[] { topic, expected1, false };
        }
    }
}
