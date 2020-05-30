using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleRepository_SizResult<TEntity> : ISimpleRepository_SizResult<TEntity, int> { }

    public interface ISimpleRepository_SizResult<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetSizIdsByPositionId(TEntityId entityId);
        TEntity AddSizToPosition (TEntityId entityId, TEntityId entity2Id, TEntityId entity3Id);
        void DeleteSizResult(TEntityId entityId);
        TEntity GetSizResultById(TEntityId entityId);
        TEntity Update(TEntity entity);
    }    
}
