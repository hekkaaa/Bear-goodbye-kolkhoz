using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TrainingTestCaseSource
{
    public class GetTrainingByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topics = new List<Topic>()
            {
                new Topic()
                {
                    Id = 1,
                    Name = "ff"
                }
            };

            var topicModel = new List<TopicModel>()
            {
                new TopicModel()
                {
                    Id = 1,
                    Name = "ff"
                }
            };

            var entity = new Training
            {
                Id = 666,
                Name = "choooo",
                Description = "dolgii description",
                Duration = 30,
                IsDeleted = false,
                MembersCount = 30,
                Price = 5000,
                Topics = topics,
            };

            var expected = new TrainingModel
            {
                Id = 666,
                Name = "choooo",
                Description = "dolgii description",
                Duration = 30,
                IsDeleted = false,
                MembersCount = 30,
                Price = 5000,
                Topics = topicModel
            };

            int id = 666;

            yield return new object[] { entity, expected, id };
        }

    }
}
