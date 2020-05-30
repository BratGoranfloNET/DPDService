using BG.DPDServices.BGDPDServiceEventTracking;
using BG.DPDServices.BGDPDServiceTracing;
using System;

namespace BG.DPDServices
{

    public class DPDWebService
    {
        private const string clientKey = "*************";
        private const long clientNumber = 1000;

        DPDEventTrackingClient _dpdEventClient = null;
        ParcelTracingClient _dpdcTracingClient = null;

        public DPDWebService()
        {
            // http://ws.dpd.ru:80/services/event-tracking
            _dpdEventClient = new DPDEventTrackingClient("DPDEventTrackingPort");

            // http://ws.dpd.ru:80/services/tracing
            _dpdcTracingClient = new ParcelTracingClient("ParcelTracingPort");

        }


        public eventTackingResponse GetDPDEvents()
        {
            eventTrackingRequest requestEvent = new eventTrackingRequest
            {
                auth = new BG.DPDServices.BGDPDServiceEventTracking.auth
                {
                    clientKey = clientKey,
                    clientNumber = clientNumber
                }
            };
                
            eventTackingResponse responseEventModel = _dpdEventClient.getEvents(requestEvent);

            return responseEventModel;
        }


        public void EventConfirm(long docId)
        {
            // Подтверждаем, что получили статусы  по эвентам   

            BG.DPDServices.BGDPDServiceEventTracking.requestConfirm requestconfirm = new BG.DPDServices.BGDPDServiceEventTracking.requestConfirm
            {
                auth = new BG.DPDServices.BGDPDServiceEventTracking.auth
                {
                    clientKey = clientKey,
                    clientNumber = clientNumber
                },

                docId = docId
            };

            string confirmresponse = _dpdEventClient.confirm(requestconfirm);
        }


        public BG.DPDServices.BGDPDServiceTracing.stateParcels GetDPDStates()
        {
            // http://ws.dpd.ru:80/services/tracing

            ParcelTracingClient dpdcTracingClient = new ParcelTracingClient("ParcelTracingPort");
            BG.DPDServices.BGDPDServiceTracing.requestClient requestclientTracing = new BG.DPDServices.BGDPDServiceTracing.requestClient
            {
                auth = new BG.DPDServices.BGDPDServiceTracing.auth
                {
                    clientKey = clientKey,
                    clientNumber = clientNumber
                }

            };
            
            BG.DPDServices.BGDPDServiceTracing.stateParcels responseParcelsModel = _dpdcTracingClient.getStatesByClient(requestclientTracing);

            return responseParcelsModel;
        }

        public void StatesConfirm(long docId)
        {
            BG.DPDServices.BGDPDServiceTracing.requestConfirm requestconfirm2 = new BG.DPDServices.BGDPDServiceTracing.requestConfirm
            {
                auth = new BG.DPDServices.BGDPDServiceTracing.auth
                {
                    clientKey = clientKey,
                    clientNumber = clientNumber
                },
                docId = docId
            };
           
            string confirmresponse2 = _dpdcTracingClient.confirm(requestconfirm2);
        }

        public BG.DPDServices.BGDPDServiceTracing.stateParcels GetHistoryByDPDOrderNr(string dpdParam)
        {
            BG.DPDServices.BGDPDServiceTracing.requestDpdOrder requestDpdOrder = new BG.DPDServices.BGDPDServiceTracing.requestDpdOrder
            {
                auth = new BG.DPDServices.BGDPDServiceTracing.auth
                {
                    clientKey = clientKey,
                    clientNumber = clientNumber
                },
                dpdOrderNr = dpdParam,
                pickupYear = DateTime.Now.Year
            };
           
            BG.DPDServices.BGDPDServiceTracing.stateParcels responseParcelsByDPDOrderModel = _dpdcTracingClient.getStatesByDPDOrder(requestDpdOrder);

            return responseParcelsByDPDOrderModel;
        }
    }
}

