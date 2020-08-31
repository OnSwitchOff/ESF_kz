using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Базовая информация об ЭСФ для всех версий ЭСФ в системе
	abstract class AbstractInvoice
	{
		//Дата выписки ЭСФ (A 2)
		DateTime date;

		//Тип ЭСФ
		InvoiceType invoiceType;

		//Исходящий номер ЭСФ в бухгалтерии отправителя
		//pattern value="[0-9]{1,30}
		string num;

		//ФИО оператора отправившего ЭСФ
		//{0,200}
		string operatorFullname;

		//Служит для связки исправленного/дополнительного ЭСФ с основным
		RelatedInvoice relatedInvoice;

		//Дата совершения оборота (A 3)
		DateTime turnoverDate;
	}
}
