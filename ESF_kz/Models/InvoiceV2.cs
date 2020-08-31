using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//ЭСФ
	class InvoiceV2 :AbstractInvoice
	{
		//Дополнительные сведения (K 43
		string addInf;

		//Реквизиты грузополучателя (D 24)
		ConsigneeV2 consignee;

		//Реквизиты грузоотправителя (D 23)
		Consignor consignor;

		//Реквизиты поверенного (оператора) покупателя. Адрес места нахождения (J 41)-
		string customerAgentAddress;

		//Документ-Дата (J 42.2)-
		DateTime customerAgentDocDate;

		//Документ-Номер (J 42.1)-
		string customerAgentDocNum;

		//Реквизиты поверенного(оператора) покупателя.Поверенный(J 40)-
		string customerAgentName;

		//Реквизиты поверенного (оператора) покупателя. БИН (J 39)-
		string customerAgentTin;

		//Получатели (УСД) (H)
		List<ParticipantV2> customerParticipants;

		//Получатели (C)
		List<CustomerV2> customers;

		//Дата выписки на бумажном носителе (2.1)-
		DateTime datePaper;

		//Дата документа, подтверждающего поставку товаров (работ, услуг) (F 32.2)-
		DateTime deliveryDocDate;

		//Номер документа, подтверждающего поставку товаров (работ, услуг) (F 32.1)-
		string deliveryDocNum;

		//Условия поставки (E)
		DeliveryTermV2 deliveryTerm;

		//Товары(работы, услуги) (G)
	    ProductSetV2 productSet;

		//Реквизиты государственного учреждения (F)
		PublicOffice publicOffice;

		//Причина выписки на бумажном носителе (2.1)-
		PaperReasonType reasonPaper;

		//Адрес места нахождения(I 37)-
		string sellerAgentAddress;

		//Документ-Дата (I 38.2)-
		DateTime sellerAgentDocDate;

		//Документ-Номер (I 38.1)-
		string sellerAgentDocNum;

		//Поверенный (I 36)-
		string sellerAgentName;

		//БИН (I 35)-
		string sellerAgentTin;

		//Поставщики(УСД) (H)
		List<ParticipantV2> sellerParticipants;

		//Поставщики (B)
		List<SellerV2> sellers;
	}
}
