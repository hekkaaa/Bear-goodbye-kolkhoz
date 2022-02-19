using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IClientRepository
    {
        bool ChangePasswordClient(Client newItem);
        bool DeleteClientById(int id);
        Client GetClientById(int id);
        List<Client> GetClients();
        bool RecoveryClientById(int id);
        bool UpdateClientInfo(Client newInfo);
    }
}