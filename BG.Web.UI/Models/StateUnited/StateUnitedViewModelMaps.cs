using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class StateUnitedAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<StateUnited, StateUnitedViewModel>((source) =>
			{
				var result = new StateUnitedViewModel();
				result.InjectFrom(source);
                return result;
			});


            Mapper.AddMap<StateUnitedViewModel, StateUnited>((source) =>
            {
                var result = new StateUnited();
                result.InjectFrom(source);
                return result;
			 });                      

        }
	}
}
