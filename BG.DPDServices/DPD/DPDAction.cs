using System;
using System.Collections.Generic;
using System.Linq;
using BG.Core.Entities;
using BG.Core.Repositories;
using Omu.ValueInjecter;
using BG.Core;
using BG.DPDServices.BGDPDServiceEventTracking;

namespace BG.DPDServices
{
    public class DPDAction
    {

        private IEventTrackingRepository _eventtrackingRepository = null;
        private IEventTrackingTypeRepository _eventtrackingtypeRepository = null;
        private IEventTrackingParameterRepository _eventtrackingparameterRepository = null;
        private IEventTrackingUnitLoadRepository _eventtrackingunitloadRepository = null;
        private IStateParcelsRepository _stateparcelsRepository = null;
        private IStateRepository _stateRepository = null;
        private IStateParcelsUnitedRepository _stateparcelsunitedRepository = null;
        private IStateUnitedRepository _stateunitedRepository = null;
        private IStateHistoryRepository _statehistoryRepository = null;
        private IEventsRepository _eventsRepository = null;

        public DPDAction(

            IEventTrackingRepository eventtrackingRepository,
            IEventTrackingTypeRepository eventtrackingtypeRepository,
            IEventTrackingParameterRepository eventtrackingparameterRepository,
            IEventTrackingUnitLoadRepository eventtrackingunitloadRepository,
            IStateParcelsRepository stateparcelsRepository,
            IStateRepository stateRepository,
            IStateParcelsUnitedRepository stateparcelsunitedRepository,
            IStateUnitedRepository stateunitedRepository,
            IStateHistoryRepository statehistoryRepository,
            IEventsRepository eventsRepository)
        {

            _eventtrackingRepository = eventtrackingRepository;
            _eventtrackingtypeRepository = eventtrackingtypeRepository;
            _eventtrackingparameterRepository = eventtrackingparameterRepository;
            _eventtrackingunitloadRepository = eventtrackingunitloadRepository;
            _stateparcelsRepository = stateparcelsRepository;
            _stateRepository = stateRepository;
            _stateparcelsunitedRepository = stateparcelsunitedRepository;
            _stateunitedRepository = stateunitedRepository;
            _statehistoryRepository = statehistoryRepository;
            _eventsRepository = eventsRepository;

        }


        public DPDActionResult Go()
        {
            DPDActionResult dpdresult = new DPDActionResult();
            dpdresult.IsOk = false;
            dpdresult.Message = " ";

            // Удаляем временные данные после последнего сеанса
            _eventtrackingRepository.DeleteAll();
            _eventtrackingtypeRepository.DeleteAll();
            _eventtrackingparameterRepository.DeleteAll();
            _eventtrackingunitloadRepository.DeleteAll();
            _stateparcelsRepository.DeleteAll();
            _stateRepository.DeleteAll();
            _stateparcelsunitedRepository.DeleteAll();

            DPDWebService dpd = new DPDWebService();
            eventTackingResponse responseEventModel = null;

            do
            {

                try
                {
                    responseEventModel = dpd.GetDPDEvents();
                }
                catch (Exception ex)
                {
                    dpdresult.IsOk = false;
                    dpdresult.Message = ex.Message;
                    return dpdresult;
                }

                EventTracking entityEventTracking = new EventTracking();

                if (responseEventModel != null)
                {
                    //1
                    entityEventTracking = Mapper.Map<EventTracking>(responseEventModel);
                    entityEventTracking = _eventtrackingRepository.Create(entityEventTracking);

                    if (responseEventModel.@event != null)
                    {

                        foreach (eventType evettype in responseEventModel.@event)
                        {
                            //2
                            EventTrackingType entityEventTrackingType = new EventTrackingType();
                            entityEventTrackingType = Mapper.Map<EventTrackingType>(evettype);
                            entityEventTrackingType.EventTrackingId = entityEventTracking.Id;
                            entityEventTrackingType = _eventtrackingtypeRepository.Create(entityEventTrackingType);

                            int typeId = entityEventTrackingType.Id;


                            //UNITED/////////////////////////////////////////////
                            //IEnumerable<StateUnited> stateUnitedsAll11 = _stateunitedRepository.GetAll();
                            //StateUnited stateunited11 = stateUnitedsAll11.Where(x => x.dpdOrderNr == entityEventTrackingType.dpdOrderNr).FirstOrDefault();


                            StateUnited stateunitedUPDATE = _stateunitedRepository.GetByDPDParam(entityEventTrackingType.dpdOrderNr);

                            StateUnited stateunitedCREATE = new StateUnited();
                            

                            if (stateunitedUPDATE == null) // Create
                            {
                                //entityStateUnited = Mapper.Map<StateUnited>(state);
                                stateunitedCREATE.dpdOrderNr = entityEventTrackingType.dpdOrderNr;
                                stateunitedCREATE.Count = 1;
                                stateunitedCREATE.EventName = entityEventTrackingType.eventName;
                                stateunitedCREATE.EventReason = entityEventTrackingType.reasonName;
                                stateunitedCREATE = _stateunitedRepository.Create(stateunitedCREATE);
                              

                            }
                            else // Update
                            {

                                stateunitedUPDATE.Count = stateunitedUPDATE.Count + 1;
                                stateunitedUPDATE.EventName = entityEventTrackingType.eventName;
                                stateunitedUPDATE.EventReason = entityEventTrackingType.reasonName;


                                if (entityEventTrackingType.eventCode == "OrderProblem" ||
                                    entityEventTrackingType.eventCode == "OrderDeliveryProblem")
                                {
                                    stateunitedUPDATE.ProblemName = entityEventTrackingType.eventName;
                                   
                                    IEnumerable<Event> calendarEvents = _eventsRepository.GetAll();
                                    Event calendarEventUpdate = calendarEvents.Where(x => x.StateUnitedId == stateunitedUPDATE.Id).FirstOrDefault();
                                                                       

                                    if (calendarEventUpdate != null) // Update Calendar
                                    {

                                        calendarEventUpdate.StartDate = new DateTimeOffset(DateTime.Now);
                                        calendarEventUpdate.EndDate = new DateTimeOffset(DateTime.Now.AddHours(1));
                                        calendarEventUpdate.Color = "#ff8243";
                                        calendarEventUpdate.Description = "Проблема";

                                        _eventsRepository.Update(calendarEventUpdate);                                                                               
                                       
                                    }
                                    else    // Create Calendar Event
                                    {
                                        Event calendarEvent = new Event
                                        {
                                            StateUnitedId = stateunitedUPDATE.Id,
                                            StartDate = new DateTimeOffset(DateTime.Now),
                                            EndDate = new DateTimeOffset(DateTime.Now.AddHours(1)), //new DateTimeOffset(stateunitedUPDATE.planDeliveryDate),
                                            Color = "#ff7033",
                                            Description = stateunitedUPDATE.newState,
                                            Name = stateunitedUPDATE.dpdOrderNr,
                                            AllDay = true

                                        };

                                        _eventsRepository.Create(calendarEvent);

                                    }

                                }

                                stateunitedUPDATE.Name = stateunitedUPDATE.Name + "1";
                                _stateunitedRepository.Update(stateunitedUPDATE);

                            }


                            if (evettype.parameter != null)
                            {
                                foreach (parameterType parametertype in evettype.parameter)
                                {
                                    //3
                                    EventTrackingParameter entityEventTrackingParameter = new EventTrackingParameter();
                                    entityEventTrackingParameter = Mapper.Map<EventTrackingParameter>(parametertype);
                                    entityEventTrackingParameter.EventTrackingTypeId = entityEventTrackingType.Id;
                                    entityEventTrackingParameter.Name = entityEventTrackingType.dpdOrderNr;
                                    entityEventTrackingParameter = _eventtrackingparameterRepository.Create(entityEventTrackingParameter);



                                    StateUnited stateunitedUPDATE_PARAM = new StateUnited();
                                    if (stateunitedCREATE != null )
                                    {
                                        stateunitedUPDATE_PARAM = stateunitedCREATE; 
                                    }
                                    else
                                    {
                                        stateunitedUPDATE_PARAM = stateunitedUPDATE;
                                    }                                             
                                    

                                    if (stateunitedUPDATE_PARAM != null) // PARAMETERS UPDATE
                                    {                                      

                                        switch (entityEventTrackingParameter.paramName)
                                        {
                                            case "DeliveryAddress":

                                                stateunitedUPDATE_PARAM.DeliveryAddress = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "DeliveryCity":

                                                stateunitedUPDATE_PARAM.DeliveryCity = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "DeliveryVariant":

                                                stateunitedUPDATE_PARAM.DeliveryVariant = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "DeliveryPointCode":

                                                stateunitedUPDATE_PARAM.DeliveryPointCode = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;
                                            case "DeliveryInterval":

                                                stateunitedUPDATE_PARAM.DeliveryInterval = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "PickupAddress":

                                                stateunitedUPDATE_PARAM.PickupAddress = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "PickupCity":

                                                stateunitedUPDATE_PARAM.PickupCity = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "PointCity":

                                                stateunitedUPDATE_PARAM.PointCity = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "Consignee":

                                                stateunitedUPDATE_PARAM.Consignee2 = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "Consignor":

                                                stateunitedUPDATE_PARAM.Consignor = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;



                                            case "ReasonName":

                                                stateunitedUPDATE_PARAM.ReasonName = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "RejectionReason":

                                                stateunitedUPDATE_PARAM.RejectionReason = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "OrderType":

                                                stateunitedUPDATE_PARAM.OrderType = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;

                                            case "MomentLocZone":

                                                stateunitedUPDATE_PARAM.MomentLocZone = entityEventTrackingParameter.valueString;
                                                _stateunitedRepository.Update(stateunitedUPDATE_PARAM);
                                                break;                                                                                                                                            


                                            default:
                                                break;

                                        }

                                    }                                    


                                    if (parametertype.value != null)
                                    {
                                        foreach (eventTrackingUnitLoad unitload in parametertype.value)
                                        {
                                            //4
                                            EventTrackingUnitLoad entityEventTrackingUnitLoad = new EventTrackingUnitLoad();
                                            entityEventTrackingUnitLoad = Mapper.Map<EventTrackingUnitLoad>(unitload);
                                            entityEventTrackingUnitLoad.EventTrackingParameterId = entityEventTrackingParameter.Id;
                                            entityEventTrackingUnitLoad = _eventtrackingunitloadRepository.Create(entityEventTrackingUnitLoad);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                /////// Подтверждаем, что получили статусы  по эвентам   
                try
                {
                    dpd.EventConfirm(entityEventTracking.docId);
                }
                catch (Exception ex)
                {
                    dpdresult.IsOk = false;
                    dpdresult.Message = ex.Message + "  ПОВТОРИТЕ ЗАПРОС ЧЕРЕЗ 5 МИН.";
                    return dpdresult;                    
                }


            } while (!responseEventModel.resultComplete);


            BG.DPDServices.BGDPDServiceTracing.stateParcels responseParcelsModel = null;

            do
            {

                try
                {
                    responseParcelsModel = dpd.GetDPDStates();
                }
                catch (Exception ex)
                {
                    dpdresult.IsOk = false;
                    dpdresult.Message = ex.Message ;
                    return dpdresult;
                }


                StateParcels entityStateParcels = new StateParcels();

                if (responseParcelsModel != null)
                {
                    //5
                    entityStateParcels = Mapper.Map<StateParcels>(responseParcelsModel);
                    entityStateParcels = _stateparcelsRepository.Create(entityStateParcels);

                    if (responseParcelsModel.states != null)
                    {

                        foreach (BG.DPDServices.BGDPDServiceTracing.stateParcel state in responseParcelsModel.states)
                        {
                            //6
                            State entityState = new State();
                            entityState = Mapper.Map<State>(state);
                            entityState.StateParcelsId = entityStateParcels.Id;
                            entityState = _stateRepository.Create(entityState);
                        }
                    }
                }


                // UNITED   &  HISTORY //////////////////////////////////////////////////////////////////////////////////////////////////// 

                if (responseParcelsModel.states != null)
                {

                    foreach (BG.DPDServices.BGDPDServiceTracing.stateParcel state in responseParcelsModel.states)
                    {

                        StateHistory entityStateHistory = new StateHistory();
                        entityStateHistory = Mapper.Map<StateHistory>(state);
                        entityStateHistory = _statehistoryRepository.Create(entityStateHistory);
                                                
                        StateUnited stateunited = _stateunitedRepository.GetByDPDParam(state.dpdOrderNr);

                        if (stateunited == null) // Create
                        {
                            StateUnited entityStateUnited = new StateUnited();
                            entityStateUnited = Mapper.Map<StateUnited>(state);
                            entityStateUnited.Count = 1;
                            entityStateUnited = _stateunitedRepository.Create(entityStateUnited);
                                                   
                            if (entityStateUnited.newState == "Problem")
                            {
                                Event calendarEvent = new Event
                                {
                                    StateUnitedId = entityStateUnited.Id,
                                    StartDate = new DateTimeOffset(DateTime.Now),
                                    EndDate = new DateTimeOffset(DateTime.Now.AddHours(1)), //new DateTimeOffset(entityStateUnited.planDeliveryDate),
                                    Color = "#ff0000",
                                    Description = entityStateUnited.newState,
                                    Name = entityStateUnited.dpdOrderNr,
                                    AllDay = true

                                };

                                _eventsRepository.Create(calendarEvent);
                            }                                                      
                        
                        }
                        else // Update
                        {

                            if (state.transitionTime > stateunited.transitionTime) // если Статус свежее, тогда обновляем
                            {

                                stateunited.Count = stateunited.Count + 1;
                                stateunited.Name = stateunited.Name + "2";
                                stateunited.clientOrderNr = state.clientOrderNr;
                                stateunited.clientParcelNr = state.clientParcelNr;
                                stateunited.dpdParcelNr = state.dpdParcelNr;
                                stateunited.pickupDate = state.pickupDate;
                                stateunited.planDeliveryDate = state.planDeliveryDate;
                                stateunited.isReturn = state.isReturn;
                                stateunited.isReturnSpecified = state.isReturnSpecified;
                                stateunited.planDeliveryDateSpecified = state.planDeliveryDateSpecified;
                                stateunited.newState = state.newState;
                                stateunited.transitionTime = state.transitionTime;
                                stateunited.terminalCode = state.terminalCode;
                                stateunited.terminalCity = state.terminalCity;
                                stateunited.incidentCode = state.incidentCode;
                                stateunited.incidentName = state.incidentName;
                                stateunited.consignee = state.consignee;

                                _stateunitedRepository.Update(stateunited);
                                
                                IEnumerable<Event> calendarEvents = _eventsRepository.GetAll();
                                Event calendarEventUpdate = calendarEvents.Where(x => x.StateUnitedId == stateunited.Id).FirstOrDefault();

                                if (calendarEventUpdate != null)
                                {                               
                                    if (stateunited.newState == "Delivered")
                                    {
                                        calendarEventUpdate.StartDate = new DateTimeOffset(DateTime.Now);
                                        calendarEventUpdate.EndDate = new DateTimeOffset(DateTime.Now.AddHours(1)); //new DateTimeOffset(stateunited.transitionTime);
                                        calendarEventUpdate.Color = "#008c95";
                                        calendarEventUpdate.Description = "Доставлено";

                                       _eventsRepository.Update(calendarEventUpdate);

                                    }
                                    else if (stateunited.newState == "Problem")
                                    {
                                        calendarEventUpdate.StartDate = new DateTimeOffset(DateTime.Now);
                                        calendarEventUpdate.EndDate = new DateTimeOffset(DateTime.Now.AddHours(1)); //new DateTimeOffset(stateunited.transitionTime);
                                        calendarEventUpdate.Color = "#ff0000";
                                        calendarEventUpdate.Description = "Проблема";
                                       _eventsRepository.Update(calendarEventUpdate);

                                    }                                    
                                }
                                else
                                {
                                     if (stateunited.newState == "Problem")
                                    {                                        

                                        Event calendarEvent = new Event
                                        {
                                            StateUnitedId = stateunited.Id,
                                            StartDate = new DateTimeOffset(DateTime.Now),
                                            EndDate = new DateTimeOffset(DateTime.Now.AddHours(1)), //new DateTimeOffset(stateunited.planDeliveryDate),
                                            Color = "#ff0000",
                                            Description = stateunited.newState,
                                            Name = stateunited.dpdOrderNr,
                                            AllDay = true
                                        };

                                        _eventsRepository.Create(calendarEvent);
                                    }
                                }
                            }
                        }
                    }
                }

                ////// Подтверждаем, что получили статусы по посылкам           
                try
                {
                   dpd.StatesConfirm(responseParcelsModel.docId);
                }
                catch (Exception ex)
                {
                    dpdresult.IsOk = false;
                    dpdresult.Message = ex.Message + "  ПОВТОРИТЕ ЗАПРОС ЧЕРЕЗ 5 МИН.";
                    return dpdresult;
                }

            } while (!responseParcelsModel.resultComplete);            

            dpdresult.IsOk = true;
            dpdresult.Message = "СТАТУСЫ ОБНОВЛЕНЫ !!!";            

            return dpdresult;

        }
    }
}
