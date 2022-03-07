using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class UpdateTrainingByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var trainingModel = new Training
            {
                Id = 666,
                Name = "666",
                Description = "xxx",
            };

            var updateModel = new TrainingModel
            {
                Name = "666",
                Description = "xxx",
            };

            yield return new object[] { trainingModel, updateModel };
        }
    }
}