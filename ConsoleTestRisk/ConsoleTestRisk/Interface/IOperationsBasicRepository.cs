using System.Collections.Generic;

namespace ConsoleTestRisk.Interface
{
    public interface IOperationsBasicRepository<Entity>
    {
        bool Insert(Entity entity);
        bool Update(Entity entity);
        bool Delete(Entity entity);
        IEnumerable<Entity> Get();
        Entity GetID(int Id);
    }
}
