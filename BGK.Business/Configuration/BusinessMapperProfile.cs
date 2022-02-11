using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Configuration
{
    public class BusinessMapperProfile : Profile
    {
        public BusinessMapperProfile()
        {
            CreateMap<Training, TrainingModel>().ReverseMap();
            CreateMap<TrainingReview, TrainingReviewModel>().ReverseMap();
            CreateMap<Topic, TopicModel>().ReverseMap();
        }
    }
}
