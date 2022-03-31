using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepo;
        private readonly ITrainingRepository _trainingRepo;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LecturerService(ILecturerRepository lecturerRepository,IUserRepository userRepository ,ITrainingRepository trainingRepository, IMapper mapper)
        {
            _lecturerRepo = lecturerRepository;
            _trainingRepo = trainingRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public int RegistrationLecturer(LecturerModel model)
        {
            CheckDublicateEmailForTable.CheckDublicateEmailForTableUser(model.Email, _userRepository);

            var entity = _mapper.Map<Lecturer>(model);
            entity.Password = PasswordHash.HashPassword(model.Password);
            
            return _lecturerRepo.AddLecturer(entity);
        }

        public bool AddTraining(int id, int trainingId)
        {
            var training = _trainingRepo.GetTrainingById(trainingId);
            var lecturer = _lecturerRepo.GetLecturerByIdAndIncludeTraning(id);
       

            if (training is null)
            {
                throw new NotFoundException($"Нет треннинга c id = {id}");
            }
            if (lecturer is null)
            {
                throw new NotFoundException($"Нет лектора c id = {id}");
            }

            CheckDublicateAddTraining(lecturer, training.Id);

            if (lecturer.Trainings is null)
            {
                lecturer.Trainings = new List<Training>();
            }

            return _lecturerRepo.AddTraining(lecturer, training);
        }

        public void DeleteTraining(int id, int trainingId)
        {
            var training = _trainingRepo.GetTrainingById(trainingId);
            var lecturer = _lecturerRepo.GetLecturerById(id);
            if (training is null)
            {
                throw new NotFoundException($"Нет треннинга c id = {id}");
            }

            _lecturerRepo.DeleteTraining(lecturer, training);
        }

        public void UpdateLecturer(int id, LecturerModel model)
        {
            var lecturer = _lecturerRepo.GetLecturerById(id);

            if (lecturer is null)
            {
                throw new NotFoundException($"Нет лектора c id = {id}");
            }

            var entity = _mapper.Map<Lecturer>(model);
            _lecturerRepo.UpdateLecturer(lecturer, entity);
        }

        public LecturerModel GetLecturerById(int id)
        {
            var entity = _lecturerRepo.GetLecturerById(id);
            if (entity is null)
            {
                throw new NotFoundException($"Нет лектора c id = {id}");
            }

            return _mapper.Map<LecturerModel>(entity);
        }

        public List<LecturerModel> GetLecturers()
        {
            List<Lecturer> lecturers = _lecturerRepo.GetLecturers();
            return _mapper.Map<List<LecturerModel>>(lecturers);
        }

        public List<TrainingModel> GetTrainingByLecturerId(int id)
        {
            //var entity = _lecturerRepo.GetLecturerById(id);
            //if (entity is null)
            //{
            //    throw new NotFoundException($"Нет лектора c id = {id}");
            //}

            //var res = _lecturerRepo.GetLecturerByIdAndIncludeTraning(id);
            //List<TrainingModel> trainings = _mapper.Map<List<TrainingModel>>(res.Trainings);

            var entity = _lecturerRepo.GetLecturerByIdAndIncludeTraning(id);
            if (entity is null)
            {
                throw new NotFoundException($"Нет лектора c id = {id}");
            }
            if(entity.Trainings.Count() == 0)
            {
                throw new NotFoundException("The lecturer does not participate in trainings | Лектор не участвует в тренингах");
            }
            List<TrainingModel> trainings = _mapper.Map<List<TrainingModel>>(entity.Trainings);
            return trainings;
        }

        private void CheckDublicateAddTraining(Lecturer lector, int traningid)
        {   
            foreach(var i in lector.Trainings)
            {
                if (i.Id == traningid)
                {
                    throw new DuplicateException($"Лектор уже записан на указанный тренинг = {traningid}");
                }

            }
        }

        public bool DeleteLecturer(int id)
        {
            var entity = _lecturerRepo.GetLecturerById(id);
            if (entity is null)
            {
                throw new NotFoundException($"Нет лектора c id = {id}");
            }
            return _lecturerRepo.UpdateLecturer(entity, true);
        }

        public bool RestoreLecturer(int id)
        {
            var entity = _lecturerRepo.GetLecturerById(id);
            if (entity is null)
            {
                throw new NotFoundException($"Нет лектора c id = {id}");
            }
            return _lecturerRepo.UpdateLecturer(entity, false);
        }
    }
}