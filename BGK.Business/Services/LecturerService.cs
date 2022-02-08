using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Interfaces;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _repo;
        private readonly ITrainingRepository _trainingRepo;

        public LecturerService(ILecturerRepository lecturerRepository, ITrainingRepository trainingRepository)
        {
            _repo = lecturerRepository;
            _trainingRepo = trainingRepository;
        }

        public void RegistrationLecturer(LecturerModel model)
        {
            var entity = CustomMapper.GetInstance().Map<Lecturer>(model);
            _repo.AddLecturer(entity);
        }

        public void DeleteLecturerById(int id)
        {
            _repo.DeleteLecturerById(id);
        }

        public void RecoverLecturerById(int id)
        {
            _repo.RecoverLecturerById(id);
        }

        public void AddTraining(int id, int trainingId)
        {
            var training = _trainingRepo.GetTrainingById(trainingId);
            if (training is null)
            {
                throw new Exception("Нет такого треннинга");
            }

            _repo.AddTraining(id, training);
        }

        public void DeleteTraining(int id, int trainingId)
        {
            var training = _trainingRepo.GetTrainingById(trainingId);
            if (training is null)
            {
                throw new Exception("Нет такого треннинга");
            }

            _repo.DeleteTraining(id, training);
        }

        public void UpdateLecturer(int id, LecturerModel model)
        {
            var training = _repo.GetLecturerById(id);

            if (training == null)
            {
                throw new Exception("Такого лектора нет");
            }

            var entity = CustomMapper.GetInstance().Map<Lecturer>(model);
            _repo.UpdateLecturer(entity);
        }

        public LecturerModel GetLecturerById(int id)
        {
            var entity = _repo.GetLecturerById(id);
            if (entity is null)
            {
                throw new Exception("Такого лектора нет");
            }

            return CustomMapper.GetInstance().Map<LecturerModel>(entity);
        }

        public List<LecturerModel> GetLecturers()
        {
            List<Lecturer> lecturers = _repo.GetLecturers();
            return CustomMapper.GetInstance().Map<List<LecturerModel>>(lecturers);
        }
    }
}
