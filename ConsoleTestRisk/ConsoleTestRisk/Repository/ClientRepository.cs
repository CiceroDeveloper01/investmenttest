using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.Repository 
{
    public class ClientRepository : IOperationsBasicRepository<Client>
    {
        public void Delete(Client entity)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public IEnumerable<Client> Get()
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public Client GetID(int Id)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public void Insert(Client entity)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }
    }
}
