using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class GetTrainingByLecturerTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            List<Training> trainingList = new()
            {
                new()
                {
                    Id = 1,
                },

                new() 
                { 
                    Id = 2
                },
            };
            
            List<TrainingModel> trainingModelList = new()
            {
                new()
                {
                    Id = 1,
                },

                new() 
                { 
                    Id = 2
                },
            };

            Lecturer lecturer = new()
            {
                Id = 1,
                Trainings = trainingList
            };



            yield return new object[] { lecturer, trainingList, trainingModelList };
        }
    }
}

