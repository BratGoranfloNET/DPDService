using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using BG.Web.UI.ViewModels;
using System.Linq;
using BG.Web;
using BG.Web.Helpers;
using BG.Services.Image;
using BG.Web.UI.Extensions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System;


namespace BG.Web.UI.Models
{   
    public class ArticleJsonModelMaps : IClassMapper
    {

        public void Configure()
        {
            var imageServices = DependencyResolver.Current.GetService<IImageService>();
          
            Mapper.AddMap<Article, ArticleSingleJsonModel>((source) =>
            {                
                var result = new ArticleSingleJsonModel();

                result.InjectFrom(source);

                if (source.ImageBlob != null)
                {                    
                    string pic = Convert.ToString(source.ImageBlob.Id);
                    result.ImageUrl = imageServices.BuildUrl(source.ImageBlob.Name, "articlepic");
                }

                return result;

            });
        }    
    }
}