using BG.Core.Entities;

namespace BG.Core.Repositories
{	
	public interface IStateHistoryRepository : ISimplePlusRepository<StateHistory> , ISimpleRepository_GetListByDPDParam<StateHistory>  //, ISearchableRepository<Tag>
    {

	}

}
