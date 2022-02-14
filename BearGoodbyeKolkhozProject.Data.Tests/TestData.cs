using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                IsDeleted = true
            };
            return adminItem;
        }
    }
}
