using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz

{
	//Служит для связки исправленного/дополнительного ЭСФ с основным
	[Serializable]
	public class RelatedInvoice
	{
		//Дата выписки ЭСФ (A 4.1, A 5.1)
		public DateTime date;

		//Исходящий номер ЭСФ в бухгалтерии отправителя (A 4.2, A 5.2)
		//pattern value="[0-9]{1,30}
		public string num;

		//Регистрационный номер ЭСФ на которую ссылается данная ЭСФ
		public string registrationNumber;

		public RelatedInvoice() { }
	}
}
