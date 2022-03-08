using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interface
{
    public interface ILecturerService
    {
        void AddTraining(int id, int trainingId);
        void DeleteTraining(int id, int trainingId);
        LecturerModel GetLecturerById(int id);
        List<LecturerModel> GetLecturers();
        int RegistrationLecturer(LecturerModel model);
        void UpdateLecturer(int id, LecturerModel model);
        List<TrainingModel> GetTrainingByLecturerId(int id);
    }
}