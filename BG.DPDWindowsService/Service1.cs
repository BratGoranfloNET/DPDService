using System;
using System.ServiceProcess;
using System.IO;
using System.Timers;
using BG.Core;
using BG.Data;
using BG.Core.Repositories;
using BG.DPDServices;
using BG.Data.Events;

namespace BG.DPDWindowsService
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 900000; 
            timer.Enabled = true;
        }

        protected override void OnStop()
        {

        }             

       
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {

                IDbConnectionFactory dbConnectionFactory = new ConnectionFactory();                

                EventTrackingRepository _eventtrackingRepository = new EventTrackingRepository(dbConnectionFactory);
                EventTrackingTypeRepository _eventtrackingtypeRepository = new EventTrackingTypeRepository(dbConnectionFactory);
                EventTrackingParameterRepository _eventtrackingparameterRepository = new EventTrackingParameterRepository(dbConnectionFactory);
                EventTrackingUnitLoadRepository _eventtrackingunitloadRepository = new EventTrackingUnitLoadRepository(dbConnectionFactory);

                StateParcelsRepository _stateparcelsRepository = new StateParcelsRepository(dbConnectionFactory);
                StateRepository _stateRepository = new StateRepository(dbConnectionFactory);
                StateUnitedRepository _stateunitedRepository = new StateUnitedRepository(dbConnectionFactory);
                StateParcelsUnitedRepository _stateparcelsunitedRepository = new StateParcelsUnitedRepository(dbConnectionFactory);
                StateHistoryRepository _statehistoryRepository = new StateHistoryRepository(dbConnectionFactory);

                EventsRepository _eventsRepository = new EventsRepository(dbConnectionFactory);

                DPDAction dpd_action = new DPDAction(
                _eventtrackingRepository,
                _eventtrackingtypeRepository,
                _eventtrackingparameterRepository,
                _eventtrackingunitloadRepository,
                _stateparcelsRepository,
                _stateRepository,
                _stateparcelsunitedRepository,
                _stateunitedRepository,
                _statehistoryRepository,
                _eventsRepository

           );

                DPDActionResult result = dpd_action.Go();
                

                if (result.IsOk)
                {
                    WriteToFile("OK ! " + DateTime.Now);
                }
                else
                {
                    WriteToFile("Что-то с пошло не так !!!" + result.Message + DateTime.Now);
                }

            }
            catch(Exception ex)
            {
                WriteToFile("Что-то с сервисом пошло не так !!!" + ex.Message + DateTime.Now);
            }
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";

            if (!File.Exists(filepath))            {
                  
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
