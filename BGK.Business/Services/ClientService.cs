using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepo;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public ClientService(IClientRepository clientRepository,IUserRepository userRepository, IMapper mapper)
        {
            _clientRepo = clientRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public int RegistrationClient(ClientModel model)
        {
            CheckDublicateEmailForTable.CheckDublicateEmailForTableUser(model.Email, _userRepository);
           
            var entity = _mapper.Map<Client>(model);
            entity.Password = PasswordHash.HashPassword(model.Password);
            return _clientRepo.AddClient(entity);
            
        }

        public ClientModel GetClientById(int id)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            return _mapper.Map<ClientModel>(client);
        }

        public List<ClientModel> GetClients()
        {
            var clients = _clientRepo.GetClients();
            return _mapper.Map<List<ClientModel>>(clients);
        }

        public bool UpdateClientInfo(int id, ClientModel updateModel)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            var updateClient = _mapper.Map<Client>(updateModel);
            return _clientRepo.UpdateClientInfo(client, updateClient);
        }

        public void ChangePasswordClient(int id, string oldPassword, string newPassword)
        {
            var client = _clientRepo.GetClientById(id);

            

            if (!PasswordHash.ValidatePassword(oldPassword, client.Password))
            {
                throw new IncorrectPasswordException("Старый пароль введён неверно");
            }

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            string hashNewPassword = PasswordHash.HashPassword(newPassword);

            _clientRepo.ChangePasswordClient(client, hashNewPassword);
        }
    }
}