using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ESF_kz
{
	//ЭСФ
	[Serializable]
	public class InvoiceV2 :AbstractInvoice
	{
		//Дополнительные сведения (K 43
		public string addInf;

		//Реквизиты грузополучателя (D 24)
		public ConsigneeV2 consignee;

		//Реквизиты грузоотправителя (D 23)
		public Consignor consignor;

		//Реквизиты поверенного (оператора) покупателя. Адрес места нахождения (J 41)-
		public string customerAgentAddress;

		//Документ-Дата (J 42.2)-
		public DateTime customerAgentDocDate;

		//Документ-Номер (J 42.1)-
		public string customerAgentDocNum;

		//Реквизиты поверенного(оператора) покупателя.Поверенный(J 40)-
		public string customerAgentName;

		//Реквизиты поверенного (оператора) покупателя. БИН (J 39)-
		public string customerAgentTin;

		//Получатели (УСД) (H)
		public List<ParticipantV2> customerParticipants;

		//Получатели (C)
		public List<CustomerV2> customers;

		//Дата выписки на бумажном носителе (2.1)-
		public DateTime datePaper;

		//Дата документа, подтверждающего поставку товаров (работ, услуг) (F 32.2)-
		public DateTime deliveryDocDate;

		//Номер документа, подтверждающего поставку товаров (работ, услуг) (F 32.1)-
		public string deliveryDocNum;

		//Условия поставки (E)
		public DeliveryTermV2 deliveryTerm;

		//Товары(работы, услуги) (G)
		public ProductSetV2 productSet;

		//Реквизиты государственного учреждения (F)
		public PublicOffice publicOffice;

		//Причина выписки на бумажном носителе (2.1)-
		public PaperReasonType reasonPaper;

		//Адрес места нахождения(I 37)-
		public string sellerAgentAddress;

		//Документ-Дата (I 38.2)-
		public DateTime sellerAgentDocDate;

		//Документ-Номер (I 38.1)-
		public string sellerAgentDocNum;

		//Поверенный (I 36)-
		public string sellerAgentName;

		//БИН (I 35)-
		public string sellerAgentTin;

		//Поставщики(УСД) (H)
		public List<ParticipantV2> sellerParticipants;

		//Поставщики (B)
		public List<SellerV2> sellers;

		public InvoiceV2() { }
	}
}
