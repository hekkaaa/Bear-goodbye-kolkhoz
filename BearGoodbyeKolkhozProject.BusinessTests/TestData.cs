﻿using BearGoodbyeKolkhozProject.Business.Models;

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
