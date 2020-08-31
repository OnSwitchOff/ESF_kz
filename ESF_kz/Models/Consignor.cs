using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Реквизиты грузоотправителя(D 25)
	class Consignor
	{
		//Адрес(D 25.3)
		string address;

		//Наименование (D 25.2)
		string name;

		//ИИН/БИН (D 25.1)
		string tin;
	}
}
