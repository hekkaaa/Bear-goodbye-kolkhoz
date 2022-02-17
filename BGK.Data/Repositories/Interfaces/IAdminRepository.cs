using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IAdminRepository
    {
        int AddNewAdmin(Admin newItem);
        bool ChangePasswordAdmin(Admin newItem);
        bool DeleteAdminById(int id);
        List<Admin> GetAdminAll();
        Admin GetAdminById(int id);
        bool RecoverAdminById(int id);
        bool UpdateAdminInfo(Admin newInfo);
    }
}