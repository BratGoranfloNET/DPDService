using BG.Core.Entities;
using System;

namespace BG.Data
{	
	public partial class EventTypeRepository
	{
		private Func<EventType, Blob,  EventType> _positionMap = (position, blob ) =>
		{  
			return position;
		};
	}
}
