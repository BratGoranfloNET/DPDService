using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BG.Web.UI.Extensions
{
    public class StatusTranslator
    {

        public static string Translate(string EngStatus)
        {
            string RuStatus = "";
            Dictionary<string, string> Status =  new Dictionary<string, string>();

            Status.Add("OnRoad", "В пути");
            Status.Add("Delivering", "Доставляется");

            Status.Add("OnTerminal", "На транзитном терминале");
            Status.Add("OnTerminalPickup", "На терминале приема");
            Status.Add("OnTerminalDelivery", "На терминале доставки");           
            Status.Add("ReturnedFromDelivery", "Возвращена с доставки");
            Status.Add("Problem", "Проблема");
            Status.Add("Delivered", "Доставлено");


            if (EngStatus != null)
            {
                if (Status.ContainsKey(EngStatus))
                {
                    RuStatus = Status[EngStatus];
                    return RuStatus;
                }
                else
                {
                    return EngStatus;
                }              
               
            }

            return EngStatus;

        }

    }

}