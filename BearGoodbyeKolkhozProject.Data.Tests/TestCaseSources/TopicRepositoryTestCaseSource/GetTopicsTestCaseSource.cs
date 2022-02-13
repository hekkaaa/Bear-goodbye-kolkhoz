using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections.Generic;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TopicRepositoryTestCaseSource
{
    public class GetTopicsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topics = new List<Topic>
            {
                new Topic()
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
                },
                new Topic()
                {
                    Id = 101,
                    Name = "eman",
                    IsDeleted = false,
                    Training = new Training()
                    {
                        Id = 101,
                        MembersCount = 8,
                        Duration =  18,
                        Price = 1200,
                        IsDeleted = false
                    }
                },
            };

            var expected = new List<Topic>
            {
                new Topic()
                {
                    Id = 100,
                    Name = "name",
                    IsDeleted = false,
                    Training = topics[0].Training
                },
                new Topic()
                {
                    Id = 101,
                    Name = "eman",
                    IsDeleted = false,
                    Training = topics[1].Training
                },
            };

            yield return new object[] { topics, expected };
            yield return new object[] { new List<Topic>(), new List<Topic>() };
        }
    }
}
