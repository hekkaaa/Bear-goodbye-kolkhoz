﻿using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCaseSources.CompanyTestCaseSourse
{
    public class UpdateCompanyTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var company = new Company
            {
                Id = 1,
                Name = "OOO Ivan",
                PhoneNumber = "1234567",
                Tin = 123234,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false

            };

            var updateCompany = new Company
            {
                Id = 1,
                Name = "OOO Lena",
                PhoneNumber = "7654321",
                Tin = 123211,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false
            };

            var expected = new Company
            {
                Id = 1,
                Name = "OOO Lena",
                PhoneNumber = "7654321",
                Tin = 123211,
                Email = "qwe@mail",
                Password = "1234",
                IsDeleted = false

            };

            yield return new object[] { company, updateCompany, expected };

        }
    }
}
