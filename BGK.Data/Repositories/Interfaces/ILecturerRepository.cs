using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Interfaces
{
    public interface ILecturerRepository
    {
        void AddLecturer(Lecturer model);
        void AddTraining(Lecturer lecturer, Training training);
        void DeleteTraining(Lecturer lecturer, Training model);
        Lecturer GetLecturerById(int id);
        List<Lecturer> GetLecturers();
        void UpdateLecturer(Lecturer lecturer, Lecturer model);
        void ChangeDeleteStatusById(Lecturer lecturer, bool IsDeleted);
        List<Lecturer> GetLecturerByTrainingId(int trainingId);
        int GetEventsCount(Lecturer lecturer);
        List<Training> GetTrainingByLecturerId(int id);
    }
}