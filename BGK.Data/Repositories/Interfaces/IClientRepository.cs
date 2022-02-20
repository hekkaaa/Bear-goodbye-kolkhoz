using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClientRepository
    {
        void ChangePasswordClient(Client client, string newPassword);
        void ChangeDeleteStatusById(Client client, bool isDeleted);
        Client GetClientById(int id);
        List<Client> GetClients();
        bool UpdateClientInfo(Client client, Client newInfo);
        Client Login(string email, string password);
    }
}