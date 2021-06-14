using System;
using System.Collections.Generic;
using System.Text;

namespace CS_DB_Access
{
	public class BizLogic
	{
		IService serv;
		public BizLogic(IService serv)
		{
			this.serv = serv;
		}

		public bool IsCategoryExist(int id)
		{
			var res = serv.GetCategory(id);
			return res;
		}
	}
}
