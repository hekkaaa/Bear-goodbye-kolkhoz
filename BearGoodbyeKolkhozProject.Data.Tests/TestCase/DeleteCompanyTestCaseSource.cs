﻿using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Tests.TestCase
{
    public class DeleteCompanyTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
        

            var expected = new Company
            {
                Id = 2,
                Name = "OOO Ivan",
                Email = "qwe@mail.ru",
                PhoneNumber = "123456789",
                Tin = 123234,
                Password = "1234"
            };


            yield return new object[] { expected };


        }
    }
}
