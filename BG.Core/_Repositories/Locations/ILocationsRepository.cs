using BG.Core.Entities;

namespace BG.Core.Repositories
{	
	public interface ILocationsRepository : ISimpleRepository<Location>, ISearchableRepository<Location>
	{
	}
}
