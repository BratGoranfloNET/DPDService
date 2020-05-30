using NLog;
using BG.Web.UI.Attributes;
using BG.Web.UI.Controllers;
using System;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.IO;
using System.Linq;

namespace BG.Web.UI
{
	/// <summary>
	/// Base configuration class.
	/// </summary>
	public class MvcApplication : HttpApplication
	{
		/// <summary>
		/// Tracks if the application started successfully.
		/// </summary>
		private static bool Initialized { get; set; } = false;

		/// <summary>
		/// Called whenever a new request starts.
		/// </summary>
		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			// Create a new id for the current request activity.
			// This helps with errors and user history tracking.
			Trace.CorrelationManager.ActivityId = Guid.NewGuid();
		}

		/// <summary>
		/// Called once when the application starts.
		/// </summary>
		protected void Application_Start()
		{

            GlobalConfiguration.Configure(WebApiConfig.Register);
			            

            /*
			 * View Engines
			 * - Keep only the custom razor engine
			 */
            ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new DotRazorViewEngine());

			/*
			 * Application filters
			 * - Register global filters
			 */
			GlobalFilters.Filters.Add(new LockScreenAgentAttribute());

			/*
			 * Routes
			 * - Register areas
			 * - Configure global routes
			 * - Controller specific routes will use attribute routes
			 */
			AreaRegistration.RegisterAllAreas();

			// Common settings
			RouteTable.Routes.LowercaseUrls = true;
			RouteTable.Routes.AppendTrailingSlash = true;

			// Set ignores
			RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// Map attributes
			RouteTable.Routes.MapMvcAttributeRoutes();

			// Add general routes
			RouteTable.Routes.MapRoute(
				name: "Error",
				url: "error/{code}",
				defaults: new { controller = "Errors", action = "Global", code = UrlParameter.Optional }
			);

			// Catch all
			RouteTable.Routes.MapRoute(
				name: "Default",
				url: "{*path}",
				defaults: new { controller = "Errors", action = "Global", code = 404 }
			);

			// Set intitialization status
			Initialized = true;
		}


        protected void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Add("__MyAppSession", string.Empty);
        }


        /// <summary>
        /// Called each time an exception is not correctly handled by the application
        /// </summary>
        protected void Application_Error()
		{
			var exception = Server.GetLastError();
			var httpException = exception as HttpException;          
            var _logger = LogManager.GetCurrentClassLogger();
            _logger.Log(LogLevel.Fatal, exception, exception.Message);

            if (Initialized)
			{
				var code = httpException?.GetHttpCode() ?? 500;

				if (exception is HttpAntiForgeryException)
					code = (int)HttpStatusCode.MethodNotAllowed;

				Server.ClearError();

				Response.Clear();

				var data = new RouteData();

				data.Values["ex"] = exception;
				data.Values["action"] = nameof(ErrorsController.Global);
				data.Values["controller"] = nameof(ErrorsController).RemoveControllerSuffix();

				var controller = DependencyResolver.Current.GetService<ErrorsController>() as IController;

				var requestContext = new RequestContext(new HttpContextWrapper(Context), data);

				controller.Execute(requestContext);
			}
		}


        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
                // config.Filters.Add(new ValidationActionFilterAttribute());
                // config.Filters.Add(new OnApiExceptionAttribute());

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",                   
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );


               // config.Routes.MapHttpRoute(
               //    name: "LoginApi",
               //    // routeTemplate: "api/{controller}/{id}",
               //    routeTemplate: "api/{controller}/{username}/{password}",
               //    defaults: new { username = RouteParameter.Optional, password = RouteParameter.Optional }
               //);



                // var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
                // config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

                GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));


            }
        }
        


    }
}
