using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleRepository_SoutResult<TEntity> : ISimpleRepository_SoutResult<TEntity, int> { }

    public interface ISimpleRepository_SoutResult<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetSoutIdsByPositionId(TEntityId entityId);
        TEntity AddSoutToPosition (TEntityId entityId, TEntityId entity2Id);
        void DeleteSoutResult(TEntityId entityId);
        TEntity GetSoutResultById(TEntityId entityId);
    }
    
}
