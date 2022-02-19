using BearGoodbyeKolkhozProject.Data.Entities;
using System.Collections.Generic;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class TestData
    {
        public Client GetTestClient()
        {
            return new Client
            {
                Name = "Sacha",
                LastName = "Vygrebyuk",
                BirthDay = "22.07.2003",
                Email = "jjj@jjj.jjj",
                Password = "********",
                Gender = Enums.Gender.Male,
                PhoneNumber = "999999999",
            };
        }

        public TrainingReview GetTestTrainingReview()
        {
            return new TrainingReview
            {
                Text = "тренинг супер!!! там мегапопулярный препод Антон Негодяй!!! класно ведёт чотко)))",
                Mark = 10,
                Client = GetTestClient(),
                Training = new Training
                {
                    Name = "Супер чоткий тренинг",
                    Description = "Как базарить на районе",
                    Duration = 5,
                    MembersCount = 50,
                    Price = 5000,
                    IsDeleted = false,
                }
            };
        }

        public Topic GetTestTopic()
        {
            return new Topic
            {
                Name = "Soft-gop-skills"
            };
        }

        public Training GetTestTraining()
        {
            var training = new Training
            {
                Name = "Супер чоткий тренинг",
                Description = "Как базарить на районе",
                Duration = 5,
                MembersCount = 50,
                Price = 5000,
                IsDeleted = false,
                Topics = new List<Topic>(),
                TrainingReviews = new List<TrainingReview>()
            };

            training.Topics.Add(GetTestTopic());
            training.Topics.Add(GetTestTopic());
            training.TrainingReviews.Add(GetTestTrainingReview());
            training.TrainingReviews.Add(GetTestTrainingReview());
            return training;
        }

        public Admin GetTestAdmin()
        {
            Admin adminItem = new Admin
            {
                Id = 34,
                Name = "Генадий",
                LastName = "Тряпкин",
                Gender = Enums.Gender.Male,
                BirthDay = "1988-04-29",
                Email = "ILoveBeer@ya.ru",
                Password = "228_nanosim",
                IsDeleted = false
            };
            return adminItem;
        }

        public List<Admin> GetTestAdminAll()
        {
            List<Admin> resultItem = new List<Admin>
            { 
                new Admin {  Id = 34,
                Name = "Генадий",
                LastName = "Тряпкин",
                Gender = Enums.Gender.Male,
                BirthDay = "1988-04-29",
                Email = "ILoveBeer@ya.ru",
                Password = "228_nanosim",
                IsDeleted = true }, 
            
            new Admin
            {
                Id = 1,
                Name = "Валерий",
                LastName = "Меладзе",
                Gender = Enums.Gender.Male,
                BirthDay = "1968-10-09",
                Email = "qwert1@ya.ru",
                Password = "kssdfn314",
                IsDeleted = false
            },

            new Admin
            {
                Id = 2,
                Name = "Валерия",
                LastName = "Новодворская",
                Gender = Enums.Gender.Female,
                BirthDay = "1950-11-10",
                Email = "jjjjres@ya.ru",
                Password = "fmpamfpqm1",
                IsDeleted = false
            },
            };
            return resultItem;
        }

        public Admin AddTestAdmin()
        {
            Admin adminItem = new Admin
            {
                Name = "Вова",
                LastName = "Бородин",
                Gender = Enums.Gender.Male,
                BirthDay = "1951-11-08",
                Email = "mnamny@yes.ru",
                Password = "ningse56asdS",
              
            };
            return adminItem;
        }

    }
}
