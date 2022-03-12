using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClientRepository
    {
        int AddClient(Client client);
        void ChangePasswordClient(Client client, string newPassword);
        Client GetClientById(int id);
        List<Client> GetClients();
        bool UpdateClientInfo(Client client, Client newInfo);
        Client Login(string email);
    }
}