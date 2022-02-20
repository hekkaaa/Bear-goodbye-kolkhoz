using AutoMapper;
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
            var entity = _mapper.Map<Client>(model);
            _clientRepo.AddClient(entity);
        }

        public ClientModel GetClientById(int id)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                // Антон, тут будет кастомный, не нервничай просто он пока в другой ветке <3
                throw new Exception();
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
                // Антон, тут будет кастомный, не нервничай просто он пока в другой ветке <3
                throw new Exception();
            }

            var updateClient = _mapper.Map<Client>(updateModel);
            _clientRepo.UpdateClientInfo(client, updateClient);
        }

        public void DeleteClient(int id)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                // Антон, тут будет кастомный, не нервничай просто он пока в другой ветке <3
                throw new Exception();
            }

            _clientRepo.ChangeDeleteStatusById(client, true);
        }

        public void RecoverClient(int id)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                // Антон, тут будет кастомный, не нервничай просто он пока в другой ветке <3
                throw new Exception();
            }

            _clientRepo.ChangeDeleteStatusById(client, false);
        }

        public void ChangePasswordClient(int id, string password)
        {
            var client = _clientRepo.GetClientById(id);

            if (client is null)
            {
                // Антон, тут будет кастомный, не нервничай просто он пока в другой ветке <3
                throw new Exception();
            }

            _clientRepo.ChangePasswordClient(client, password);
        }
    }
}