using Dapper;
using BG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BG.Data
{

    public partial class CategoryRepository
    {
        /// <summary>
        /// Build the entity object from the query results.
        /// </summary>
        private Func<Category, Blob, Category> _categoryMap = (category, blob) =>
        {
            category.ImageBlob = blob;      

            return category;
        };
    }
}
