using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections.Generic;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.TopicServiceTestCaseSource
{
    public class GetTopicsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var topics = new List<Topic>()
            {
                new Topic()
                {
                    Id = 1,
                    Name = "name",
                    IsDeleted = false
                },
                new Topic()
                {
                    Id = 2,
                    Name = "qwe",
                    IsDeleted = false
                }
            };

            var expected = new List<TopicModel>()
            {
                new TopicModel()
                {
                    Id = 1,
                    Name = "name",
                    IsDeleted = false
                },
                new TopicModel()
                {
                    Id = 2,
                    Name = "qwe",
                    IsDeleted = false
                },
            };

            yield return new object[] { topics, expected };
        }
    }
}
