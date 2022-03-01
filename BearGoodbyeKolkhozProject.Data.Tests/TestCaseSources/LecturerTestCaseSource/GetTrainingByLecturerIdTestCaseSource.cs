using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.LecturerTestCaseSource
{
    public class GetTrainingByLecturerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var lectirer = new Lecturer
            {
                Id = 1,
                Name = "Roma",
                LastName = "Azarov",
                Password = "qwe",
                Email = "123qwe@mail.com",
                BirthDay = "12.12.1999",
                Gender = Enums.Gender.Male,
                Trainings = new List<Training>
                {
                    new Training {
                        Id = 1,
                        Description = "qwertui",
                        Name = "name",
                        MembersCount = 12,
                        Price = 1234,
                        Duration = 123,
                        IsDeleted = false},
                    new Training
                    {
                        Id= 2,
                        Description = "12345",
                        Name = "nbvcxz",
                        MembersCount = 2,
                        Price = 4321,
                        Duration = 321,
                        IsDeleted = false
                    }
                }
            };

            var expected = new List<Training>
            {
                new Training {
                    Id = 1,
                    Description = "qwertui",
                    Name = "name",
                    MembersCount = 12,
                    Price = 1234,
                    Duration = 123,
                    IsDeleted = false},
                new Training
                {
                    Id= 2,
                    Description = "12345",
                    Name = "nbvcxz",
                    MembersCount = 2,
                    Price = 4321,
                    Duration = 321,
                    IsDeleted = false
                }
            };

            yield return new object[] { lectirer, expected };
        }
    }
}
