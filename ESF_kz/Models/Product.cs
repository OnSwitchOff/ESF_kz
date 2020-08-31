using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	//Товар (работа, услуга)
	class Product : AbstractProduct
	{
		//Дополнительные данные (G 18)
		string additional;

		//Идентификатор товара, работ, услуг (G 17)
		string catalogTruId;

		//Наименование ТРУ (G 3)
		string description;

		//Акциз-Сумма (G 10)
		//fractionDigits value="2", totalDigits value="17"
		float exciseAmount;

		//Акциз-Ставка (G 9)
		//fractionDigits value="2",minInclusive value="0",totalDigits value="14"
		float exciseRate;

		//Классификатор продукции по видам экономической деятельности
		string kpvedCode;

		//НДС-Сумма(G 13)
		//fractionDigits value="2", totalDigits value="17"
		float ndsAmount;

		//НДС-Ставка (G 12)
		int ndsRate;

		//Стоимость ТРУ с учетом НДС (G 14)
		//fractionDigits value = "2", totalDigits value="17
		float priceWithTax;

		//Стоимость ТРУ без косвенных налогов (G 8)
		//fractionDigits value = "2", totalDigits value="17
		float priceWithoutTax;

		//Декларации на товары, заявления в рамках ТС, СТ-1 или СТ-KZ(G 15)
		string productDeclaration;

		//Номер товарной позиции из заявления в рамках ТС или Декларации на товары (G 16)
		string productNumberInDeclaration;

		//Кол-во (объем) (G 6)
		//fractionDigits value="6", totalDigits value="18"
		float quantity;

		//Наименование товаров по классификатору ТН ВЭД ЕАЭС(G 3/1)
		string tnvedName;

		//Признак происхождения ТРУ (G 2)
		TruOriginCode truOriginCode;

		//Размер оборота по реализации (облагаемый/необлагаемый оборот) (G 11)
		//fractionDigits value = "2", totalDigits value="17
		float turnoverSize;

		//Код товара(ТНВД ЕАЭС) (G 4)
		//pattern value="[0-9]{1,10}
		string unitCode;

		//Ед.изм(G 5)
		string unitNomenclature;

		//Цена (тариф) за единицу ТРУ без косвенных налогов (G 7)
		//fractionDigits value="6", totalDigits value="18"
		float unitPrice;
	}
}
