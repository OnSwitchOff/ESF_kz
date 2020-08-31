using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Реквизиты грузополучателя (D 26)
	class ConsigneeV2
	{
		//Адрес (D 26.3)+
		string address;

		//Код страны(D 26.4)-
		string countryCode;

		//Наименование (D 26.2)+
		string name;

		//ИИН/БИН (D 26.1)+
		string tin;
	}
}
