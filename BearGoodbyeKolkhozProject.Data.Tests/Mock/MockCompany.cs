using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Tests.Mock
{
    class MockCompany
    {
        public readonly string DefaultEmail = "qwe@mail.ru";
        public readonly string DefaultPassword = "12345";

        public MockCompany()
        {
            
        }

        public string Name = "ООО Трико";
        public string Email = "Trico@mail.ru";
        public int Tin = 881672145;
        public string Password = "12345";
        public string PhoneNumber = "89650436534";

        public Company AddCompanyMock()
        {           
            Company company = new Company();
            company.Name = Name;
            company.PhoneNumber = PhoneNumber;
            company.Email = Email;
            company.Password =Password;
            company.Tin = Tin;
            return company;
        }
    }
}
