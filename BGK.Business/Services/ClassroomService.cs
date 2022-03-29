using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;


namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _repository;
        private readonly IMapper _mapper;

        public ClassroomService(IClassroomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ClassroomModel GetClassroomById(int id)
        {
            return _mapper.Map<ClassroomModel>(_repository.GetClassroomById(id));
        }

        public List<ClassroomModel> GetClassroomAll()
        {
            return _mapper.Map<List<ClassroomModel>>(_repository.GetClassroomsAll());
        }

        public int AddNewClassroom(ClassroomModel newItem)
        {
            return _repository.AddNewClassroom(_mapper.Map<Classroom>(newItem));
        }

        public bool DeleteClassroom(int id)
        {
            var res = _repository.GetClassroomById(id);
            if (res == null)
            {
                throw new NotFoundException("Нет такого кабинета");
            }
            else
            {
                res.IsDeleted = true;
                return _repository.UpdateClassroomInfo(res, true);
            }
        }
        
        public bool RestoreClassroom(int id)
        {
            var res = _repository.GetClassroomById(id);
            if (res == null)
            {
                throw new NotFoundException("Нет такого кабинета");
            }
            else
            {
                res.IsDeleted = true;
                return _repository.UpdateClassroomInfo(res, false);
            }
        }

        public bool UpdateClassroomInfo(int id, ClassroomModel newItem)
        {
            var res = _repository.GetClassroomById(id);
            if (res == null)
            {
                throw new ArgumentNullException();
            }
            var entities = _mapper.Map<Classroom>(newItem);
            return _repository.UpdateClassroomInfo(res, entities);
        }
    }
}
