using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	class InvoiceV1:AbstractInvoice
	{
		//Дополнительные сведения (K 43)+
		string addInf;

		//Реквизиты грузополучателя (D 24)+
		ConsigneeV1 consignee;

		//Реквизиты грузоотправителя (D 23)+
		Consignor consignor;

		//Получатели (УСД) (H)+
		List<ParticipantV1> customerParticipants;

		//Получатели (C)+
		List<CustomerV1> customers;

		//Условия поставки (E)+
		DeliveryTermV1 deliveryTerm;

		//Товары(работы, услуги) (G)+
		ProductSetV1 productSet;

		//Реквизиты государственного учреждения (F)+
		PublicOffice publicOffice;

		//Поставщики(УСД) (H)+
		List<ParticipantV1> sellerParticipants;

		//Поставщики (B)+
		List<SellerV1> sellers;
	}
}
