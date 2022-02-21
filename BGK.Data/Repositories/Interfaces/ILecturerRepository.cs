using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Interfaces
{
    public interface ILecturerRepository
    {
        void AddLecturer(Lecturer model);
        void AddTraining(Lecturer lecturer, Training training);
        void DeleteTraining(int lecturerId, Training model);
        Lecturer GetLecturerById(int id);
        List<Lecturer> GetLecturers();
        Lecturer Login(string login);
        void UpdateLecturer(Lecturer lecturer, Lecturer model);
        void ChangeDeleteStatusById(Lecturer lecturer, bool IsDeleted);
    }
}