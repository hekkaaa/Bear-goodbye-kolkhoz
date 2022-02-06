using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingReviewRepository : ITrainingReviewRepository
    {
        private ApplicationContext _applicationContext;

        public TrainingReviewRepository()
        {
            _applicationContext = Storage.GetStorage();
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

        public void AddTrainingReview(TrainingReview trainingReview)
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
