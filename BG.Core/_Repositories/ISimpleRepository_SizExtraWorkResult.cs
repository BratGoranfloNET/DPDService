using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleRepository_SizExtraWorkResult<TEntity> : ISimpleRepository_SizExtraWorkResult<TEntity, int> { }

    public interface ISimpleRepository_SizExtraWorkResult<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetSizIdsByExtraWorkId(TEntityId entityId);
        TEntity AddSizToExtraWork(TEntityId entityId, TEntityId entity2Id, TEntityId entity3Id);
        void DeleteSizExtraWorkResult(TEntityId entityId);
        TEntity GetSizExtraWorkResultById(TEntityId entityId);
        TEntity Update(TEntity entity);
    }    
}
