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

        public int AddClient(Client client)
        {
            client.Role = Role.Client;
            _db.Client.Add(client);
            _db.SaveChanges();
            return client.Id;
        }

        public bool UpdateClientInfo(Client client, Client newInfo)
        {
            client.Name = newInfo.Name;
            client.LastName = newInfo.LastName;
            client.BirthDay = newInfo.BirthDay;
            client.Gender = newInfo.Gender;

            _db.SaveChanges();
            return true;
        }

        public bool ChangeDeleteStatusById(Client client)
        {
            client.IsDeleted = true;
            _db.SaveChanges();
            return true;
        }

        public bool ChangeRestoreStatusById(Client client)
        {
            client.IsDeleted = false;
            _db.SaveChanges();
            return true;
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