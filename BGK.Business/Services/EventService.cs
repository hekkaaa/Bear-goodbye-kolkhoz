using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using BearGoodbyeKolkhozProject.Data.Interfaces;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class EventService : IEventService
    {

        private readonly IEventRepository _eventRepository;
        private readonly ITrainingRepository _trainingRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ICompanyRepository _companyRepository;


        private IMapper _mapper;

        public EventService(IEventRepository eventRepository
            , ITrainingRepository trainingRepo
            , IClientRepository clientRepo
            , ILecturerRepository lecturerRepo
            , IClassroomRepository classroomRepo
            , ICompanyRepository companyRepo
            , IMapper mapper)
        {
            _companyRepository = companyRepo;
            _lecturerRepository = lecturerRepo;
            _classroomRepository = classroomRepo;
            _eventRepository = eventRepository;
            _trainingRepository = trainingRepo;
            _clientRepository = clientRepo;
            _mapper = mapper;
        }

        public EventModel GetEventById(int id)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new BusinessException("Такого события не существует.");

            return _mapper.Map<EventModel>(even);
        }

        public List<EventModel> GetEvents()
        {
            List<Event> events = _eventRepository.GetEvents();

            return _mapper.Map<List<EventModel>>(events);
        }


        public void AddEventFromCompany(EventModel eventModel)
        {

            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));

        }

        public void AddEventFromClient(EventModel eventModel)
        {

            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));
        }

        public void UpdateEvent(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new BusinessException("Такого события не существует!");


            _eventRepository.UpdateEvent(_mapper.Map<Event>(eventModel));
        }
      

        public void DeleteEvent(int id)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new BusinessException($"Такого события {id} не существует.");

            _eventRepository.DeleteEvent(even);
        }

        public bool SignUp(int trainingId, int clientId)
        {
            var events = _eventRepository.GetEventsByTrainingId(trainingId);
            var client = _clientRepository.GetClientById(clientId);
            var training = _trainingRepository.GetTrainingById(trainingId);

            if (training is null)
            {
                throw new NotFoundException($"Нет тренинга с id = {trainingId}");
            }

            if (client is null)
            {
                throw new NotFoundException($"Нет клиента с id = {trainingId}");
            }

            if (events is null)
            {
                var newEvent = new Event()
                {
                    Training = training,
                    Clients = new List<Client> { client }
                };

                _eventRepository.AddEvent(newEvent);

                return true;
            }
            else if (training.MembersCount - events.Clients.Count == 1)
            {
                _eventRepository.SignUp(client, events);
                //метод назначения всего
                //запись на ивент
            }
            else if(events.Clients.Count < training.MembersCount)
            {
                _eventRepository.SignUp(client, events);
                return true;
            }
            //заглушка
            return false;
        }

        private void LecturerClassroomTimeSelection(Training training)
        {
            List<DateTime> lecturerWork = new List<DateTime>();

            var lecturers = _lecturerRepository.GetLecturerByTrainingId(training.Id);
            var classrooms = _classroomRepository.GetNeededClassroom(training.MembersCount);

            Dictionary<Classroom, List<DateTime>> classroomWorks = new Dictionary<Classroom, List<DateTime>>();

            Lecturer actualLecturer = null;
            Classroom freeClassroom = null;

            DateTime dateTime = DateTime.Now;
            DateTime date = Convert.ToDateTime(dateTime.AddDays(1).ToString("dd.MM.yyyy"));

            // нашли нужного тренера
            if (lecturers.Count > 0)
            {
                foreach (Lecturer lecturer in lecturers)
                {
                    if (_lecturerRepository.GetEventsCount(lecturer) < _lecturerRepository.GetEventsCount(actualLecturer))
                    {
                        actualLecturer = lecturer;
                    }
                }
            }
            else if (lecturers.Count == 0)
            {
                throw new NotFoundException("Нет подхощего тренера");
            }

            //только эвенты с завершенной регистрацией
            var events = _eventRepository.GetEvents();


            // получили список рабочих дней лектора
            foreach (Event even in actualLecturer.Events)
            {
                //i'm sorry
                DateTime eventDate = Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy"));

                if (eventDate > date)
                {
                    lecturerWork.Add(eventDate);
                }
            }

            //мы узнали когда какой кабинет занят
            foreach (Classroom classroom in classrooms)
            {
                foreach(Event even in events)
                {
                    if (classroom == even.Classroom)
                    {
                        if (classroomWorks[classroom] is null)
                        {
                            classroomWorks[classroom] = new List<DateTime> {
                                Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy"))};
                        }
                        else
                        {
                            classroomWorks[classroom]
                                .Add(Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy")));
                        }
                    }
                }
            }

            foreach (KeyValuePair<Classroom, List<DateTime>> pair in classroomWorks)
            {
                foreach (DateTime classroomWorkTime in pair.Value)
                {
                    if (!lecturerWork.Contains(classroomWorkTime))
                    {

                    }
                }
            }
        }
    }
}
