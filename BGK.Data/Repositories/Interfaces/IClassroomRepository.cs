using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClassroomRepository
    {
        bool DeleteClassroomById(Classroom item);
        Classroom GetClassroomById(int id);
        List<Classroom> GetClassroomsAll();
        bool UpdateClassroomInfo(Classroom oldItem, Classroom newInfo);
        int AddNewClassroom(Classroom newItem);
    }
}