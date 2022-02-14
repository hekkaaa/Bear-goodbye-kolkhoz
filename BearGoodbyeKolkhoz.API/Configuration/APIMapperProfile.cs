using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API
{
    public class APIMapperProfile : Profile
    {
        public APIMapperProfile()
        {
            CreateMap<LecturerRegistrationInputModel, LecturerModel>().ReverseMap();
            CreateMap<LecturerOutputModel, LecturerModel>().ReverseMap();
            CreateMap<TrainingReviewOutputModel, TrainingReviewModel>();
            CreateMap<TrainingOutputModel, TrainingModel>();
            CreateMap<AdminModel, AdminOutputModel>();

        }
    }

}

