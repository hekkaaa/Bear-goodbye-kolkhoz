using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingReviewRepository : ITrainingReviewRepository
    {
        private ApplicationContext _applicationContext;

        public TrainingReviewRepository(ApplicationContext context)
        {
            _applicationContext = context;
        }


        public TrainingReview GetTrainingReviewById(int id) =>
            _applicationContext.TrainingReview.FirstOrDefault(tr => tr.Id == id);

        public List<TrainingReview> GetTrainingReviews() =>
            _applicationContext.TrainingReview.ToList();

        public void UpdateTrainingReview(TrainingReview trainingReview)
        {
            var oldTrainingReview = GetTrainingReviewById(trainingReview.Id);

            oldTrainingReview.Mark = trainingReview.Mark;
            oldTrainingReview.Text = trainingReview.Text;

            _applicationContext.SaveChanges();
        }

        public int AddTrainingReview(TrainingReview trainingReview)
        {
            _applicationContext.TrainingReview.Add(trainingReview);
            _applicationContext.SaveChanges();
            return trainingReview.Id;
        }

        public void DeleteTrainingReview(int id)
        {
            var trainingReview = GetTrainingReviewById(id);
            _applicationContext.TrainingReview.Remove(trainingReview);
            _applicationContext.SaveChanges();
        }

        public List<TrainingReview> GetReviewByTrainingId(int trainingId)
        {
            List<TrainingReview> reviews = _applicationContext.TrainingReview
                .Include(r=>r.Client)
                .Include(r=>r.Training)
                .Where(tr => tr.Training.Id == trainingId)
                .ToList();

            return reviews;
        }

    }
}
