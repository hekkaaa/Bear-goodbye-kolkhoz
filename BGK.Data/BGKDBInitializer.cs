using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data
{
    public class BGKDBInitializer : DropCreateDatabaseAlways<BGKContext>
    {
        protected override void Seed(BGKContext context)
        {
            IList<Training> trainings = new List<Training>();
            trainings.Add(new Training() {Name = "Развитие ораторских способностей", Description = "Тренинг для развития ораторских способностей, лучшие приглашенные ораторы всех времён", Duration = 3, MembersCount = 15, Price = 1500 });
            trainings.Add(new Training() {Name = "Нетворк-скиллы", Description = "Тренинг для развития скиллов нетворкинга, знакомьтесь везде и всегда", Duration = 5, MembersCount = 18, Price = 2000 });
            trainings.Add(new Training() {Name = "Сторителлинг", Description = "Научитесь рассказывать истории, захватывайте всех своими презентациями", Duration = 2, MembersCount = 10, Price = 3500 });

            IList<Lecturer> lecturers = new List<Lecturer>();
            lecturers.Add(new Lecturer() { Name = "Вячеслав Ибрагимович", LastName = "Пототько", BirthDay = "27 августа", Gender = Enums.Gender.Male});
            lecturers.Add(new Lecturer() { Name = "Евгения Владимировна", LastName = "Цыплухина", BirthDay = "22 сентября", Gender = Enums.Gender.Female});
            lecturers.Add(new Lecturer() { Name = "Андрей Андреевич", LastName = "Вейпов", BirthDay = "15 октября", Gender = Enums.Gender.Male});

            IList<Classroom> classrooms = new List<Classroom>();
            classrooms.Add(new Classroom() { Address = "ул. Вавилова дом 5", City = "Санкт-Петербург", MembersCount = 25});
            classrooms.Add(new Classroom() { Address = "пр. Ветеранов дом 8", City = "Санкт-Петербург", MembersCount = 25});
            classrooms.Add(new Classroom() { Address = "ул. Пушкина дом 27", City = "Санкт-Петербург", MembersCount = 40});

            context.Grades.AddRange(trainings);
            context.Database.

            base.Seed(context); 
        }
    }
}
