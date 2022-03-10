using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class DeleteTrainingByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var training = new Training
            {

                Id = 666,
                Name = "666",
                Description = "xxx",
            };
            yield return new object[] { training };
        }
    }
}