using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Core.Repositories
{	
	public interface ILogsRepository
	{		
		IEnumerable<LogEntry> GetAll(int top = 30);
	}
}
