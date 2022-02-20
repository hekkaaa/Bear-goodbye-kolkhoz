using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IClassroomService
    {
        int AddNewClassroom(ClassroomModel newItem);
        bool DeleteClassroom(int id);
        List<ClassroomModel> GetClassroomAll();
        ClassroomModel GetClassroomById(int id);
        bool UpdateClassroomInfo(int id, ClassroomModel newItem);
    }
}