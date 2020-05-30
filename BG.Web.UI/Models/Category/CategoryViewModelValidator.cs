using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{	
	public class CategoryFormViewModelValidator : AbstractValidator<CategoryViewModel>
	{		
     	public CategoryFormViewModelValidator()
		{	     
			RuleFor(model => model.Title).NotEmpty();
            RuleFor(model => model.Description).NotEmpty();         
        }		
	}
}
