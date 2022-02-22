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
            var even = _eventRepository.GetEventsByTrainingId(trainingId);
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

            if (even is null)
            {
                var newEvent = new Event()
                {
                    Training = training,
                    Clients = new List<Client> { client }
                };

                _eventRepository.AddEvent(newEvent);

                return true;
            }
            else if (training.MembersCount - even.Clients.Count == 1 && !IsDuplicateRegistration(even, clientId))
            {
                _eventRepository.SignUp(client, even);
                LecturerClassroomTimeSelection(training, even);
                //запись на ивент
            }
            else if(even.Clients.Count < training.MembersCount && !IsDuplicateRegistration(even, clientId))
            {
                _eventRepository.SignUp(client, even);
                return true;
            }
            //заглушка
            return false;
        }

        private bool IsDuplicateRegistration(Event even, int clientId)
        {
            foreach (Client eventsClient in even.Clients)
            {
                if (eventsClient.Id == clientId)
                {
                    return true;
                }
            }

            return false;
        }

        private void LecturerClassroomTimeSelection(Training training, Event even)
        {
            var lecturers = _lecturerRepository.GetLecturerByTrainingId(training.Id);
            var classrooms = _classroomRepository.GetNeededClassroom(training.MembersCount);

            if (classrooms.Count == 0)
            {
                throw new NotFoundException("Нет подходящего помещения");
            }

            if (lecturers.Count == 0)
            {
                throw new NotFoundException("Нет подходящего тренера");
            }

            // нашли самого неоптыного тренера
            Lecturer actualLecturer = GetMostInexperiencedLecturer(lecturers);

            //только эвенты с завершенной регистрацией
            var events = _eventRepository.GetClosedRegEvents();

            // расписание каждого кабинета
            Dictionary<Classroom, List<DateTime>> classroomsWork = GetClassroomsSchedule(classrooms, events);

            // получили список рабочих дней лектора
            List<DateTime> lecturerWork = GetLecturerSchedule(actualLecturer, events);

            //получаем первый ближайший свободный день кабинета
            Dictionary <Classroom, DateTime> firstClassroomsFreeDay = new Dictionary<Classroom, DateTime>();

            foreach (KeyValuePair<Classroom, List<DateTime>> pair in classroomsWork)
            {
                firstClassroomsFreeDay.Add(pair.Key, FirstFreeDay(lecturerWork, pair.Value));
            }

            //выбираем самую близкую дату и кабинет
            Classroom freeClassroom = firstClassroomsFreeDay.Min().Key;
            DateTime time = firstClassroomsFreeDay.Min().Value;

            even.Lecturer = actualLecturer;
            even.Classroom = freeClassroom;
            even.StartDate = time.ToString();

            _eventRepository.UpdateEvent(even);
        }

        private Lecturer GetMostInexperiencedLecturer(List<Lecturer> lecturers)
        {
            Lecturer resLecturer;
            if (lecturers.Count > 0)
            {
                resLecturer = lecturers[0];
                foreach (Lecturer lecturer in lecturers)
                {
                    if (_lecturerRepository.GetEventsCount(lecturer) < _lecturerRepository.GetEventsCount(resLecturer))
                    {
                        resLecturer = lecturer;
                    }
                }

                return resLecturer;
            }
            else
            {
                throw new NotFoundException("Нет подхощего тренера");
            }
        }

        private List<DateTime> GetLecturerSchedule(Lecturer lecturer, List<Event> events)
        {
            List<DateTime> schedule = new List<DateTime>();

            DateTime date = DateTime.Today.AddDays(1);

            if (lecturer.Events.Count != 0)
            {

                foreach (Event even in lecturer.Events)
                {
                    DateTime eventDate = Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy"));

                    if (eventDate >= date)
                    {
                        schedule.Add(eventDate);
                    }
                }
            }
            return schedule;
        }

        private Dictionary<Classroom, List<DateTime>> GetClassroomsSchedule(List<Classroom> classrooms, List<Event> events)
        {
            Dictionary<Classroom, List<DateTime>> classroomWorks = new Dictionary<Classroom, List<DateTime>>();

            
            foreach (Classroom classroom in classrooms)
            {
                foreach (Event even in events)
                {
                    if (classroom == even.Classroom)
                    {
                        if (!classroomWorks.ContainsKey(classroom))
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

            if (classroomWorks.Count == 0)
            {
                foreach (Classroom classroom in classrooms)
                {
                    classroomWorks.Add(classroom, new List<DateTime>());
                }
            }

            return classroomWorks;
        }

        private DateTime FirstFreeDay(List<DateTime> workDays, List<DateTime> workClassroomDays)
        {
            DateTime resDate = DateTime.Today.AddDays(1);

            while (workDays.Contains(resDate) || workClassroomDays.Contains(resDate))
            {
                resDate = resDate.AddDays(1);
            }

            return resDate;
        }
    }
}
