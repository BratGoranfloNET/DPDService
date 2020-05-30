using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class StateParcelsViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя")]
		public string Name { get; set; }
        public long docId { get; set; }
        public System.DateTime docDate { get; set; }
        public long clientNumber { get; set; }
        public bool resultComplete { get; set; }                   

    }
}
