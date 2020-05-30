using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleRepository_PositionResult<TEntity> : ISimpleRepository_PositionResult<TEntity, int> { }

    public interface ISimpleRepository_PositionResult<TEntity, TEntityId>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetPositionsIdsByDepartmentId(TEntityId entityId);
        TEntity AddPositionToDepartment (TEntityId entityId, TEntityId entity2Id);
        void DeletePositionResult(TEntityId entityId);
        TEntity GetPositionResultById(TEntityId entityId);
    }    
}
