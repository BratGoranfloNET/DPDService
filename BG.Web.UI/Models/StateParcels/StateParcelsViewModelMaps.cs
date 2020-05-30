using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class StateParcelsAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<StateParcels, StateParcelsViewModel>((source) =>
			{
				var result = new StateParcelsViewModel();
				result.InjectFrom(source);
                return result;
			});


            Mapper.AddMap<StateParcelsViewModel, StateParcels>((source) =>
            {
                var result = new StateParcels();
                result.InjectFrom(source);
                return result;

            });
        }
	}
}
