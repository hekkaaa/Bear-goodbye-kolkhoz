using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ClientRepository
    {
        private ApplicationContext _db;
        public ClientRepository()
        {
            this._db = Storage.GetStorage();
        }
        public Client GetClientById(int id)
        {
            var res = _db.Client.FirstOrDefault(x => x.Id == id);
            return res;
        }

        public bool UpdateClientInfo(Client newInfo)
        {
            var res = _db.Client.FirstOrDefault(x => x.Id == newInfo.Id);

            res.Name = newInfo.Name;
            res.LastName = newInfo.LastName;
            res.Gender = newInfo.Gender;
            res.BirthDay = newInfo.BirthDay;
            res.Email = newInfo.Email;
            res.PhoneNumber = newInfo.PhoneNumber;
            res.Topic = newInfo.Topic;

            _db.SaveChanges();
            return true;
        }

        public bool DeleteClientById(int id)
        {
            var res = _db.Client.FirstOrDefault(x => x.Id == id);

            res.IsDeleted = false;
            _db.SaveChanges();
            return true;
        }

        public bool RecoveryClientById(int id)
        {
            var res = _db.Client.FirstOrDefault(x => x.Id == id);

            res.IsDeleted = true;
            _db.SaveChanges();
            return true;
        }

        public bool ChangePasswordClient(Client newItem)
        {
            Client item = GetClientById(newItem.Id);
            item.Password = newItem.Password;
            _db.SaveChanges();
            return true;
        }

        public List<Client> GetClients()
        {
            return _db.Client.Where(x => !x.IsDeleted).ToList();
        }
    }
}
