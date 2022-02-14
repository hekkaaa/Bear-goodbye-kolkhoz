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
            CreateMap<Admin, AdminModel>().ReverseMap();
            CreateMap<LecturerModel, Lecturer>().ReverseMap();

            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Event, EventModel>().ReverseMap();
            CreateMap<Training, TrainingModel>().ReverseMap();
            CreateMap<TrainingReview, TrainingReviewModel>().ReverseMap();
            CreateMap<Lecturer, LecturerModel>().ReverseMap();
            CreateMap<ContactLecturer, ContactLecturerModel>().ReverseMap();
        }
    }
}
