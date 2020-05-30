using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BG.Web.UI.Models;
using BG.Core;
using BG.Core.Entities;
using Omu.ValueInjecter;
using BG.Web.UI.ViewModels;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using BG.Core.Resources;
using System.Threading.Tasks;
using BG.Web.UI.Extensions;



namespace BG.Web.UI.ApiControllers
{
    public partial class LoginController
    {
        [HttpGet]
        [Route("{username}/{password}", Name = "LoginGetApi")]
        public LoginJsonModel Get(string username, string password)
        {               
            LoginJsonModel view_model = new LoginJsonModel();
            return view_model;
        }
    }
}