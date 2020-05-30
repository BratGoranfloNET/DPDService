using System.Collections.Generic;

namespace BG.Core.Repositories
{
   
    public interface ISimpleRepository_GetByAutorId<TEntity> : ISimpleRepository_GetByAutorId<TEntity, int> { }

    
    public interface ISimpleRepository_GetByAutorId<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetByAutorId(TEntityId entityId);
    }

}
