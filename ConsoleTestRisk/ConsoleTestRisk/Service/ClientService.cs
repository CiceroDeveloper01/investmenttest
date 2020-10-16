using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.Service
{
    public class ClientService : IServicesOperationsBasic<Client>
    {
        private readonly IOperationsBasicRepository<Client> _operationsBasicRepository;

        public ClientService(IOperationsBasicRepository<Client> operationsBasicRepository)
        {
            _operationsBasicRepository = operationsBasicRepository;
        }

        public void Delete(Client entity)
        {
            _operationsBasicRepository.Delete(entity);
        }

        public IEnumerable<Client> Get()
        {
            return _operationsBasicRepository.Get();
        }

        public Client GetID(int Id)
        {
            return _operationsBasicRepository.GetID(Id);
        }

        public void Insert(Client entity)
        {
            _operationsBasicRepository.Insert(entity);
        }

        public void Update(Client entity)
        {
            _operationsBasicRepository.Delete(entity);
        }
    }
}
