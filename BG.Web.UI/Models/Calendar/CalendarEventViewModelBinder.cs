using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar event view model binder.
	/// </summary>
	public class CalendarEventViewModelBinder : DefaultModelBinder
	{
		/// <summary>
		/// Bind images collection to the model.
		/// </summary>
		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			if (propertyDescriptor.Name == nameof(CalendarEventViewModel.Images))
			{
				var model = bindingContext.Model as CalendarEventViewModel;

				if (model != null)
				{
					var images = new List<CalendarEventImageViewModel>();

					var imageIds = controllerContext.HttpContext.Request.Form.Get("imageBlobId");
					var imageNames = controllerContext.HttpContext.Request.Form.Get("imageBlobName");
					var imageLabels = controllerContext.HttpContext.Request.Form.Get("imageLabel");
					var imageDescriptions = controllerContext.HttpContext.Request.Form.Get("imageDescription");

					if (!string.IsNullOrWhiteSpace(imageIds))
					{
						var ids = imageIds.Split(',');
						var names = imageNames.Split(',');
						var labels = imageLabels.Split(',');
						var descriptions = imageDescriptions.Split(',');

						for (int idx = 0; idx < ids.Length; idx++)
						{
							var id = ids[idx];
							var name = names[idx];
							var label = labels[idx];
							var description = descriptions[idx];

							var image = new CalendarEventImageViewModel();

							image.OrderIndex = idx;
							image.ImageBlobId = new Guid(id);
							image.ImageBlobName = name;
							image.ImageLabel = label;
							image.ImageDescription = description;

							images.Add(image);
						}
					}

					model.Images = images;
				}
			}

			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
		}
	}
}
