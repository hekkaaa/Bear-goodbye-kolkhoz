using BearGoodbyeKolkhozProject.Business.Models;

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
        List<TrainingModel> GetTrainingByLecturerId(int id);
        bool DeleteLecturer(int id);
        bool RestoreLecturer(int id);
    }
}