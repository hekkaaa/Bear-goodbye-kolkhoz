using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingService : ITrainingService
    {
        private ITrainingRepository _repository;

        public TrainingService(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public void UpdateTraining(int id, TrainingModel trainingModel)
        {
            var training = _repository.GetTrainingById(id);

            if (training == null)
                throw new Exception("Такого тренинга не найдено!");

            var trainingEntity = CustomMapper.GetInstance().Map<Training>(trainingModel);
            _repository.UpdateTraining(trainingEntity);
        }

        public TrainingModel GetTrainingModelById(int id)
        {
            var trainingEntity = _repository.GetTrainingById(id);
            return CustomMapper.GetInstance().Map<TrainingModel>(trainingEntity);
        }

        public List<TrainingModel> GetTrainingModelsAll()
        {
            var trainingEntityList = _repository.GetTrainings();
            return CustomMapper.GetInstance().Map<List<TrainingModel>>(trainingEntityList);
        }



        public void AddTraining(TrainingModel trainingModel)
        {
            var trainingEntity = CustomMapper.GetInstance().Map<Training>(trainingModel);
            _repository.AddTraining(trainingEntity);
        }

        public void DeleteTraining(TrainingModel trainingModel)
        {
            _repository.DeleteTraining(trainingModel.Id);
        }
    }
}
