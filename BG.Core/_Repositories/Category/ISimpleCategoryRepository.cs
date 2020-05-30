using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleCategoryRepository<TEntity> : ISimpleCategoryRepository<TEntity, int> { }
    public interface ISimpleCategoryRepository<TEntity, TEntityId>
    {
		TEntity Create(TEntity entity);       
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllParent();
        IEnumerable<TEntity> GetAllChild();
        TEntity GetById(TEntityId entityId);               
        TEntity Update(TEntity entity); 
        void Delete(TEntityId entityId);
    }   
}
