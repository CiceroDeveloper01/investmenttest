using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Interface;
using System;
using System.Collections.Generic;

namespace ConsoleTestRisk.Repository
{
    class CategoriesRepository : IOperationsBasicRepository<Categories>
    {
        public bool Delete(Categories entity)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public IEnumerable<Categories> Get()
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public Categories GetID(int Id)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public bool Insert(Categories entity)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }

        public bool Update(Categories entity)
        {
            //Usar algum modelo de ir até o Banco de Dados
            throw new NotImplementedException();
        }
    }
}