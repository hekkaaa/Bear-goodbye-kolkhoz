using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API
{
    public class APIMapperProfile : Profile
    {
        public APIMapperProfile()
        {

            CreateMap<TrainingReviewModel, TrainingReviewOutputModel>();
            CreateMap<TrainingModel, TrainingOutputModel>();
            CreateMap<TopicModel, TopicOutputModel>();
            CreateMap<TopicInputModel, TopicModel>();
        }
    }

}

