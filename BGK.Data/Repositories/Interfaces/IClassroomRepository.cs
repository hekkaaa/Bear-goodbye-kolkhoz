using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClassroomRepository
    {
        Classroom GetClassroomById(int id);
        List<Classroom> GetClassroomsAll();
        bool UpdateClassroomInfo(Classroom oldItem, Classroom newInfo);
        int AddNewClassroom(Classroom newItem);
        List<Classroom> GetNeededClassroom(int sitCount);
        bool UpdateClassroomInfo(Classroom oldItem, bool isDeleted);
    }
}