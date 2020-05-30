using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleRepository_TagResult<TEntity> : ISimpleRepository_TagResult<TEntity, int> { }

    public interface ISimpleRepository_TagResult<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetTagsIdsByArticletId(TEntityId entityId);
        TEntity AddTagToArticle (TEntityId entityId, TEntityId entity2Id);
        void DeleteTagResult(TEntityId entityId);
        TEntity GetTagResultById(TEntityId entityId);
    }    
}
