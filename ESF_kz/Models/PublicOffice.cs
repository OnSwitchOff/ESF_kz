using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Реквизиты государственного учреждения (C1)
	class PublicOffice
	{
		//Реквизиты государственного учреждения (C1)
		//default="KKMFKZ2A"
		string bik = "KKMFKZ2A";

		//ИИК (C1 21)
		//pattern value="[0-9A-Z]{20}
		string iik;

		//Назначение платежа (C1 23)
		//pattern value = "[^\s:][^:\n\r\t]*"
		string payPurpose;

		//Код товаров (работ, услуг) (C1 22)
		string productCode;
	}
}
