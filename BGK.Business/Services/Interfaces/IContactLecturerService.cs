using BearGoodbyeKolkhozProject.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Services.Interfaces
{
    public interface IContactLecturerService
    {
        void AddContactLecturerValue(ContactLecturerModel сontactLecturerModel);

        void UpdateContactLecturerValue(ContactLecturerModel сontactLecturerModel);
    }
}
