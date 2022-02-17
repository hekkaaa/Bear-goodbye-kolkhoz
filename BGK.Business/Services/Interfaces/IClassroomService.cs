using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IClassroomService
    {
        int AddNewClassroom(ClassroomModel newItem);
        bool DeleteClassroom(int id);
        List<ClassroomModel> GetClassroomAll();
        ClassroomModel GetClassroomById(int id);
        bool UpdateAdminInfo(int id, ClassroomModel newItem);
    }
}