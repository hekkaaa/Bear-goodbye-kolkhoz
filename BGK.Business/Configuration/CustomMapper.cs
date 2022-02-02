using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Configuration
{
    public static class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitCustomMapper();
            return _instance;
        }

        public static Mapper Custom { get; set; }


        private static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Training, TrainingModel>();
                cfg.CreateMap<TrainingModel, Training>();
                cfg.CreateMap<TrainingReview, TrainingReviewModel>();
                cfg.CreateMap<TrainingReviewModel, TrainingReview>();

            }));
        }
    }
}
