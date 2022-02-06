﻿using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Interfaces;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _repo;

        public LecturerService(ILecturerRepository lecturerRepository)
        {
            _repo = lecturerRepository;
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
            var entity = _repo.GetLecturerById(id);
            _repo.AddTraining(id, trainingId);
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
