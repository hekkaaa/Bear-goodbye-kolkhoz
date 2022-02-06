using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interfaces
{
    public interface ILecturerService
    {
        void AddTraining(int id, int trainingId);
        void DeleteLecturerById(int id);
        LecturerModel GetLecturerById(int id);
        List<LecturerModel> GetLecturers();
        void RecoverLecturerById(int id);
        void RegistrationLecturer(LecturerModel model);
        void UpdateLecturer(int id, LecturerModel model);
    }
}