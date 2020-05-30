using Dapper;
using BG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BG.Data
{
	public partial class ArticleRepository
    {
		


        private Func<Article, Blob,  Article> _articleMap = (article, blob) =>
        {
            article.ImageBlob = blob;
            return article;
        };



    }
}
