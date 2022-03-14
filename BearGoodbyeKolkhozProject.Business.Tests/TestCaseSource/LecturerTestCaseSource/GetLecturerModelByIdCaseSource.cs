using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class GetLecturerModelByIdCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lecturer = new Lecturer()
            {
                Id = 111,
                Name = "fff",
                LastName = "fff",
                BirthDay = DateTime.Now,
                Email = "l",
                Gender = Data.Enums.Gender.Male
            };
            
            var lecturerModel = new LecturerModel()
            {
                Id = 111,
                Name = "fff",
                LastName = "fff",
                BirthDay = DateTime.Now,
                Email = "l",
                Gender = Data.Enums.Gender.Male
            };

            int id = 111;
            
            yield return new object[] { lecturer, lecturerModel, id };

        }
    }
}