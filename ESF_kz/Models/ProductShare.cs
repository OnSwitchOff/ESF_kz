using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Информация по товарам (работам, услугам)
	class ProductShare:AbstractProductShare
	{
		//Дополнительные данные(H 18)
		string additional;

		//Акциз-Сумма (H 10)
		//fractionDigits value="2", totalDigits value="17"
		float exciseAmount;

		//НДС-Сумма(H 13)
		//fractionDigits value="2", totalDigits value="17"
		float ndsAmount;

		//Стоимость ТРУ с учетом НДС (H 14)
		//fractionDigits value="2", totalDigits value="17"
		float priceWithTax;

		//Стоимость ТРУ без учета НДС (H 7)
		//fractionDigits value="2", totalDigits value="17"
		float priceWithoutTax;

		//Номер продукта (товара, услуги) (H 1)
		//1-200
		int productNumber;

		//Кол-во (объем) (H 6)
		//fractionDigits value="6", totalDigits value="18"
		float quantity;

		//Размер оборота по реализации (H 11)
		//fractionDigits value="2", totalDigits value="17"
		float turnoverSize;
	}
}
