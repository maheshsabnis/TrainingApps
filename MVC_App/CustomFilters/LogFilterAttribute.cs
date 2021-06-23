using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.CustomFilters
{
	public class LogFilterAttribute : ActionFilterAttribute
	{

		private void LogRequest(string status, RouteData route)
		{
			string controller = route.Values["controller"].ToString();
			string action = route.Values["action"].ToString();

			string logMessage = $"Current Status of Execution is {status} in Controller {controller} and action {action}";
			Debug.WriteLine(logMessage);
		}


		public override void OnActionExecuting(ActionExecutingContext context)
		{
			LogRequest("Action Executing", context.RouteData);
		}
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			LogRequest("Action Executed", context.RouteData);
		}
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			LogRequest("Result Executing", context.RouteData);
		}
		public override void OnResultExecuted(ResultExecutedContext context)
		{
			LogRequest("Result Executed", context.RouteData);
		}
	}
}
