using BG.Web.UI.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using BG.Core.Entities;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController 
	{
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private CalendarEventViewModel BuildModel(CalendarEventViewModel model)
		{
			var locations = _locationsRepository.GetAll();
            //var productions = _productionRepository.GetAll();

           // IEnumerable<Production> nullproduction = new List<Production>();

            var eventtypes = _eventtypeRepository.GetAll();           

            model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;

			model.Locations = new SelectList(
				locations
				, "Id"
				, "Name"
			);





            //if (model.Id == 0)
            //{
            //    model.Productions = new SelectList(
            //        nullproduction  // productions
            //        , "Id"
            //        , "Name"
            //    );

            //    model.StartDate = DateTime.Now;
            //    model.EndDate = DateTime.Now;

            //    model.StartTime = DateTime.Now;
            //    model.EndTime = DateTime.Now;


            //}
            //else
            //{
            //    model.Productions = new SelectList(
            //        productions
            //        , "Id"
            //        , "Name"
            //    );

            //}




            model.EventTypes = new SelectList(
               eventtypes
               , "Id"
               , "Name"
           );

            return model;

		}

	}

}
