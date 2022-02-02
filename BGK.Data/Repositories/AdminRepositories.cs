using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class AdminRepositories
    {
        public Admin GetAdminById(int id)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Admin.FirstOrDefault(x => x.Id == id);
            if (res == null) throw new ArgumentNullException("Указанный id, не существует");
            return res;
        }

        public bool UpdateAdminInfo(Admin newinfo)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Admin.FirstOrDefault(x => x.Id == newinfo.Id);
            if (res == null) throw new ArgumentNullException("Указанный id в обьекте, не существует");

            res.Name = newinfo.Name;
            res.LastName = newinfo.LastName;
            res.BirthDay = newinfo.BirthDay;
            res.Email = newinfo.Email;
            res.Gender = newinfo.Gender;
            res.Password = newinfo.Password;
            res.IsDeleted = newinfo.IsDeleted;
            db.SaveChanges();
            return true;
        }

        public bool DeleteAdminById(int id)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Admin.FirstOrDefault(x => x.Id == id);
            if (res == null) throw new ArgumentNullException("Указанный id, не существует");

            res.IsDeleted = false;
            db.SaveChanges();
            return true;
        }
    }
}
