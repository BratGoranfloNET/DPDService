using BG.Core.Entities;
using System.Net;
using System.Web.Mvc;
using Omu.ValueInjecter;
using BG.Core.Resources;
using BG.Web.UI.Models;
using BG.Services;
// using auth = BG.Web.UI.BGDPDServiceEventTracking.auth;

namespace BG.Web.UI.Controllers
{
	
	public partial class DashboardController
    {


        [HttpGet]
        [Route("deletealldpd", Name = "DashboardDeleteAllDpdPost")]
        public ActionResult DeleteAllDpd()
        {

            //_eventtrackingRepository.DeleteAll(); 
            //_eventtrackingtypeRepository.DeleteAll();
            //_eventtrackingparameterRepository.DeleteAll();
            //_eventtrackingunitloadRepository.DeleteAll();

            //_stateparcelsRepository.DeleteAll();
            //_stateRepository.DeleteAll();

            //_stateparcelsunitedRepository.DeleteAll();

            // _stateunitedRepository.DeleteAll();

            Feedback.AddMessageWarning("ВСЕ ДАННЫЕ ПО СТАТУСАМ УДАЛЕНЫ !!!");

            return RedirectToAction("Index", nameof(DashboardController).RemoveControllerSuffix());
        }

	}
}