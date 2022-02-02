using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingReviewRepository
    {
        private ApplicationContext _applicationContext;

        public TrainingReviewRepository()
        {
            _applicationContext = Storage.GetStorage();
        }


        public TrainingReview GetTrainingReviewById(int id) =>
            _applicationContext.TrainingReview.FirstOrDefault(tr => tr.Id == id);

        public List<TrainingReview> GetTrainingReviewsAll =>
            _applicationContext.TrainingReview.ToList();

        public void UpdateTrainingReview(TrainingReview trainingReview)
        {
            var oldTrainingReview = GetTrainingReviewById(trainingReview.Id);
            oldTrainingReview.Mark = trainingReview.Mark;
            oldTrainingReview.Text = trainingReview.Text;
            _applicationContext.SaveChanges();
        }

        public void AddTrainingReviw(TrainingReview trainingReview)
        {
            _applicationContext.TrainingReview.Add(trainingReview);
            _applicationContext.SaveChanges();
        }

        public void DeleteTrainingReview(int id)
        {
            var trainingReview = GetTrainingReviewById(id);
            _applicationContext.TrainingReview.Remove(trainingReview);
            _applicationContext.SaveChanges();
        }

    }
}
