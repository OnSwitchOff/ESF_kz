using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ESF_kz
{
	//Базовая информация об ЭСФ для всех версий ЭСФ в системе
	public abstract class AbstractInvoice
	{
		//Дата выписки ЭСФ (A 2)
		
		[XmlIgnore]
		public DateTime date;

		[XmlElement("date")]
		public string SomeDateString
		{
			get { return this.date.ToString("dd.mm.yyyy"); }
			set { this.date = DateTime.Parse(value); }
		}

		//Тип ЭСФ
		public InvoiceType invoiceType;

		//Исходящий номер ЭСФ в бухгалтерии отправителя
		//pattern value="[0-9]{1,30}
		public string num;

		//ФИО оператора отправившего ЭСФ
		//{0,200}
		public string operatorFullname;

		//Служит для связки исправленного/дополнительного ЭСФ с основным
		public RelatedInvoice relatedInvoice;

		//Дата совершения оборота (A 3)
		public DateTime turnoverDate;
	}
}
