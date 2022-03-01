using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interface
{
    public interface ILecturerService
    {
        void AddTraining(int id, int trainingId);
        void DeleteTraining(int id, int trainingId);
        LecturerModel GetLecturerById(int id);
        List<LecturerModel> GetLecturers();
        void RegistrationLecturer(LecturerModel model);
        void UpdateLecturer(int id, LecturerModel model);
        void DeleteLecturerById(int id);
        void RecoverLecturerById(int id);
    }
}