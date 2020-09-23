using ESF_kz.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	static class FormManagerFacade
	{
		static private ESF_form invoiceForm;

		static internal bool setInvoiceForm(ESF_form form)
		{
			try
			{
				invoiceForm = form;
				return true;
			}
			catch (Exception)
			{
				return false;
			}			
		}

		static internal ESF_form getInvoiceForm()
		{
			return invoiceForm;
		}

		internal static string getOperatorFullname()
		{
			throw new NotImplementedException();
		}

		internal static DateTime getRelatedInvoiceDate()
		{
			panelESFpartA panelA = invoiceForm.getPannel<panelESFpartA>();
			if (panelA.isCorrectedESF())
			{
				return panelA.getCorrectedESFDate();
			}
			else if (panelA.isAddedESF())
			{
				return panelA.getAddedESFDate();
			}
			return new DateTime(1990,9,24);
		}

		internal static string getRelatedInvoiceNum()
		{
			panelESFpartA panelA = invoiceForm.getPannel<panelESFpartA>();
			if (panelA.isCorrectedESF())
			{
				return panelA.getCorrectedESFNum();
			}
			else if (panelA.isAddedESF())
			{
				return panelA.getAddedESFNum();
			}
			return null;
		}

		internal static string getRelatedInvoiceRegistrationNum()
		{
			panelESFpartA panelA = invoiceForm.getPannel<panelESFpartA>();
			if (panelA.isCorrectedESF())
			{
				return panelA.getCorrectedESFRegistrationNum();
			}
			else if (panelA.isAddedESF())
			{
				return panelA.getAddedESFRegistrationNum();
			}
			return null;
		}

		internal static string getInvoiceAddInf()
		{
			return invoiceForm.getPannel<panelESFpartK>().getInvoiceAddInf();
		}

		internal static string getConsigneeAddress()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsigneeAddress();
		}

		internal static string getConsigneeCountryCode()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsigneeCountryCode();
		}

		internal static string getConsigneeName()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsigneeName();
		}

		internal static string getConsigneeTin()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsigneeTin();
		}

		internal static string getConsignorAddress()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsignorAddress();
		}

		internal static string getConsignorName()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsignorName();
		}

		internal static string getConsignorTin()
		{
			return invoiceForm.getPannel<panelESFpartD>().getConsignorTin();
		}

		internal static string getCustomerAgentAddress()
		{
			return invoiceForm.getPannel<panelESFpartJ>().getCustomerAgentAddress();
		}

		internal static DateTime getCustomerAgentDocDate()
		{
			return invoiceForm.getPannel<panelESFpartJ>().getCustomerAgentDocDate();
		}

		internal static string getCustomerAgentDocNum()
		{
			return invoiceForm.getPannel<panelESFpartJ>().getCustomerAgentDocNum();
		}

		internal static string getCustomerAgentName()
		{
			return invoiceForm.getPannel<panelESFpartJ>().getCustomerAgentName();
		}

		internal static string getCustomerAgentTin()
		{
			return invoiceForm.getPannel<panelESFpartJ>().getCustomerAgentTin();
		}

		internal static int getCustomerParticipantsCount()
		{
			return invoiceForm.getPannel<panelESFpartC>().getCustomerParticipantsCount();
		}

		internal static ParticipantV2 getCustomerParticipant(int i)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerParticipantTin(int number)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(number).getCustomerParticipantsTin();
		}

		internal static string getCustomerParticipantReorgTin(int number)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(number).getCustomerParticipantsReorgTin();
		}

		internal static int getShareByCustomerParticipantCount(int number)
		{
			return getCustomerParticipantsCount();
		}

		internal static string getCustomerProductShareAdditional(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductShareAdditional(productShareNumber);
		}

		internal static float getCustomerProductShareExciseAmount(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductShareExciseAmount(productShareNumber);
		}

		internal static float getCustomerProductShareNDSAmount(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductShareNDSAmount(productShareNumber);
		}

		internal static float getCustomerProductSharePriceWithoutTax(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductSharePriceWithoutTax(productShareNumber);
		}

		internal static float getCustomerProductSharePriceWithhTax(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductSharePriceWithTax(productShareNumber);
		}

		internal static int getProductShareProductNumber(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getProductShareProductNumber(productShareNumber);
		}

		internal static float getCustomerProductShareQuantity(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductShareQuantity(productShareNumber);
		}

		internal static float getCustomerProductShareTurnoverSize(int participantNumber, int productShareNumber)
		{
			return invoiceForm.getPannel<panelESFpartH>().getTab(participantNumber).getCustomerProductShareTurnoverSize(productShareNumber);
		}

		internal static int getCustomersCount()
		{
			return getCustomerParticipantsCount();
		}

		internal static string getCustomerBranchTin(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerTin();
		}

		internal static string getCustomerAddress(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerAddress();
		}

		internal static string getCustomerCountryCode(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerCountryCode();
		}

		internal static string getCustomerName(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerName();
		}

		internal static string getCustomerReorgTin(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerReorgTin();
		}

		internal static float getCustomerShareParticipation(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerShareParticipation();
		}

		internal static int getCustomerStatusesCount(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerStatusesCount();
		}

		internal static CustomerType getCustomerStatusById(int customerNumber, int statusId)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerStatusById(statusId);
		}

		internal static string getCustomerTin(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerTin();
		}

		internal static string getCustomerTrailer(int customerNumber)
		{
			return invoiceForm.getPannel<panelESFpartC>().getTab(customerNumber).getCustomerTrailer();
		}

		internal static DateTime getInvoiceDatePaper()
		{
			return invoiceForm.getPannel<panelESFpartA>().getInvoiceDatePaper();
		}

		internal static DateTime getInvoiceDeliveryDocDate()
		{
			return invoiceForm.getPannel<panelESFpartF>().getInvoiceDeliveryDocDate();
		}

		internal static string getInvoiceDeliveryDocNum()
		{
			return invoiceForm.getPannel<panelESFpartF>().getInvoiceDeliveryDocNum();
		}

		internal static DateTime getDeliveryTermContractDate()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermContractDate();
		}

		internal static string getDeliveryTermContractNum()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermContractNum();
		}

		internal static string getDeliveryTermConditiomCode()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermConditiomCode();
		}

		internal static string getDeliveryTermDestination()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermDestination();
		}

		internal static bool getDeliveryTermHasContract()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermHasContract();
		}

		internal static string getDeliveryTermTerm()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermTerm();
		}

		internal static string getDeliveryTermTransportTypeCode()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermTransportTypeCode();
		}

		internal static string getDeliveryTermWarrant()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermWarrant();
		}

		internal static DateTime getDeliveryTermWarrantDate()
		{
			return invoiceForm.getPannel<panelESFpartE>().getDeliveryTermWarrantDate();
		}

		internal static string getProductSetCurrentCode()
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductSetCurrentCode();
		}

		internal static float getProductSetCurrencyRate()
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductSetCurrencyRate();
		}

		internal static NdsRateType getProductSetNdsRateType()
		{
			throw new NotImplementedException();
		}

		internal static int getProductsCount()
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductsCount();
		}

		internal static string getProductAdditional(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductAdditional(productNum);
		}

		internal static string getProductCatalogTruId(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductCatalogTruId(productNum);
		}

		internal static string getProductDescription(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductDescription(productNum);
		}

		internal static float getProductExciseAmount(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductExciseAmount(productNum);
		}

		internal static float getProductExciseRate(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductExciseRate(productNum);
		}

		internal static string getProductKpvedCode(int productNum)
		{
			return "some kpnved code???";
			//return invoiceForm.getPannel<panelESFpartG>().getProductKpvedCode(productNum);
		}

		internal static float getProductNDSAmount(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductNDSAmount(productNum);
		}

		internal static int getProductNDSRAte(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductNDSRate(productNum);
		}

		internal static float getProductPriceWithoutTax(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductPriceWithoutTax(productNum);
		}

		internal static string getProductDeclaration(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductDeclaration(productNum);
		}

		internal static float getProductPriceWithTax(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductPriceWithTax(productNum);
		}

		internal static string getProductNumberInDexlaration(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductNumberInDexlaration(productNum);
		}

		internal static string getProductTnvedName(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductTnvedName(productNum);
		}

		internal static TruOriginCode getProductTruOriginCode(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductTruOriginCode(productNum);
		}

		internal static float getProductTurnoverSize(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductTurnoverSize(productNum);
		}

		internal static string getProductUnitCode(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductUnitCode(productNum);
		}

		internal static string getProductUnitNominclature(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductUnitNominclature(productNum);
		}

		internal static float getProductUnitPrice(int productNum)
		{
			return invoiceForm.getPannel<panelESFpartG>().getProductUnitPrice(productNum);
		}

		internal static float getProductSetTotalExciseAmount()
		{
			throw new NotImplementedException();
		}

		internal static float getProductSetTotalNDSAmount()
		{
			throw new NotImplementedException();
		}

		internal static float getProductSetTotalPriceWithoutTax()
		{
			throw new NotImplementedException();
		}

		internal static float getProductSetTotalPriceWithTax()
		{
			throw new NotImplementedException();
		}

		internal static float getProductSetTotalTurnoverSize()
		{
			throw new NotImplementedException();
		}

		internal static string getPublicOfficeBik()
		{
			throw new NotImplementedException();
		}

		internal static string getPublicOfficeIik()
		{
			throw new NotImplementedException();
		}

		internal static string getPublicOfficePayPurpose()
		{
			throw new NotImplementedException();
		}

		internal static string getPublicOfficeProductCOde()
		{
			throw new NotImplementedException();
		}

		internal static PaperReasonType getReasonPaper()
		{
			throw new NotImplementedException();
		}

		internal static string getSellerCertificateSeries()
		{
			throw new NotImplementedException();
		}

		internal static string getInvoiceSellerAgentAddress()
		{
			throw new NotImplementedException();
		}

		internal static DateTime getInvoiceSellerAgentDocDate()
		{
			throw new NotImplementedException();
		}

		internal static string getInvoiceSellerAgentDocNum()
		{
			throw new NotImplementedException();
		}

		internal static string getInvoiceSellerAgentName()
		{
			throw new NotImplementedException();
		}

		internal static string getInvoiceSellerAgentTin()
		{
			throw new NotImplementedException();
		}

		internal static int getSellerParticipantsCount()
		{
			throw new NotImplementedException();
		}

		internal static string getSellerParticipantTin(int number)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerParticipantReorgTin(int number)
		{
			throw new NotImplementedException();
		}

		internal static int getShareBySellerParticipantCount(int number)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerProductShareAdditional(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static float getSellerProductShareExciseAmount(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static float getSellerProductShareNDSAmount(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static float getSellerProductSharePriceWithoutTax(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static float getSellerProductSharePriceWithhTax(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static int getSellerProductShareQuantity(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static float getSellerProductShareTurnoverSize(int sellerNumber, int productSharNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerTrailer(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerTin(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static int getSellersCount()
		{
			throw new NotImplementedException();
		}

		internal static string getSellerAddress(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerReorgTin(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static int getSellerStatusesCount(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static SellerType getSellerStatusById(int sellerNum, int statusId)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerKbe(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static bool getSellerIsBranchNonResident(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerName(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerIik(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerCertificateNum(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerCertificateSeries(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerBranchTin(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerBank(int sellerNum)
		{
			throw new NotImplementedException();
		}

		internal static string getSellerBik(int sellerNum)
		{
			throw new NotImplementedException();
		}
	}
}
