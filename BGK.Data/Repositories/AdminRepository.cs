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
        public bool UpdateAdminInfo(int id, Admin newItem)
        {
            var oldItem = _db.Admin.FirstOrDefault(a => a.Id == id);

            oldItem.Name = newItem.Name;
            oldItem.LastName = newItem.LastName;
            oldItem.BirthDay = newItem.BirthDay;
            oldItem.Email = newItem.Email;
            oldItem.Gender = newItem.Gender;
           
            _db.SaveChanges();
            return true;
        }

        public bool DeleteAdminById(int id)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);

            res.IsDeleted = true;
            _db.Admin.Update(res);
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

        public bool ChangePasswordAdmin(int id, Admin newData)
        {
            // т.к шифрование пока не реализованно записываем так.
            var res = _db.Admin.FirstOrDefault(x => x.Id == id);

            res.Password = newData.Password;
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
