using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVC_App.SessionExtensions
{
	public static class CustomSessions
	{
		public static void SetObject<T>(this ISession session, string key, T data)
		{
			// data stored in JSON in Serialized form
			session.SetString(key, JsonSerializer.Serialize(data));
		}

		public static T GetObject<T>(this ISession session, string key)
		{
			var data = session.GetString(key);
			if (data == null)
			{
				return default(T); // return the default instance of T 
			}
			else
			{
				return JsonSerializer.Deserialize<T>(data);
			}

		}
	}
}
