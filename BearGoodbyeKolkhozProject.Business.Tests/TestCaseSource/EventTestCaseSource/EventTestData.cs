using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.EventTestCaseSource
{
    public class EventTestData
    {
        public Classroom GetClassroom()
        {
            return new()
            {
                Id = 1
            };
        }

        public Lecturer GetLecturer()
        {
            return new()
            {
                Id = 1
            };
        }

        public Training GetTraining()
        {
            return new()
            {
                Id = 1
            };
        }

        public ClassroomModel GetClassroomModel()
        {
            return new()
            {
                Id = 1
            };
        }

        public LecturerModel GetLecturerModel()
        {
            return new()
            {
                Id = 1
            };
        }

        public TrainingModel GetTrainingModel()
        {
            return new()
            {
                Id = 1
            };
        }

        public Event GetEntity()
        {
            return new Event()
            {
                Id = 1,
                StartDate = DateTime.Today,
                Classroom = GetClassroom(),
                Lecturer = GetLecturer(),
                IsDeleted = false,
                Training = GetTraining()
            };
        }

        public List<Event> GetEntityList()
        {
            return new List<Event>()
            {
                new(){
                Id = 1,
                StartDate = DateTime.Today,
                Classroom = GetClassroom(),
                Lecturer = GetLecturer(),
                IsDeleted = false,
                Training = GetTraining()
                },
                new(){
                Id = 2,
                StartDate = DateTime.Today,
                Classroom = GetClassroom(),
                Lecturer = GetLecturer(),
                IsDeleted = false,
                Training = GetTraining()
                },
                new(){
                Id = 3,
                StartDate = DateTime.Today,
                Classroom = GetClassroom(),
                Lecturer = GetLecturer(),
                IsDeleted = false,
                Training = GetTraining()
                },
            };
        }

        public EventModel GetModel()
        {
            return new()
            {
                Id = 1,
                StartDate = DateTime.Today,
                Classroom = GetClassroomModel(),
                Lecturer = GetLecturerModel(),
                IsDeleted = false,
                Training = GetTrainingModel()
            };
        } 
        
        public List<EventModel> GetModelList()
        {
            return new()
            {
                new()
                {
                    Id = 1,
                    StartDate = DateTime.Today,
                    Classroom = GetClassroomModel(),
                    Lecturer = GetLecturerModel(),
                    IsDeleted = false,
                    Training = GetTrainingModel()
                },
                new()
                {
                    Id = 2,
                    StartDate = DateTime.Today,
                    Classroom = GetClassroomModel(),
                    Lecturer = GetLecturerModel(),
                    IsDeleted = false,
                    Training = GetTrainingModel()
                },
                new()
                {
                    Id = 3,
                    StartDate = DateTime.Today,
                    Classroom = GetClassroomModel(),
                    Lecturer = GetLecturerModel(),
                    IsDeleted = false,
                    Training = GetTrainingModel()
                }
            };
        }
    }
}
