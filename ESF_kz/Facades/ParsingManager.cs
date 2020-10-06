using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	static class ParsingManager
	{
		internal static float ParseStringToFLoat(string str)
		{
			return float.Parse(str);
		}

		internal static T ParseStringToEnum<T>(string str) where T: Enum
		{
			return  (T)Enum.Parse(typeof(T), str);
		}		
	}
}
