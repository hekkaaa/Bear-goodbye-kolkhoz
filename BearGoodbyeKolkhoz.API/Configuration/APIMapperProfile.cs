using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModel;
using BearGoodbyeKolkhozProject.API.Models.InputModels;
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
            CreateMap<UpdateInputModel, LecturerModel>().ReverseMap();
            CreateMap<UpdateInputModel, ClientModel>().ReverseMap();
            CreateMap<UpdateInputModel, AdminModel>().ReverseMap();
            CreateMap<TrainingReviewOutputModel, TrainingReviewModel>();
            CreateMap<AdminModel, AdminOutputModel>(); // Не менять строчку!!!
            CreateMap<AdminInsertInputModel, AdminModel>();
            CreateMap<TopicInputModel, TopicModel>();
            CreateMap<TrainingReviewInsertInputModel, TrainingReviewModel>();
            CreateMap<ClientInputModel, ClientModel>();
            CreateMap<TrainingModel, TrainingOutputModel>();
            CreateMap<TrainingUpdateInputModel, TrainingModel>();
            CreateMap<TrainingInsertInputModel, TrainingModel>();

            CreateMap<AdminUpdateInputModel, AdminModel>();
            CreateMap<ChangePasswordInputModel, AdminModel>();
            CreateMap<ClassroomOutputModel, ClassroomModel>().ReverseMap();
            CreateMap<ClassroomInsertInputModel, ClassroomModel>().ReverseMap();
            CreateMap<ClassroomOutputModel, ClassroomModel>().ReverseMap();
            CreateMap<RegistrationInputModel, ClientModel>().ReverseMap();
            CreateMap<ClientOutputModel, ClientModel>().ReverseMap();

        }
    }

}

