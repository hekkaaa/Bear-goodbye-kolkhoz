using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class AddTrainingToLecturerTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Training training = new()
            {
                Id = 1,
            };

            Lecturer lecturer = new()
            {
                Id = 1,
                Trainings = new List<Training>()
            };

            LecturerModel lecturerModel = new()
            {
                Id = 1,
                Trainings = new List<TrainingModel>()
            };

            yield return new object[] { training, lecturer, lecturerModel };
        }
    }
}

