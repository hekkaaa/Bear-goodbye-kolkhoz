using BearGoodbyeKolkhozProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class TrainingReviewModel
    {
        private TrainingReviewRepository _repository;
        public TrainingReviewModel()
        {

        }

        public void UpdateTrainingReview(int id, TrainingModel trainingModel)
        {
            var training = _repository.GetTrainingReviewById(id);
            
            if (training == null)
                throw new Exception("Такого обзора на тренинг не найдено!");

            
        }

    }
}
