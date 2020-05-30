using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using BG.Web.UI.ViewModels;
using BG.Web;
using BG.Web.Helpers;
using BG.Services.Image;
using BG.Web.UI.Extensions;
using System.Web.Mvc;
using System.Web.Mvc.Html; 




namespace BG.Web.UI.Models
{
   
    public class ArticleImageJsonModelMaps : IClassMapper
    {
        public void Configure()
        {

            Mapper.AddMap<ArticleImage,ArticleImageJsonModel>((source) =>
            {
                var result = new ArticleImageJsonModel();
                var imageServices = DependencyResolver.Current.GetService<IImageService>();
                result.InjectFrom(source);
                string pictureUrl = imageServices.BuildUrl(source.Name, source.Label);                
                result.Url = pictureUrl;             
                result.Label = source.Label;
                result.Description = source.Description;

                return result;

            });
        }    
    }
}