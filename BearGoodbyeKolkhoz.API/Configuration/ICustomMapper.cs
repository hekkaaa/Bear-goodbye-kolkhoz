using AutoMapper;

namespace BearGoodbyeKolkhozProject.API.Configuration
{
    public interface ICustomMapper
    {
        Mapper GetInstance();
    }
}