using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;
using BG.Core.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BG.Web.UI.Models
{
    public class TagResultViewModelMaps : IClassMapper
    {

       
        private IArticleRepository _articleRepository = null;
        private ITagRepository _tagRepository = null;


        public TagResultViewModelMaps(IArticleRepository articleRepository,
                                       ITagRepository tagRepository)
        {
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;           
        }
        

        public void Configure()
        {


            Mapper.AddMap<TagResult, TagResultViewModel>((source) =>
            {
                var result = new TagResultViewModel();

                result.InjectFrom(source);

                Tag   tag   = _tagRepository.GetById(Convert.ToInt32(source.TagId));
                Article article = _articleRepository.GetById(Convert.ToInt32(source.ArticleId));

                result.TagName = tag.Name;
                result.ArticleName = article.Title;               

                return result;

            });
        }
    }
}