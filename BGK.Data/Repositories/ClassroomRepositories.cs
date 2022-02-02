using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ClassroomRepositories
    {

        public Classroom GetAdminById(int id)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Classroom.FirstOrDefault(x => x.Id == id);
            if (res == null) throw new ArgumentNullException("Указанный id, не существует");
            return res;
        }

        public bool UpdateAdminInfo(Classroom newinfo)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Classroom.FirstOrDefault(x => x.Id == newinfo.Id);
            if (res == null) throw new ArgumentNullException("Указанный id в обьекте, не существует");

            res.City = newinfo.City;
            res.Address = newinfo.Address;
            res.MembersCount = newinfo.MembersCount;

            db.SaveChanges();
            return true;
        }

       

    }
}
