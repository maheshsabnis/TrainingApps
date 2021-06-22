using Core_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core_API.CustomMiddlewares
{

	public class ExceptionInfo
	{
		public int ExceptionStatusCode { get; set; }
		public string ExceptionMessage { get; set; }
	}

	/// <summary>
	/// Custom Middleware Logic class
	/// </summary>
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		/// <summary>
		/// Logic
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				// if no error then continue with next middlewares in pipeline
				await _next(context);
			}
			catch (Exception ex)
			{
				// if exception occures then catch it and generate response
				context.Response.StatusCode = 500;
 

				var exceptionDetails = new ExceptionInfo()
				{
					 ExceptionStatusCode = context.Response.StatusCode,
					 ExceptionMessage = ex.Message
				};
				// serialize the Object so that it can be written into the response
				string responseMessage = JsonSerializer.Serialize(exceptionDetails);

				// write the response
				await context.Response.WriteAsync(responseMessage);
			}
		}
	}

	/// <summary>
	/// extension  class that will register the Custom Middleware
	/// </summary>
	public static class CustomMiddlewareExtensions
	{
		public static void UseExceptionMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}
}
