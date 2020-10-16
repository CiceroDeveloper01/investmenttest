using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.Service
{
    public class CategoriesService : IServicesOperationsBasic<Categories>
    {
        private readonly IOperationsBasicRepository<Categories> _operationsBasicRepositoryCategories;

        public CategoriesService(IOperationsBasicRepository<Categories> operationsBasicRepositoryCategories)
        {
            _operationsBasicRepositoryCategories = operationsBasicRepositoryCategories;
        }

        public void Delete(Categories entity)
        {
            _operationsBasicRepositoryCategories.Delete(entity);
        }

        public IEnumerable<Categories> Get()
        {
            return _operationsBasicRepositoryCategories.Get();
        }

        public Categories GetID(int Id)
        {
            return _operationsBasicRepositoryCategories.GetID(Id);
        }

        public void Insert(Categories entity)
        {
            _operationsBasicRepositoryCategories.Insert(entity);
        }

        public void Update(Categories entity)
        {
            _operationsBasicRepositoryCategories.Update(entity);
        }
    }
}
