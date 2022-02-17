using AutoMapper;
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
            return _repository.DeleteClassroomById(id);
        }

        public bool UpdateAdminInfo(int id, ClassroomModel newItem)
        {
            var entities = _mapper.Map<Classroom>(newItem);
            return _repository.UpdateClassroomInfo(id, entities);
        }
    }


}
