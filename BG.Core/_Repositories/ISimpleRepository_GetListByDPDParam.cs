using System.Collections.Generic;

namespace BG.Core.Repositories
{
    public interface ISimpleRepository_GetListByDPDParam<TEntity> : ISimpleRepository_GetListByDPDParam<TEntity, string> { }

   
    public interface ISimpleRepository_GetListByDPDParam<TEntity, TEntityParam>
    {
       IEnumerable<TEntity> GetListByDPDParam(TEntityParam entityParam);
    }

}
