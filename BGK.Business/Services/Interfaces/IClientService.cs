using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IClientService
    {
        int RegistrationClient(ClientModel model);
        void ChangePasswordClient(int id, string password);
        ClientModel GetClientById(int id);
        List<ClientModel> GetClients();
        bool UpdateClientInfo(int id, ClientModel updateModel);
    }
}