using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class CategoryController
	{
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private CategoryViewModel BuilModel(CategoryViewModel model)
		{
            var categories =  _categoryRepository.GetAllParent();
         
            model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;
            		

			model.ParentCategory = new SelectList(
                categories
                , "Id"
				, "Title"
			);

			return model;
		}
	}
}