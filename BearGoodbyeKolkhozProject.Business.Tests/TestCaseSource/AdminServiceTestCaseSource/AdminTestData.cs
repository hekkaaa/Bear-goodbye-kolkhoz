using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;


namespace BearGoodbyeKolkhozProject.Business.Tests.TestCaseSource.AdminServiceTestCaseSource
{
    public class AdminTestData
    {
        public Admin GetEntity()
        {
            return new()
            {
                Id = 1,
                BirthDay = DateTime.Today,
                Email = "",
                Gender = Data.Enums.Gender.Male,
                IsDeleted = false,
                LastName = "",
                Name = "",
                Password = "",
                Role = Data.Enums.Role.Admin
            };
        }
        public List<Admin> GetEntityList()
        {
            return new()
            {
                new()
                {
                    Id = 1,
                    BirthDay = DateTime.Today,
                    Email = "",
                    Gender = Data.Enums.Gender.Male,
                    IsDeleted = false,
                    LastName = "",
                    Name = "",
                    Password = "",
                    Role = Data.Enums.Role.Admin
                },
                new()
                {
                    Id = 2,
                    BirthDay = DateTime.Today,
                    Email = "",
                    Gender = Data.Enums.Gender.Male,
                    IsDeleted = false,
                    LastName = "",
                    Name = "",
                    Password = "",
                    Role = Data.Enums.Role.Admin
                },
                new()
                {
                    Id = 3,
                    BirthDay = DateTime.Today,
                    Email = "",
                    Gender = Data.Enums.Gender.Male,
                    IsDeleted = false,
                    LastName = "",
                    Name = "",
                    Password = "",
                    Role = Data.Enums.Role.Admin
                }
            };
        }

        public AdminModel GetModel()
        {
            return new()
            {
                Id = 1,
                BirthDay = DateTime.Today,
                Email = "",
                Gender = Data.Enums.Gender.Male,
                IsDeleted = false,
                LastName = "",
                Name = "",
                Password = ""
            };
        }

        public List<AdminModel> GetModelList()
        {
            return new()
            {
                new()
                {
                    Id = 1,
                    BirthDay = DateTime.Today,
                    Email = "",
                    Gender = Data.Enums.Gender.Male,
                    IsDeleted = false,
                    LastName = "",
                    Name = "",
                    Password = ""
                },
                new()
                {
                    Id = 2,
                    BirthDay = DateTime.Today,
                    Email = "",
                    Gender = Data.Enums.Gender.Male,
                    IsDeleted = false,
                    LastName = "",
                    Name = "",
                    Password = ""
                },
                new()
                {
                    Id = 3,
                    BirthDay = DateTime.Today,
                    Email = "",
                    Gender = Data.Enums.Gender.Male,
                    IsDeleted = false,
                    LastName = "",
                    Name = "",
                    Password = ""
                }
            };
        }
    }
}
