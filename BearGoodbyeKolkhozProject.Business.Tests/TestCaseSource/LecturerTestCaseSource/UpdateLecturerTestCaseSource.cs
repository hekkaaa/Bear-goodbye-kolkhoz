using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class UpdateLecturerTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
          
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

            yield return new object[] { lecturer, lecturerModel };
        }
    }
}

