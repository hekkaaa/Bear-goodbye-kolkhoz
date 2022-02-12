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

            CreateMap<TrainingReviewOutputModel, TrainingReviewModel>();
            CreateMap<TrainingOutputModel, TrainingModel>();
            CreateMap<AdminModel, AdminOutputModel>();

        }
    }

}

