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

        public bool UpdateClassroomInfo(Classroom oldItem, Classroom newInfo)
        {
            oldItem.City = newInfo.City;
            oldItem.Address = newInfo.Address;
            oldItem.MembersCount = newInfo.MembersCount;

            _db.SaveChanges();
            return true;
        }
        
        public bool UpdateClassroomInfo(Classroom oldItem, bool isDeleted)
        {
            oldItem.IsDeleted = true;
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

        public bool DeleteClassroomById(Classroom item)
        {
            _db.Classroom.Update(item);
            _db.SaveChanges(true);
            return true;
        }

        public List<Classroom> GetNeededClassroom(int sitCount) =>
            _db.Classroom.Where(c => c.MembersCount >= sitCount).ToList();
    }
}
