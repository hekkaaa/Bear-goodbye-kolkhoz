using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void ChangePasswordClient(Client client, string newPassword);
        bool ChangeDeleteStatusById(Client client);
        bool ChangeRestoreStatusById(Client client);
        Client GetClientById(int id);
        List<Client> GetClients();
        bool UpdateClientInfo(Client client, Client newInfo);
        Client Login(string email);
    }
}