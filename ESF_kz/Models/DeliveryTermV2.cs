using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Условия поставки (E)
	[Serializable]
	public class DeliveryTermV2
	{
		//Дата договора(контракт) на поставку товаров (работ, услуг) (E 27.4)+
		public DateTime contractDate;

		//Номер договора(контракт) на поставку товаров (работ, услуг) (E 27.3)+
		public string contractNum;

		//Условия поставки(E 31.1)-
		public string deliveryConditionCode;

		//Пункт назначения поставляемых товаров (работ, услуг) (E 31)+
		public string destination;

		//Договор/без договора(E 27.1 - true, E27.2 - false)
		public bool hasContract;

		//Условия оплаты по договору (E 28)+
		public string term;

		//Способ отправления (E 29)
		public string transportTypeCode;

		//Номер доверенности на поставку товаров (работ, услуг) (E 30.1)+
		public string warrant;

		//Дата доверенности на поставку товаров(работ, услуг) (E 30.2)+
		public DateTime warrantDate;

		public DeliveryTermV2() { }
	}
}
