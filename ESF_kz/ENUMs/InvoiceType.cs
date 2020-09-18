using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Тип ЭСФ
	public	enum InvoiceType
	{
		ORDINARY_INVOICE,//Основной ЭСФ
		FIXED_INVOICE,//Исправленный ЭСФ (A 4)
		ADDITIONAL_INVOICE//Дополнительный ЭСФ (A 5)
	}
}
