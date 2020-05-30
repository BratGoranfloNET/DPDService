using System.Collections.Generic;

namespace BG.Core.Repositories
{   
    public interface ISimpleRepository_GetByDPDParam<TEntity> : ISimpleRepository_GetByDPDParam<TEntity, string> { }
       
    public interface ISimpleRepository_GetByDPDParam<TEntity, TEntityParam>
    {
        TEntity GetByDPDParam(TEntityParam entityParam);
    }

}
