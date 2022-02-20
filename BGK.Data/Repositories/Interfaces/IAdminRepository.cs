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
        bool ChangePasswordAdmin(int id, Admin newData);
        Admin Login(string email);
    }
}