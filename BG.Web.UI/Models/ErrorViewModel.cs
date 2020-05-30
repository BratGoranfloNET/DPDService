using BG.Core.Resources;
using System.Net;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Default error view model.
	/// </summary>
	public class ErrorViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets the error code.
		/// </summary>
		public int Code { get; private set; }

		/// <summary>
		/// Gets the error message.
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ErrorViewModel(HttpStatusCode statusCode, string errorMessage = null)
		{
			// Set status code
			Code = (int)statusCode;

			// Set error message
			Message = errorMessage;

			// No need to proceed if message is already set
			if (!string.IsNullOrWhiteSpace(Message))
				return;

			// Build description based on the current status code
			switch (statusCode)
			{
				case HttpStatusCode.BadRequest:
					Message = ErrorResources.BadRequestMessage;
					break;

				case HttpStatusCode.Forbidden:
					Message = ErrorResources.ForbiddenMessage;
					break;

				case HttpStatusCode.NotFound:
					Message = ErrorResources.NotFoundMessage;
					break;

				case HttpStatusCode.Unauthorized:
					Message = ErrorResources.UnauthorizedMessage;
					break;

				default:
					Message = ErrorResources.GeneralErrorMessage;
					break;
			}
		}
	}
}
