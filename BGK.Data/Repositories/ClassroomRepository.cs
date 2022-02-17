using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private ApplicationContext _db;
        public ClassroomRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public Classroom GetClassroomById(int id)
        {
            var res = _db.Classroom.FirstOrDefault(x => x.Id == id);
            return res;
        }

        public bool UpdateClassroomInfo(int id, Classroom newInfo)
        {
            var res = _db.Classroom.FirstOrDefault(x => x.Id == id);

            res.City = newInfo.City;
            res.Address = newInfo.Address;
            res.MembersCount = newInfo.MembersCount;

            _db.SaveChanges();
            return true;
        }

        public List<Classroom> GetClassroomsAll()
        {
            return _db.Classroom.ToList();
        }

        public int AddNewClassroom(Classroom newItem)
        {
            _db.Classroom.Add(newItem);
            _db.SaveChanges();
            return newItem.Id;
        }

        public bool DeleteClassroomById(int Id)
        {
            var res = _db.Classroom.FirstOrDefault(x => x.Id == Id);
            _db.Classroom.Remove(res);
            _db.SaveChanges(true);
            return true;
        }
    }
}
