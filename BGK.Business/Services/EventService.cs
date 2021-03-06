using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;

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

        public EventService(IEventRepository eventRepository,
            ITrainingRepository trainingRepo,
            IClientRepository clientRepo,
            ILecturerRepository lecturerRepo,
            IClassroomRepository classroomRepo,
            ICompanyRepository companyRepo,
            IMapper mapper)
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
            CheckExistsOrRaiseException(even, id);

            return _mapper.Map<EventModel>(even);
        }

        public List<EventModel> GetEvents()
        {
            List<Event> events = _eventRepository.GetEvents();

            return _mapper.Map<List<EventModel>>(events);
        }


        public void AddEvent(EventModel eventModel)
        {
            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));
        }

        public bool UpdateEvent(int id, EventModel eventModel)
        {
            Event oldItemEvent = _eventRepository.GetEventById(id);

            if (oldItemEvent is null || oldItemEvent.IsDeleted == true)
            {
                throw new NotFoundException($"???? ?????????????? ?? ???????? ???????????? Event ?? ID {id}. ???????????????? Event ????????????");
            }
            
            Lecturer checkLector = _lecturerRepository.GetLecturerById(eventModel.Lecturer.Id);

            if (checkLector is null || checkLector.IsDeleted == true)
            {   
                throw new NotFoundException($"???? ?????????????? ?? ???????? ?????????????? ?? ID {eventModel.Lecturer.Id}. ???????????????? ???????????? ????????????.");
            }

            Training checktraning = _trainingRepository.GetTrainingById(eventModel.Training.Id);

            if(checktraning is null || checktraning.IsDeleted == true)
            {
                throw new NotFoundException($"???? ?????????????? ?? ???????? ???????????????? ?? ID {eventModel.Training.Id}. ???????????????? ?????????????? ????????????.");
            }
            
            Classroom checkClassroom = _classroomRepository.GetClassroomById(eventModel.Classroom.Id);

            if (checkClassroom is null || checkClassroom.IsDeleted == true)
            { 
                throw new NotFoundException($"???? ?????????????? ?? ???????? Classroom ?? ID {eventModel.Classroom.Id}. ???????????????? Classroom ????????????.");
            }

            Event testEvent = new Event
            {
                Id = eventModel.Id,
                StartDate = eventModel.StartDate,
                Training = checktraning,
                Lecturer = checkLector,
                Classroom = checkClassroom
            };

            bool res = _eventRepository.PartialUpdateEvent(oldItemEvent, testEvent);

            // ?????? ?? ???????????????? ?????????? ???????????????? ?? ?????????????????? ???????????? ?????? ???????? ???????????????????????????????? ??????.

            return res;
        }

        public void DeleteEvent(int id)
        {
            var even = _eventRepository.GetEventById(id);
            CheckExistsOrRaiseException(even, id);
            _eventRepository.UpdateEvent(even, true);
        }
        
        public void RestoreEvent(int id)
        {
            var even = _eventRepository.GetEventById(id);
            CheckExistsOrRaiseException(even, id);
            _eventRepository.UpdateEvent(even, false);
        }

        public List<EventModel> GetCompletedEventsByLecturerId(int id)
        {
            var lecturer = _lecturerRepository.GetLecturerById(id);
            if (lecturer is null)
            {
                throw new NotFoundException($"?????? ?????????????? ?? id = {id}");
            }

            var events = _eventRepository.GetCompletedEventsByLecturer(lecturer, DateTime.Now);
            var eventModels = _mapper.Map<List<EventModel>>(events);
           
            if(eventModels.Count is 0)
            {
                throw new BusinessException("The lecturer does not conduct any events | ???????????? ???? ???????????????? ???? ???????? ??????????");
            }

            foreach(EventModel model in eventModels)
            {
                model.Price = (model.Training.Price * 60) / 100;
                model.Name = model.Training.Name;
            }

            return eventModels;
        }

        public List<EventModel> GetAttendedEventsByClientId(int id)
        {
            var client = _clientRepository.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"?????? ?????????????? ?? id = {id}");
            }

            var events = _eventRepository.GetAttendedEventsByClient(client, DateTime.Now);
            var eventModels = _mapper.Map<List<EventModel>>(events);

            if (eventModels.Count is 0)
            {
                throw new BusinessException("The user did not participate in trainings | ???????????????????????? ???? ?????????????????????? ?? ??????????????????");
            }

            foreach (EventModel model in eventModels)
            {
                model.Price = (model.Training.Price);
                model.Name = model.Training.Name;
            }

            return eventModels;
        }

        public bool SignUp(int trainingId, int clientId)
        {
            var even = _eventRepository.GetEventsByTrainingId(trainingId);
            var client = _clientRepository.GetClientById(clientId);
            var training = _trainingRepository.GetTrainingById(trainingId);

            CheckExistsOrRaiseException(training, trainingId);
            CheckExistsOrRaiseException(client, clientId);
            CheckExistsDuplicateRegistrationOrRaiseException(even, client);

            if (even is null)
            {
                InitEvent(training, client);
                return true;
            }
            else if (training.MembersCount - even.Clients.Count == 1 && !IsDuplicateRegistration(even, clientId))
            {
                AssignData(training, client, even);

                _eventRepository.SignUp(client, even);

                // EmailSender() - ???????????????? EMAIL ???? ???????? ????????????????????.

                return true;
            }
            else if (even.Clients.Count < training.MembersCount && !IsDuplicateRegistration(even, clientId))
            {
                _eventRepository.SignUp(client, even);
                return true;
            }

            return true;
        }
        private void CheckExistsOrRaiseException(object test, int id)
        {
            if (test is null)
            {
                throw new NotFoundException($"???? ?????????????? ?? ???????? ???????????? ?????????????? ?? ID {id}");
            }
        }

        private void CheckExistsDuplicateRegistrationOrRaiseException(Event even, Client idClient)
        {
            if (even is null)
            {
                return;
            }
            var t = even.Clients.FirstOrDefault(x=>x.Id == idClient.Id);

            if(t != null)
            {
                throw new NotFoundException($"???????????? ?? ID {idClient.Id} ?????? ?????????????????????? ???? ???????? ??????????????! ");
            }

        }

        private void InitEvent(Training training, Client client)
        {
            var newEvent = new Event()
            {
                Training = training,
                Clients = new List<Client> { client }
            };

            _eventRepository.AddEvent(newEvent);
        }

        private void AssignData(Training training, Client client, Event even)
        {
            List<Event> events = _eventRepository.GetClosedRegEvents();

            Lecturer selectedLecturer = LecturerSelection(training);

            List<DateTime> lecturerSchedule = GetLecturerSchedule(selectedLecturer);

            KeyValuePair<Classroom, DateTime> selectedClassroomWithTime
                = ClassroomSelection(training, events, lecturerSchedule);

            Classroom selectedClassroom = selectedClassroomWithTime.Key;
            DateTime selectedDate = selectedClassroomWithTime.Value;

            SetEventData(selectedClassroom, selectedLecturer, selectedDate, even);
        }

        private Lecturer LecturerSelection(Training training)
        {
            var lecturers = _lecturerRepository.GetLecturerByTrainingId(training.Id);

            if (lecturers.Count == 0)
            {
                throw new NotFoundException("?????? ?????????????????????? ??????????????");
            }

            return GetMostInexperiencedLecturer(lecturers);
        }

        private KeyValuePair<Classroom, DateTime> ClassroomSelection(
            Training training
            , List<Event> events
            , List<DateTime> lecturerSchedule)
        {
            var classrooms = _classroomRepository.GetNeededClassroom(training.MembersCount);

            if (classrooms.Count == 0) throw new NotFoundException("?????? ?????????????????????? ??????????????????");

            Dictionary<Classroom, List<DateTime>> classroomsWork = GetClassroomsSchedule(classrooms, events);

            Dictionary<Classroom, DateTime> firstClassroomsFreeDay = new Dictionary<Classroom, DateTime>();

            foreach (KeyValuePair<Classroom, List<DateTime>> pair in classroomsWork)
            {
                firstClassroomsFreeDay.Add(pair.Key, FirstFreeDay(lecturerSchedule, pair.Value));
            }

            Classroom freeClassroom = firstClassroomsFreeDay.First(x => x.Value == firstClassroomsFreeDay.Values.Min()).Key;
            DateTime time = firstClassroomsFreeDay.First(x => x.Value == firstClassroomsFreeDay.Values.Min()).Value;

            return new KeyValuePair<Classroom, DateTime>(freeClassroom, time);
        }

        private void SetEventData(Classroom classroom, Lecturer lecturer, DateTime date, Event even)
        {
            even.Classroom = classroom;
            even.StartDate = date;
            even.Lecturer = lecturer;

            _eventRepository.UpdateEvent(even);
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

        private Lecturer GetMostInexperiencedLecturer(List<Lecturer> lecturers)
        {
            Lecturer resLecturer;
            if (lecturers.Count > 0)
            {
                resLecturer = lecturers[0];
                foreach (Lecturer lecturer in lecturers)
                {
                    if (_lecturerRepository.GetEventsCount(lecturer) < _lecturerRepository.GetEventsCount(resLecturer))
                        resLecturer = lecturer;
                }

                return resLecturer;
            }

            else throw new NotFoundException("?????? ?????????????????? ??????????????");

        }

        private List<DateTime> GetLecturerSchedule(Lecturer lecturer)
        {
            List<DateTime> schedule = new List<DateTime>();

            DateTime date = DateTime.Today.AddDays(1);

            if (lecturer.Events.Count != 0)
            {
                foreach (Event even in lecturer.Events)
                {
                    DateTime eventDate = Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy"));

                    if (eventDate >= date) schedule.Add(eventDate);

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
                            classroomWorks[classroom] = new List<DateTime> {
                                Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy"))};

                        else
                            classroomWorks[classroom]
                                .Add(Convert.ToDateTime(Convert.ToDateTime(even.StartDate).ToString("dd.MM.yyyy")));
                    }
                }
            }

            if (classroomWorks.Count == 0)
            {
                foreach (Classroom classroom in classrooms) classroomWorks.Add(classroom, new List<DateTime>());
            }

            return classroomWorks;
        }

        private DateTime FirstFreeDay(List<DateTime> workDays, List<DateTime> workClassroomDays)
        {
            DateTime resDate = DateTime.Today.AddDays(1);

            while (workDays.Contains(resDate) || workClassroomDays.Contains(resDate)) resDate = resDate.AddDays(1);

            return resDate;
        }
    }
}