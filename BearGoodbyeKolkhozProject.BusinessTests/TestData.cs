using BearGoodbyeKolkhozProject.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TestData
    {
        public TrainingModel GetTrainingModel()
        {
            var trainingModel = new TrainingModel
            {
                Id = 4,
                Description = "xxx",
                Duration = 40,
                MembersCount = 666,
                Name = "yyy",
                Price = 50000,

            };

            return trainingModel;
        }

        public TopicModel GetTopicModel()
        {
            return new TopicModel
            {
                Name = "hhh",
            };
        }

    }
}
