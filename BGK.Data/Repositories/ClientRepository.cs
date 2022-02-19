using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

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

        public bool UpdateClientInfo(Client client, Client newInfo)
        {
            client.Name = newInfo.Name;
            client.LastName = newInfo.LastName;
            client.Gender = newInfo.Gender;
            client.BirthDay = newInfo.BirthDay;
            client.Email = newInfo.Email;
            client.PhoneNumber = newInfo.PhoneNumber;
            client.Topic = newInfo.Topic;

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
    }
}