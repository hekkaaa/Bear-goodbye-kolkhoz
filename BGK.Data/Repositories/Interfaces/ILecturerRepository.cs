using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Interfaces
{
    public interface ILecturerRepository
    {
        int AddLecturer(Lecturer model);
        bool AddTraining(Lecturer lecturer, Training training);
        void DeleteTraining(Lecturer lecturer, Training model);
        Lecturer GetLecturerById(int id);
        List<Lecturer> GetLecturers();
        void UpdateLecturer(Lecturer lecturer, Lecturer model);
        List<Lecturer> GetLecturerByTrainingId(int trainingId);
        int GetEventsCount(Lecturer lecturer);
    }
}