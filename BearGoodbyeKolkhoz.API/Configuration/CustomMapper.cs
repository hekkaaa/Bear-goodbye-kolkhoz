using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models;

namespace BearGoodbyeKolkhozProject.API.Configuration
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
                cfg.CreateMap<LecturerRegistrationInputModel, LecturerModel>().ReverseMap();
            }));
        }
    }
}
