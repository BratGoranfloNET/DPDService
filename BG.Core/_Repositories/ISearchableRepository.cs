using System.Collections.Generic;

namespace BG.Core.Repositories
{
	public interface ISearchableRepository<T>
	{		
		IEnumerable<T> Search(string query);
	}
}
