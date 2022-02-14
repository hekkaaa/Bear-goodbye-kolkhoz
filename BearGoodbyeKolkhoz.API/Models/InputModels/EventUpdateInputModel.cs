﻿namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class EventUpdateInputModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public CompanyModel? Company { get; set; }
        public ClassroomModel Classroom { get; set; }
        public LecturerModel Lecturer { get; set; }
        public List<ClientModel>? Clients { get; set; }
    }
}