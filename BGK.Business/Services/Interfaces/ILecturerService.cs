﻿using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interface
{
    public interface ILecturerService
    {
        bool AddTraining(int id, int trainingId);
        void DeleteTraining(int id, int trainingId);
        LecturerModel GetLecturerById(int id);
        List<LecturerModel> GetLecturers();
        int RegistrationLecturer(LecturerModel model);
        void UpdateLecturer(int id, LecturerModel model);
        bool DeleteLecturerById(int id);
        bool RecoverLecturerById(int id);
        List<TrainingModel> GetTrainingByLecturerId(int id);
    }
}