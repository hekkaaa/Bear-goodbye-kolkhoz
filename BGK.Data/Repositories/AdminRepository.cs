using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private ApplicationContext _db;

        public AdminRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public Admin GetAdminById(int id)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);
            return res;
        }
        public List<Admin> GetAdminAll()
        {   

            return _db.Admin.Where(a => !a.IsDeleted).ToList();
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

        public int AddNewAdmin(Admin newItem)
        {
            newItem.IsDeleted = false; // делам при создании нового админа статус НЕзаблокирован по умолчанию.
            _db.Admin.Add(newItem);
            _db.SaveChanges();
            return newItem.Id;
        }

        public bool ChangePasswordAdmin(Admin newItem)
        {
            Admin item = GetAdminById(newItem.Id);
            item.Password = newItem.Password;
            _db.SaveChanges();
            return true;
        }

        public bool RecoverAdminById(int id)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);

            res.IsDeleted = true;
            _db.SaveChanges();
            return true;
        }
    }
}
