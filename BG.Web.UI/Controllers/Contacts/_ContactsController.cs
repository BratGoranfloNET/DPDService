using BG.Core.Repositories;
using BG.Services.Image;
using BG.Services.Timeline;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial contacts controller.
	/// </summary>
	[Authorize]
	[RoutePrefix("contacts")]
	public partial class ContactsController : BaseController
	{
		private IImageService _imageService = null;
		private IContactsRepository _contactsRepository = null;
		private ITimelineService _timelineService = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ContactsController(IImageService imageService, IContactsRepository contactsRepository, ITimelineService timelineService)
		{
			_imageService = imageService;
			_contactsRepository = contactsRepository;
			_timelineService = timelineService;

		}
	}
}