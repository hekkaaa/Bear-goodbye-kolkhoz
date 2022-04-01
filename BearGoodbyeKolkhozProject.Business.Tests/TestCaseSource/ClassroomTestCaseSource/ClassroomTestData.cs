using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.ClassroomTestCaseSource
{
    public class ClassroomTestData
    {
        public Classroom GetEntity()
        {
            return new Classroom()
            {
                Id = 1,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30
            };
        }

        public ClassroomModel GetModel()
        {
            return new ClassroomModel()
            {
                Id = 1,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30
            };
        }

        public List<ClassroomModel> GetModelList()
        {
            return new List<ClassroomModel>()
            {
                new()
                {
                Id = 1,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30 
                },
                new()
                {
                Id = 2,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30 
                },
                new()
                {
                Id = 3,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30 
                }

            };
        } 
        
        public List<Classroom> GetEntityList()
        {
            return new List<Classroom>()
            {
                new()
                {
                Id = 1,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30 
                },
                new()
                {
                Id = 2,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30 
                },
                new()
                {
                Id = 3,
                Address = "",
                City = "",
                IsDeleted = false,
                MembersCount = 30 
                }

            };
        }
    }
}
