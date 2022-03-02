﻿using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IAdminService
    {
        AdminModel GetAdminById(int id);
        List<AdminModel> GetAdminAll();
        int AddNewAdmin(AdminModel newItem);
        bool DeleteAdmin(int id);
        bool RestoreAdmin(int id);
        bool UpdateAdminInfo(int id, AdminModel newItem);
        bool ChangeAdminPassword(int id, string password);
    }
}