using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
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