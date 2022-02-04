﻿using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ClassroomRepository
    {
        private ApplicationContext _db;
        private ClassroomRepository()
        {
            this._db = new ApplicationContext();
        }

        public Classroom GetClassroomById(int id)
        {
            var res = _db.Classroom.FirstOrDefault(x => x.Id == id);
            return res;
        }

        public bool UpdateClassroomInfo(Classroom newInfo)
        {
            var res = _db.Classroom.FirstOrDefault(x => x.Id == newInfo.Id);

            res.City = newInfo.City;
            res.Address = newInfo.Address;
            res.MembersCount = newInfo.MembersCount;

            _db.SaveChanges();
            return true;
        }

        public List<Classroom> GetClassroom()
        {
            return _db.Classroom.ToList();
        }
    }
}
