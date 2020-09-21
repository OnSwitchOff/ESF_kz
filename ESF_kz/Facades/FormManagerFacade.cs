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
			throw new NotImplementedException();
		}

		internal static DateTime getCustomerAgentDocDate()
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerAgentDocNum()
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerAgentName()
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerAgentTin()
		{
			throw new NotImplementedException();
		}

		internal static int getCustomerParticipantsCount()
		{
			throw new NotImplementedException();
		}

		internal static ParticipantV2 getCustomerParticipant(int i)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerParticipantTin(int number)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerParticipantReorgTin(int number)
		{
			throw new NotImplementedException();
		}

		internal static int getShareByCustomerParticipantCount(int number)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerProductShareAdditional(int participantNumber1, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerProductShareExciseAmount(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerProductShareNDSAmount(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerProductSharePriceWithoutTax(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerProductSharePriceWithhTax(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static int getProductShareProductNumber(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerProductShareQuantity(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerProductShareTurnoverSize(int participantNumber, int productShareNumber)
		{
			throw new NotImplementedException();
		}

		internal static int getCustomersCount()
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerBranchTin(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerAddress(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerCountryCode(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerName(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerReorgTin(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static float getCustomerShareParticipation(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static int getCustomerStatusesCount(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static CustomerType getCustomerStatusById(int customerNumber, int statusId)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerTin(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static string getCustomerTrailer(int customerNumber)
		{
			throw new NotImplementedException();
		}

		internal static DateTime getInvoiceDatePaper()
		{
			throw new NotImplementedException();
		}

		internal static DateTime getInvoiceDeliveryDocDate()
		{
			throw new NotImplementedException();
		}

		internal static string getInvoiceDeliveryDocNum()
		{
			throw new NotImplementedException();
		}

		internal static DateTime getDeliveryTermContractDate()
		{
			throw new NotImplementedException();
		}

		internal static string getDeliveryTermContractNum()
		{
			throw new NotImplementedException();
		}

		internal static string getDeliveryTermConditiomCode()
		{
			throw new NotImplementedException();
		}

		internal static string getDeliveryTermDestination()
		{
			throw new NotImplementedException();
		}

		internal static bool getDeliveryTermHasContract()
		{
			throw new NotImplementedException();
		}

		internal static string getDeliveryTermTerm()
		{
			throw new NotImplementedException();
		}

		internal static string getDeliveryTermTransportTypeCode()
		{
			throw new NotImplementedException();
		}

		internal static string getDeliveryTermWarrant()
		{
			throw new NotImplementedException();
		}

		internal static DateTime getDeliveryTermWarrantDate()
		{
			throw new NotImplementedException();
		}

		internal static string getProductSetCurrentCode()
		{
			throw new NotImplementedException();
		}

		internal static float getProductSetCurrencyRate()
		{
			throw new NotImplementedException();
		}

		internal static NdsRateType getProductSetNdsRateType()
		{
			throw new NotImplementedException();
		}

		internal static int getProductsCount()
		{
			throw new NotImplementedException();
		}

		internal static string getProductAdditional()
		{
			throw new NotImplementedException();
		}

		internal static string getProductCatalogTruId()
		{
			throw new NotImplementedException();
		}

		internal static string getProductDescription()
		{
			throw new NotImplementedException();
		}

		internal static float getProductExciseAmount()
		{
			throw new NotImplementedException();
		}

		internal static float getProductExciseRate()
		{
			throw new NotImplementedException();
		}

		internal static string getProductKpvedCode()
		{
			throw new NotImplementedException();
		}

		internal static float getProductNDSAmount()
		{
			throw new NotImplementedException();
		}

		internal static int getProductNDSRAte()
		{
			throw new NotImplementedException();
		}

		internal static float getProductPriceWithoutTax()
		{
			throw new NotImplementedException();
		}

		internal static string getProductDeclaration()
		{
			throw new NotImplementedException();
		}

		internal static float getProductPriceWithTax()
		{
			throw new NotImplementedException();
		}

		internal static string getProductNumberInDexlaration()
		{
			throw new NotImplementedException();
		}

		internal static string getProductTnvedName()
		{
			throw new NotImplementedException();
		}

		internal static TruOriginCode getProductTruOriginCode()
		{
			throw new NotImplementedException();
		}

		internal static float getProductTurnoverSize()
		{
			throw new NotImplementedException();
		}

		internal static string getProductUnitCode()
		{
			throw new NotImplementedException();
		}

		internal static string getProductUnitNominclature()
		{
			throw new NotImplementedException();
		}

		internal static float getProductUnitPrice()
		{
			throw new NotImplementedException();
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
