﻿using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITrainingReviewService
    {
        void AddTrainingReview(TrainingReviewModel trainingReviewModel);
        void DeleteTrainingReview(TrainingReviewModel trainingReviewModel);
        TrainingReviewModel GetTrainingReviewModelById(int id);
        List<TrainingReviewModel> GetTrainingReviewModels();
        void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel);
    }
}