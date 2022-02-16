﻿using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IAdminService
    {
        AdminModel GetAdminById(int id);
        List<AdminModel> GetAdminAll();
        int AddNewAdmin(AdminModel newItem);
    }
}