using System.Collections.Generic;

namespace ConsoleTestRisk.Interface
{
    public interface IOperationsBasicRepository<Entity>
    {
        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        IEnumerable<Entity> Get();
        Entity GetID(int Id);
    }
}
