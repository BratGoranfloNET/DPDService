using System;

namespace BG.Services
{	
	[Serializable]
	public class ServiceException : Exception
	{		
		public ServiceException(string message) : base(message) { }
		public ServiceException(string message, Exception innerException) : base(message, innerException) { }
	}
}
