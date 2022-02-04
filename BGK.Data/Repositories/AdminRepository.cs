using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class AdminRepository
    {
        private ApplicationContext _db;
        private AdminRepository()
        {
            this._db = new ApplicationContext();
        }
        public Admin GetAdminById(int id)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);
            return res;
        }

        public bool UpdateAdminInfo(Admin newInfo)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == newInfo.Id);

            res.Name = newInfo.Name;
            res.LastName = newInfo.LastName;
            res.BirthDay = newInfo.BirthDay;
            res.Email = newInfo.Email;
            res.Gender = newInfo.Gender;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteAdminById(int id)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);

            res.IsDeleted = false;
            _db.SaveChanges();
            return true;
        }

        public bool AddAdmin(Admin newItem)
        {
            _db.Admin.Add(newItem);
            _db.SaveChanges();
            return true;
        }

        public bool ChangePasswordAdmin(Admin newItem)
        {
            Admin item = GetAdminById(newItem.Id);
            item.Password = newItem.Password;
            _db.SaveChanges();
            return true;
        }

        public bool RecoveryAdminById(int id)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);

            res.IsDeleted = true;
            _db.SaveChanges();
            return true;
        }
    }
}
