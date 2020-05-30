using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{
    /// <summary>
    /// Article view model validator.
    /// </summary>
    public class ArticleFormViewModelValidator : AbstractValidator<ArticleViewModel>
	{		
     	public ArticleFormViewModelValidator()
		{
            
            // RuleFor(model => model.CategoryId).NotEmpty();
            RuleFor(model => model.Title).NotEmpty();
            //RuleFor(model => model.Abstract).NotEmpty();
            RuleFor(model => model.Body).NotEmpty();
        }
		
	}
}
