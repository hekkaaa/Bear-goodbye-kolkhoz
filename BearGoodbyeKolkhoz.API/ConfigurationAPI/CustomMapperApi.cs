using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.InputModel;
using BearGoodbyeKolkhozProject.API.Models.OutputModel;
using BearGoodbyeKolkhozProject.Business.Models;


namespace BearGoodbyeKolkhozProject.API.ConfigurationAPI
{
    public class CustomMapperApi : Profile
    {

        public CustomMapperApi()  
        {
            
            CreateMap<CompanyInsertInputModel, CompanyModel>().ReverseMap();

            CreateMap<CompanyUpdateInputModel, CompanyModel>().ReverseMap();

            CreateMap<CompanyOutputModel, CompanyModel>().ReverseMap();

            CreateMap<ContactLecturerInsertInputModel, ContactLecturerModel>().ReverseMap();

        }
    }
}
