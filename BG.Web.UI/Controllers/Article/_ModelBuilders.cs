using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class ArticleController
	{
		/// <summary>
		/// Build the view model with common required contents.
		/// </summary>
		[NonAction]
		private ArticleViewModel BuilModel(ArticleViewModel model)
		{
            var categories =  _categoryRepository.GetAll();
         
            model.ImageUploadMaxLengthInBytes = _imageService.ImageUploadMaxLengthInBytes;

            model.Categories = new SelectList(
                categories
                , "Id"
                , "Title"
            );

            return model;
		}
	}
}