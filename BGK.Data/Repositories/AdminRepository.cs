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
            //return _db.Admin.Where(a => !a.IsDeleted).ToList();
            return _db.Admin.ToList();
        }
        public bool UpdateAdminInfo(Admin oldItem, Admin newItem)
        {
            oldItem.Name = newItem.Name;
            oldItem.LastName = newItem.LastName;
            oldItem.BirthDay = newItem.BirthDay;
            oldItem.Email = newItem.Email;
            oldItem.Gender = newItem.Gender;

            _db.SaveChanges();
            return true;
        }

        public bool DeleteAdminById(int item)
        {
            var res = _db.Admin.FirstOrDefault(x => x.Id == item);
            res.IsDeleted = true;
            _db.SaveChanges();
            return true;
        }

        public int AddNewAdmin(Admin newItem)
        {
            _db.Admin.Add(newItem);
            _db.SaveChanges();
            return newItem.Id;
        }

        public bool ChangePasswordAdmin(string password, Admin admin)
        {
            admin.Password = password;
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

        public Admin Login(string email)
        {
            Admin? res = _db.Admin
                .Where(l => l.Email == email)
                .FirstOrDefault();

            return res;
        }
    }
}
