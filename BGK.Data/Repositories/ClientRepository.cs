using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationContext _db;
        public ClientRepository(ApplicationContext context)
        {
            this._db = context;
        }

        public Client GetClientById(int id)
        {
            var res = _db.Client.FirstOrDefault(с => с.Id == id);
            return res;
        }

        public void AddClient(Client client)
        {
            client.Role = Role.Client;
            _db.Client.Add(client);
            _db.SaveChanges();
        }

        public bool UpdateClientInfo(Client client, Client newInfo)
        {
            client.Name = newInfo.Name;
            client.LastName = newInfo.LastName;
            client.BirthDay = newInfo.BirthDay;

            _db.SaveChanges();
            return true;
        }

        public void ChangeDeleteStatusById(Client client, bool isDeleted)
        {
            client.IsDeleted = isDeleted;
            _db.SaveChanges();
        }

        public void ChangePasswordClient(Client client, string newPassword)
        {
            client.Password = newPassword;
            _db.SaveChanges();
        }

        public List<Client> GetClients()
        {
            return _db.Client.Where(с => !с.IsDeleted).ToList();
        }

        public Client Login(string email)
        {
            Client? res = _db.Client
                .FirstOrDefault(l => l.Email == email);

            return res;
        }
    }
}