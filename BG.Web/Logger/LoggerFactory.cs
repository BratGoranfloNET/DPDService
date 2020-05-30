using NLog;

namespace BG.Web.Logger
{
	/// <summary>
	/// Logger factory implementation.
	/// </summary>
	public class LoggerFactory<T> : ILoggerFactory
	{
		/// <summary>
		/// Create a new logger instance.
		/// </summary>
		public ILogger Create()
		{
			return LogManager.GetLogger(typeof(T).FullName);
		}
	}
}
