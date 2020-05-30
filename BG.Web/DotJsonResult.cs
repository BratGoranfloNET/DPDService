using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace BG.Web
{	
	public class DotJsonResult : JsonResult
	{
		private JsonSerializerSettings _jsonSerializerSettings = null;
				
		public DotJsonResult(JsonSerializerSettings jsonSerializerSettings = null)
		{
			if (jsonSerializerSettings == null)
				jsonSerializerSettings = new DotJsonSerializationSettings();

			_jsonSerializerSettings = jsonSerializerSettings;
		}
				
		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null)
				throw new ArgumentNullException("Invalid context");

			var response = context.HttpContext.Response;

			response.ContentType = string.IsNullOrWhiteSpace(ContentType) ? "application/json" : ContentType;

			if (ContentEncoding != null)
				response.ContentEncoding = ContentEncoding;

			string json = JsonConvert.SerializeObject(Data, _jsonSerializerSettings);

			response.Write(json);
		}
	}
}
