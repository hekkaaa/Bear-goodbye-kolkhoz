using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.API.Models.InputModels;

namespace BearGoodbyeKolkhozProject.API.Configuration
{
    public class CustomMapper : ICustomMapper
    {
        private Mapper _instance;

        public Mapper GetInstance()
        {
            if (_instance == null)
                InitCustomMapper();
            return _instance;
        }

        //public Mapper Custom { get; set; }

        private void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LecturerRegistrationInputModel, LecturerModel>().ReverseMap();
                cfg.CreateMap<LecturerOutputModel, LecturerModel>().ReverseMap();
            }));
        }
    }
}
