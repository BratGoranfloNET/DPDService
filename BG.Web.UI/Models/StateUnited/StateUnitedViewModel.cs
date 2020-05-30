using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class StateUnitedViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя")]
		public string Name { get; set; }
        public int Count { get; set; }
        public int StateParcelsUnitedId { get; set; }
        public string clientOrderNr { get; set; }
        public string clientParcelNr { get; set; }
        public string dpdOrderNr { get; set; }
        public string dpdParcelNr { get; set; }
        public System.DateTime pickupDate { get; set; }
        public string dpdOrderReNr { get; set; }
        public string dpdParcelReNr { get; set; }
        public bool isReturn { get; set; }
        public bool isReturnSpecified { get; set; }
        public System.DateTime planDeliveryDate { get; set; }
        public bool planDeliveryDateSpecified { get; set; }
        public string newState { get; set; }
        public System.DateTime transitionTime { get; set; }
        public string terminalCode { get; set; }
        public string terminalCity { get; set; }
        public string incidentCode { get; set; }
        public string incidentName { get; set; }
        public string consignee { get; set; }
        public string EventName { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryVariant { get; set; }
        public string DeliveryPointCode { get; set; }
        public string DeliveryInterval { get; set; }
        public string PickupAddress { get; set; }
        public string PickupCity { get; set; }
        public string PointCity { get; set; }
        public string Consignee2 { get; set; }
        public string Consignor { get; set; }
        public string EventReason { get; set; }
        public string ProblemName { get; set; }
        public string ReasonName { get; set; }
        public string RejectionReason { get; set; }
        public string OrderType { get; set; }
        public string MomentLocZone { get; set; }
    }
}
