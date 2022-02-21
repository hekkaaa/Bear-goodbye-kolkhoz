using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.TopicRepositoryTestCaseSource
{
    public class GetTopicsByTrainingIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var training = new List<Training>()
            {   
                new Training()
                {
                     Id = 100,
                MembersCount = 8,
                Duration = 18,
                Price = 1200,
                IsDeleted = false
                }
               
            };

            var topics = new List<Topic>
            {
                new Topic()
                {
                    Id = 100,
                    Name = "name",
                    IsDeleted = false,
                    Training = training
                },
                new Topic()
                {
                    Id = 101,
                    Name = "eman",
                    IsDeleted = true,
                    Training = training
                },
                new Topic()
                {
                    Id = 102,
                    Name = "qwertyui",
                    IsDeleted = false,
                    Training = new List<Training>()
                    {   
                        new Training()
                        {
                             Id = 101,
                        MembersCount = 10,
                        Duration = 20,
                        Price = 1000,
                        IsDeleted = false
                        }
                       
                    }
                }
            };

            var expected = new List<Topic>
            {
                new Topic()
                {
                    Id = 100,
                    Name = "name",
                    IsDeleted = false,
                    Training = training
                },
            };

            yield return new object[] { topics, expected, 100 };
        }
    }
}
