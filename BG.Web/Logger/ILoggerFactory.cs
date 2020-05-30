using NLog;

namespace BG.Web.Logger
{
	/// <summary>
	/// Logger factory interface.
	/// </summary>
	public interface ILoggerFactory
	{
		ILogger Create();
	}
}
