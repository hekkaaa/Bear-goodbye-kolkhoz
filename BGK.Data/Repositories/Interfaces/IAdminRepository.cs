using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IAdminRepository
    {
        bool AddAdmin(Admin newItem);
        bool ChangePasswordAdmin(Admin newItem);
        bool DeleteAdminById(int id);
        Admin GetAdminById(int id);
        bool RecoverAdminById(int id);
        bool UpdateAdminInfo(Admin newInfo);
    }
}