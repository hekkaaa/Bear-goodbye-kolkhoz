using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.API.Models.OutputModel;
using BearGoodbyeKolkhozProject.Business.Models;


namespace BearGoodbyeKolkhozProject.API.ConfigurationAPI
{
    public class CustomMapperApi
    {
        private static Mapper _instanceApi;

        public static Mapper GetInstance()
        {

            if (_instanceApi == null)
                InitCustomMapper();
            return _instanceApi;

        }

        public static Mapper CustomApi { get; set; }

        private static void InitCustomMapper()
        {

            _instanceApi = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompanyInsertInputModel, CompanyModel>().ReverseMap();

                cfg.CreateMap<CompanyUpdateInputModel, CompanyModel>().ReverseMap();

                cfg.CreateMap<CompanyOutputModel, CompanyModel>().ReverseMap();
               

            }));




        }
    }
}
