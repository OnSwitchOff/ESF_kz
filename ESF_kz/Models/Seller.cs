using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Реквизиты поставщика (B)
	class Seller:AbstractCustomer
	{
		//Адрес (B 8)
		string address;

		//Наименование банка(B1 15)
		string bank;

		//БИК (B1 14)
		//pattern value="[0-9A-Z]{8}"
		string bik;

		//БИН филиала, выписавшего ЭСФ за голову
		string branchTin;

		//Номер cвидетельства НДС (B 9.2)
		string certificateNum;

		//Серия cвидетельства НДС
		string certificateSeries;

		//Расчетный счет (B1 13)
		//pattern value="[0-9A-Z]{20}
		string iik;

		//Cтруктурное подразделение юридического лица-нерезидента (B 9.3)
		bool isBranchNonResident;

		//КБе (B1 12)
		string kbe;

		//Наименование поставщика (B 7)
		string name;

		//БИН реорганизованного лица (B 6.1)
		string reorganizedTin;

		//Доля участия (B 7.1)
		//fractionDigits value="6", totalDigits value="18"
		float shareParticipation;

		//Категориu поставщика (B 10)
		SellerType[] statuses;

		//ИИН/БИН (B 6)
		string tin;

		//Дополнительные сведения(B 11)
		string trailer;
	}
}
