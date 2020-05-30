using System;
using System.Collections.Generic;
using System.Linq;
using BG.Core.Entities;
using Omu.ValueInjecter;
using BG.Web.UI.ViewModels;
using System.Web.Http;

namespace BG.Web.UI.ApiControllers
{   
    public partial class ArticleController
    {
        [HttpGet]         
        [Route("all", Name = "ArticleGetAllApi")]        
        public ArticleListJsonModel Get()
        {

            IEnumerable<Article> article =  _articleRepository.GetAll();

            List<ArticleJsonModel> article_view_model = article
                      .Select(x => new ArticleJsonModel().InjectFrom(x))
                      .Cast<ArticleJsonModel>()
                      .ToList();


            foreach (ArticleJsonModel articleitem in article_view_model)
            {
                articleitem.Tags = "";
                int count = 1;

                IEnumerable<TagResult> tagresult = _tagresultRepository.GetTagsIdsByArticletId(articleitem.Id);
                foreach (TagResult item in tagresult)
                {
                    Tag tag =  _tagRepository.GetById(Convert.ToInt32(item.TagId));
                    if (tag != null)
                    {
                        if (count == 1)
                        {
                            articleitem.Tags = articleitem.Tags + tag.Name;

                        }
                        else
                        {
                            articleitem.Tags = articleitem.Tags + ", " + tag.Name;
                        }
                        count++;
                    }
                }
             
            }

            ArticleListJsonModel article_list_view_model = new ArticleListJsonModel(article_view_model);                      
            
            return article_list_view_model;

        }

    }

}