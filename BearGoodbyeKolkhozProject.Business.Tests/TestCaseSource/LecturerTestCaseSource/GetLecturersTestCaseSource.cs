using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class GetLecturersTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            List<Event> events = new()
            {
                new Event()
                {
                    Id = 1
                },
                new Event()
                {
                    Id = 1
                }
            };

            List<EventModel> eventModels = new()
            {
                new EventModel()
                {
                    Id = 1
                },
                new EventModel()
                {
                    Id = 1
                }
            };

            List<Lecturer> lecturers = new()
            {
                new Lecturer()
                {
                    Id = 111,
                    Name = "fff",
                    LastName = "fff",
                    BirthDay = DateTime.Now,
                    Email = "l",
                    Gender = Data.Enums.Gender.Male,
                    Events = events
                },
                new Lecturer()
                {
                    Id = 112,
                    Name = "fff",
                    LastName = "fff",
                    BirthDay = DateTime.Now,
                    Email = "l",
                    Gender = Data.Enums.Gender.Male,
                    Events = events
                },
            };


            List<LecturerModel> lecturerModels = new()
            {
                new LecturerModel()
                {
                    Id = 111,
                    Name = "fff",
                    LastName = "fff",
                    BirthDay = DateTime.Now,
                    Email = "l",
                    Gender = Data.Enums.Gender.Male,
                    Events = eventModels
                },
                new LecturerModel()
                {
                    Id = 112,
                    Name = "fff",
                    LastName = "fff",
                    BirthDay = DateTime.Now,
                    Email = "l",
                    Gender = Data.Enums.Gender.Male,
                    Events = eventModels
                },
            };



            yield return new object[] { lecturers, lecturerModels };

        }
    }
}