using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace BearGoodbyeKolkhozProject.Business.AutoMappers
{
    public static class CompanyMapper
    {
        private static Mapper mapper;

        public static Mapper GetInstance()
        {
            if (mapper == null) InitCustomMapper();
            return mapper;
        }      

        private static void InitCustomMapper()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyModel>()               
                .ReverseMap();






            }));

        }
    }
}
