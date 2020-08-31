using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Реквищиты получателя (C)
	class CustomerV2:AbstractCustomer
	{
		//Адрес(C 18)+
		string address;

		//БИН филиала, выписавшего ЭСФ за голову
		string branchTin;

		//Код страны получателя. Обязательно заполняется если установлен статус CustomerType.NONRESIDENT и SellerType.EXPORTER (C 18.1)+
		string countryCode;

		//Наименование получателя (C 17)+
		string name;

		//БИН реорганизованного лица (C 16.1)-
		string reorganizedTin;

		//Доля участия (С 17.1)
		//fractionDigits value="6", totalDigits value="18"
		float shareParticipation;

		//Категории получателя (С 20)+
		List<CustomerType> statuses;

		//ИИН/БИН. Может отсутствовать если установлен статус CustomerType.NONRESIDENT (C 16)+
		string tin;

		//Дополнительные сведения(C 19)+
		string trailer;
	}
}
