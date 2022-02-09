using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Interfaces
{
    public interface ITrainingService
    {
        Training GetTrainingById(int id);
    }
}
