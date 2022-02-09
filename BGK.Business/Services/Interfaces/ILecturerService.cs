using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interfaces
{
    public interface ILecturerService
    {
        void AddTraining(int id, int trainingId);
        LecturerModel GetLecturerById(int id);
        List<LecturerModel> GetLecturers();
        void RegistrationLecturer(LecturerModel model);
        void UpdateLecturer(int id, LecturerModel model);
        void ChangeDeleteStatusById(int id, bool IsDeleted);
    }
}