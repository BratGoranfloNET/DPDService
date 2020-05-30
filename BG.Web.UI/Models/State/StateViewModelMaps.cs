using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{	
	public class StateAddViewModelMaps : IClassMapper
	{		
		public void Configure()
		{
			Mapper.AddMap<State, StateViewModel>((source) =>
			{
				var result = new StateViewModel();
				result.InjectFrom(source);
                return result;
			});


            Mapper.AddMap<StateViewModel, State>((source) =>
            {
                var result = new State();
                result.InjectFrom(source);
                return result;
            });
        }
	}
}
