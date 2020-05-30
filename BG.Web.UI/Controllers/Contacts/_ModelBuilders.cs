using BG.Web.UI.Models;
using System.Web.Mvc;
using BG.Core.Entities;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial contacts controller.
	/// </summary>
	public partial class ContactsController
	{
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private ContactViewModel BuildModel(ContactViewModel model, bool partial = false)
		{
			model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;

            // model.Type = ContactType.Company;

			return model;
		}
	}
}