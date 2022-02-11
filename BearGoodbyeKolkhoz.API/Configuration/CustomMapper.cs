using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models;
using AutoMapper;

namespace BearGoodbyeKolkhozProject.API.Configuration
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<LecturerRegistrationInputModel, LecturerModel>().ReverseMap();
            CreateMap<LecturerOutputModel, LecturerModel>().ReverseMap();
        }
    }
}