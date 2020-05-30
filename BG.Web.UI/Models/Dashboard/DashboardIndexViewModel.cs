using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{	
	public class DashboardIndexViewModel : BaseViewModel
	{

        [Display(Name = "Начало периода")]
        public DateTime StartDate { get; set; }


        [Display(Name = "Конец периода")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Отправитель")]
        public SelectList Consignors { get; set; }

        public  int? ConsignorID { get; set; }

    }
}
