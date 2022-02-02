using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ClientRepositories
    {
        public Client GetClientById(int id)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Client.FirstOrDefault(x => x.Id == id);
            if (res == null) throw new ArgumentNullException("Указанный id, не существует");
            return res;
        }

        public bool UpdateClientInfo(Client newinfo)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Client.FirstOrDefault(x => x.Id == newinfo.Id);
            if (res == null) throw new ArgumentNullException("Указанный id в обьекте, не существует");

            res.Name = newinfo.Name;
            res.LastName = newinfo.LastName;
            res.Gender = newinfo.Gender;
            res.BirthDay = newinfo.BirthDay;
            res.Email = newinfo.Email;
            res.PhoneNumber = newinfo.PhoneNumber;
            res.Password = newinfo.Password;
            res.IsDeleted = newinfo.IsDeleted;
            res.TrainingReviews = newinfo.TrainingReviews;
            res.LecturerReviews = newinfo.LecturerReviews;
            res.Topic = newinfo.Topic;

            db.SaveChanges();
            return true;
        }

        public bool DeleteClientById(int id)
        {
            var db = ConnectDb.Storage.GetStorage();
            var res = db.Client.FirstOrDefault(x => x.Id == id);
            if (res == null) throw new ArgumentNullException("Указанный id, не существует");

            res.IsDeleted = false;
            db.SaveChanges();
            return true;
        }
    }
}
