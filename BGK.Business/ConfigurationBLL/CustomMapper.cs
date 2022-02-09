using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Configuration
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {

            CreateMap<Company, CompanyModel>().ReverseMap();

            CreateMap<Event, EventModel>().ReverseMap();

            CreateMap<Training, TrainingModel>().ReverseMap();

            CreateMap<TrainingReview, TrainingReviewModel>().ReverseMap();

            CreateMap<Lecturer, LecturerModel>().ReverseMap();

        }


    }
}
