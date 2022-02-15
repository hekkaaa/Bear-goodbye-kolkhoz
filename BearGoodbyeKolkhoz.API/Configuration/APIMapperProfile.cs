using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModel;
using BearGoodbyeKolkhozProject.API.Models.OutputModel;
using BearGoodbyeKolkhozProject.API.Models.OutputModels;
using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API
{
    public class APIMapperProfile : Profile
    {
        public APIMapperProfile()
        {
            CreateMap<CompanyInsertInputModel, CompanyModel>().ReverseMap();

            CreateMap<CompanyUpdateInputModel, CompanyModel>().ReverseMap();

            CreateMap<CompanyOutputModel, CompanyModel>().ReverseMap();

            CreateMap<ContactLecturerInsertInputModel, ContactLecturerModel>().ReverseMap();

            CreateMap<LecturerRegistrationInputModel, LecturerModel>().ReverseMap();
            CreateMap<LecturerOutputModel, LecturerModel>().ReverseMap();

            CreateMap<TrainingReviewModel,TrainingReviewOutputModel>();
            CreateMap<TrainingModel, TrainingOutputModel>();

            CreateMap<AdminModel, AdminOutputModel>();

        }
    }

}

