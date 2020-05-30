using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class TagAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<Tag, TagViewModel>((source) =>
			{
				var result = new TagViewModel();
				result.InjectFrom(source);
                return result;
			});


            Mapper.AddMap<TagViewModel, Tag>((source) =>
            {
                var result = new Tag();
                result.InjectFrom(source);
                return result;
            });

        }
	}
}
