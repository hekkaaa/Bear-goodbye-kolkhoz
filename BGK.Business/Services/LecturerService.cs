﻿using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Interfaces;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepo;
        private readonly ITrainingRepository _trainingRepo;

        public LecturerService(ILecturerRepository lecturerRepository, ITrainingRepository trainingRepository)
        {
            _lecturerRepo = lecturerRepository;
            _trainingRepo = trainingRepository;
        }

        public void RegistrationLecturer(LecturerModel model)
        {
            var entity = CustomMapper.GetInstance().Map<Lecturer>(model);
            _lecturerRepo.AddLecturer(entity);
        }

        public void DeleteLecturerById(int id)
        {
            var lecturer = _lecturerRepo.GetLecturerById(id);
            if (lecturer is null)
            {
                throw new Exception("Нет Такого треннинга");
            }

            _lecturerRepo.ChangeDeleteStatusById(lecturer, true);
        }

        public void RecoverLecturerById(int id)
        {
            var lecturer = _lecturerRepo.GetLecturerById(id);
            if (lecturer is null)
            {
                throw new Exception("Нет Такого треннинга");
            }

            _lecturerRepo.ChangeDeleteStatusById(lecturer, false);
        }

        public void AddTraining(int id, int trainingId)
        {
            var training = _trainingRepo.GetTrainingById(trainingId);
            var lecturer = _lecturerRepo.GetLecturerById(trainingId);
            if (training is null)
            {
                throw new Exception("Нет такого треннинга");
            }
            if (lecturer is null)
            {
                throw new Exception("Нет такого лектора");
            }

            _lecturerRepo.AddTraining(lecturer, training);
        }

        public void DeleteTraining(int id, int trainingId)
        {
            var training = _trainingRepo.GetTrainingById(trainingId);
            if (training is null)
            {
                throw new Exception("Нет такого треннинга");
            }

            _lecturerRepo.DeleteTraining(id, training);
        }

        public void UpdateLecturer(int id, LecturerModel model)
        {
            var lecturer = _lecturerRepo.GetLecturerById(id);

            if (lecturer is null)
            {
                throw new Exception("Такого лектора нет");
            }

            var entity = CustomMapper.GetInstance().Map<Lecturer>(model);
            _lecturerRepo.UpdateLecturer(entity);
        }

        public LecturerModel GetLecturerById(int id)
        {
            var entity = _lecturerRepo.GetLecturerById(id);
            if (entity is null)
            {
                throw new Exception("Такого лектора нет");
            }

            return CustomMapper.GetInstance().Map<LecturerModel>(entity);
        }

        public List<LecturerModel> GetLecturers()
        {
            List<Lecturer> lecturers = _lecturerRepo.GetLecturers();
            return CustomMapper.GetInstance().Map<List<LecturerModel>>(lecturers);
        }
    }
}
