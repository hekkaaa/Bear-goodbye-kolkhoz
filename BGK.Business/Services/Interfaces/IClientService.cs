using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IClientService
    {
        int RegistrationClient(ClientModel model);
        void ChangePasswordClient(int id, string password);
        bool DeleteClient(int id);
        bool RestoreClient(int id);
        ClientModel GetClientById(int id);
        List<ClientModel> GetClients();
        void UpdateClientInfo(int id, ClientModel updateModel);
    }
}