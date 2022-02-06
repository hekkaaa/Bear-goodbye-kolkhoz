using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Interfaces
{
    public interface ILecturerRepository
    {
        void AddLecturer(Lecturer model);
        void AddTraining(int lecturerId, int trainingId);
        void DeleteLecturerById(int id);
        void DeleteTraining(int lecturerId, Training model);
        Lecturer GetLecturerById(int id);
        List<Lecturer> GetLecturers();
        void RecoverLecturerById(int id);
        void UpdateLecturer(Lecturer model);
    }
}