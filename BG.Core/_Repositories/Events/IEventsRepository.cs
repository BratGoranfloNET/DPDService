using BG.Core.Entities;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Events repository interface.
	/// </summary>
	public interface IEventsRepository : ISimpleRepository<Event>, ISearchableRepository<Event>
	{
	}
}
