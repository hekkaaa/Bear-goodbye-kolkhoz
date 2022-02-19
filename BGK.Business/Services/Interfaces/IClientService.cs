using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IClientService
    {
        void ChangePasswordClient(int id, string password);
        void DeleteClient(int id);
        ClientModel GetClientById(int id);
        List<ClientModel> GetClients();
        void RecoverClient(int id);
        void UpdateClientInfo(int id, ClientModel updateModel);
    }
}