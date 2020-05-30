using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class EventTrackingParameterViewModel : BaseViewModel
	{
		public int Id { get; set; }	

		[Display(Name = "Имя")]
		public string Name { get; set; }
        public int EventTrackingTypeId { get; set; }        
        public string paramName { get; set; }
        public string valueString { get; set; }
        public decimal valueDecimal { get; set; }
        public bool valueDecimalSpecified { get; set; }
        public System.DateTime valueDateTime { get; set; }
        public bool valueDateTimeSpecified { get; set; }
        public string type { get; set; }        
    }
}
