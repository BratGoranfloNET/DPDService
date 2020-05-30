using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BG.Web.UI.Models;
using BG.Core;
using BG.Core.Entities;
using Omu.ValueInjecter;
using BG.Web.UI.ViewModels;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using BG.Core.Resources;
using System.Threading.Tasks;
using BG.Web.UI.Extensions;


namespace BG.Web.UI.ApiControllers
{
    public class ArticleData2
    {       
        public int  articleid { get; set; }     

    }
    

    public partial class ArticleController
    {

        [HttpGet]         
        [Route("getbyid", Name = "ArticleGetApi")]        
        public ArticleSingleJsonModel Get([FromUri]ArticleData2 articleData)
        {
           Article article;

            if (articleData != null)
            {
                article = _articleRepository.GetById(articleData.articleid);
            }
            else
            {
                return null;
            }                      

            if (article == null)
            {
                return null;
            }

            ArticleSingleJsonModel article_single_view_model =  Mapper.Map<ArticleSingleJsonModel>(article);

            IEnumerable<TagResult> tag_entity = _tagresultRepository.GetTagsIdsByArticletId(article.Id);
            
            int i = 1;
            foreach (TagResult item2 in tag_entity)
            {

                Tag tag = _tagRepository.GetById(Convert.ToInt32(item2.TagId));
                if (i == 1)
                {
                    article_single_view_model.Tags = article_single_view_model.Tags + tag.Name;
                }
                else
                {
                    article_single_view_model.Tags = "," + article_single_view_model.Tags + tag.Name;
                }

                i++;
            }

            return article_single_view_model;
        }
    }
}