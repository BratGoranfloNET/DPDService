using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleArticleRepository<TEntity> : ISimpleArticleRepository<TEntity, int> { }
    public interface ISimpleArticleRepository<TEntity, TEntityId>
    {        
		TEntity Create(TEntity entity);       
        IEnumerable<TEntity> GetAll();       
        TEntity GetById(TEntityId entityId);       
        TEntity Update(TEntity entity);       
        void Delete(TEntityId entityId);
        IEnumerable<TEntity> GetPublishedArticles(int categoryId);              

    }  

}
