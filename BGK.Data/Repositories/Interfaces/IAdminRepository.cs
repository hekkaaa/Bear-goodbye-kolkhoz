using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IAdminRepository
    {
        int AddNewAdmin(Admin newItem);
        bool DeleteAdminById(int item);
        List<Admin> GetAdminAll();
        Admin GetAdminById(int id);
        bool RecoverAdminById(int id);
        bool UpdateAdminInfo(Admin oldItem, Admin newItem);
        bool ChangePasswordAdmin(string password, Admin admin);
        Admin Login(string email);
    }
}