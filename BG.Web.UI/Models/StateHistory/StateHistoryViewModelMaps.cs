using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Mappers;

namespace BG.Web.UI.Models
{
	public class StateHistoryAddViewModelMaps : IClassMapper
	{
		public void Configure()
		{
			Mapper.AddMap<StateHistory, StateHistoryViewModel>((source) =>
			{
				var result = new StateHistoryViewModel();
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
