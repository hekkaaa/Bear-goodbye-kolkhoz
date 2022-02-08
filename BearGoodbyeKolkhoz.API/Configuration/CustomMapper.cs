using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API
{
    public class CustomMapper
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
                cfg.CreateMap<TrainingReviewOutputModel, TrainingReviewModel>();
                cfg.CreateMap<TrainingOutputModel, TrainingModel>();


            }));
        }
    }

}

