using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVC_App.CustomFilters
{
	public class MyExceptionFilterAttribute : ExceptionFilterAttribute
	{
		private readonly IModelMetadataProvider modelMetadataProvider;
		/// <summary>
		/// IModelMetadataProvider is the Contract interface used by Http Pipline to
		/// manage the Model Binding when Actions are executed
		/// </summary>
		/// <param name="modelMetadataProvider"></param>
		public MyExceptionFilterAttribute(IModelMetadataProvider modelMetadataProvider)
		{
			this.modelMetadataProvider = modelMetadataProvider;
		}
		/// <summary>
		/// Logic for handling Excpetion
		/// </summary>
		/// <param name="context"></param>
		public override void OnException(ExceptionContext context)
		{
			// 1. Handle the exception so that the Filter Pipeline is completed
			context.ExceptionHandled = true;
			// 2. Read the Error Message
			var messsage = context.Exception.InnerException.Message;
			// generate result
			// 3 define a View Result Object
			var viewResult = new ViewResult() { ViewName = "Error"};
			// 4, to pass data to View define a ViewDataDictionry object
			var viewData = new ViewDataDictionary(modelMetadataProvider,context.ModelState);
			viewData["ControllerName"] = context.RouteData.Values["controller"].ToString();
			viewData["ActionName"] = context.RouteData.Values["action"].ToString();
			viewData["ExceptionMessage"] = messsage;
			// 5. set the ViewDataDictionary to the ViewResult
			viewResult.ViewData = viewData;
			// 6. set the result
			context.Result = viewResult;
		}
	}
}
