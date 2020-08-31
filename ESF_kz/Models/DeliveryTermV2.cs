using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Условия поставки (E)
	class DeliveryTermV2
	{
		//Дата договора(контракт) на поставку товаров (работ, услуг) (E 27.4)+
		DateTime contractDate;

		//Номер договора(контракт) на поставку товаров (работ, услуг) (E 27.3)+
		string contractNum;

		//Условия поставки(E 31.1)-
		string deliveryConditionCode;

		//Пункт назначения поставляемых товаров (работ, услуг) (E 31)+
		string destination;

		//Договор/без договора(E 27.1 - true, E27.2 - false)
		bool hasContract;

		//Условия оплаты по договору (E 28)+
		string term;

		//Способ отправления (E 29)
		string transportTypeCode;

		//Номер доверенности на поставку товаров (работ, услуг) (E 30.1)+
		string warrant;

		//Дата доверенности на поставку товаров(работ, услуг) (E 30.2)+
		DateTime warrantDate;
	}
}
