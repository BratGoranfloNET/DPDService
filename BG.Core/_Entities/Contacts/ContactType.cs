using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Contact types enumerator.
	/// </summary>
	public enum ContactType : byte
	{
		[Display(Name = "ContactTypeGeneral", ResourceType = typeof(ContactResources))]
		General = 1,		

        [Display(Name = "ContactTypeCompany", ResourceType = typeof(ContactResources))]
        Company = 2,

        [Display(Name = "ContactTypePerson", ResourceType = typeof(ContactResources))]
        Person = 3,

        [Display(Name = "ContactTypeLocation", ResourceType = typeof(ContactResources))]
        Location = 4,

        [Display(Name = "ContactTypeVizierUMTOP", ResourceType = typeof(ContactResources))]
        VizierUMTOP = 5,

        [Display(Name = "ContactTypeVizierUKS", ResourceType = typeof(ContactResources))]
        VizierUKS = 6,

        [Display(Name = "ContactTypeVizierPROJECT", ResourceType = typeof(ContactResources))]
        VizierPROJECT = 7

       

    }
}
