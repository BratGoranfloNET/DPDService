﻿using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class StateHistoryController
    {
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private StateHistoryViewModel BuilModel(StateHistoryViewModel model)
		{
            // var position = _positionRepository.GetAll();
         
            // model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;            		

			// model.Position = new SelectList(
            // position
            // , "Id"
			// , "Name"
			// );

			return model;
		}
	}
}