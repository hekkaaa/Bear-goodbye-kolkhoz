using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClassroomRepository
    {
        bool DeleteClassroomById(int Id);
        Classroom GetClassroomById(int id);
        List<Classroom> GetClassroomsAll();
        bool UpdateClassroomInfo(int id, Classroom newInfo);
        int AddNewClassroom(Classroom newItem);
    }
}