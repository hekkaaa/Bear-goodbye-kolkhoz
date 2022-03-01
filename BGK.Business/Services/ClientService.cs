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
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepo = clientRepository;
            _mapper = mapper;
        }

        public void RegistrationClient(ClientModel model)
        {
            bool res = CheckDublicateEmailAddClient(model.Email);

            if (res)
            {
                throw new DuplicateException("User with this Email already exists | Пользователь с таким Email уже существует ");
            }
            else
            {
                var entity = _mapper.Map<Client>(model);
                entity.Password = PasswordHash.HashPassword(model.Password);
                _clientRepo.AddClient(entity);
            }

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

        public void UpdateClientInfo(int id, ClientModel updateModel)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            var updateClient = _mapper.Map<Client>(updateModel);
            _clientRepo.UpdateClientInfo(client, updateClient);
        }

        public bool DeleteClient(int id)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            return _clientRepo.ChangeDeleteStatusById(client);
        }

        public bool RestoreClient(int id)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            return _clientRepo.ChangeRestoreStatusById(client);
        }

        public void ChangePasswordClient(int id, string password)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                throw new NotFoundException($"нет клиента с id = {id}");
            }

            string hashPassword = PasswordHash.HashPassword(password);

            _clientRepo.ChangePasswordClient(client, hashPassword);
        }

        private bool CheckDublicateEmailAddClient(string email)
        {
            var allList = _clientRepo.GetClients();

            Client res = allList.FirstOrDefault(a => a.Email == email);

            if (res == null)
            {
                return false;
            }
            return true;
        }
    }
}