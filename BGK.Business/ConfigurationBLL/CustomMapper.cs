using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Configuration
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
                cfg.CreateMap<Company, CompanyModel>().ReverseMap();

                cfg.CreateMap<Event, EventModel>().ReverseMap();

                cfg.CreateMap<Training, TrainingModel>().ReverseMap();
                
                cfg.CreateMap<TrainingReview, TrainingReviewModel>().ReverseMap();

                cfg.CreateMap<Lecturer, LecturerModel>().ReverseMap();
            }));




        }

    }
}
