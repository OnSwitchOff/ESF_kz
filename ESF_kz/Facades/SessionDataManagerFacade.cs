using ESF_kz.LocalService;
using ESF_kz.SessionService;
using ESF_kz.UploadInvoiceService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ESF_kz
{
	static class SessionDataManagerFacade
	{
		private static string sessionId;
		private static string invoiceSignature;
		private static string invoiceSignatureId;
		private static string invoiceSignatureIdWithReason;
		private static long invoiceId;
		private static string invoiceDate;
		private static string invoiceNum;
		private static User currentUser;
		private static profileInfo[] profileInfoList;

		internal static string getSessionId()
		{
			return SessionDataManagerFacade.sessionId;
		}

		internal static string getUserName()
		{
			return "760816300415";
		}

		internal static string getPassword()
		{
			return "Micr0!nvest";
		}

		internal static string getX509AuthCertificate()
		{
			return "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";
		}

		internal static bool setInvoiceSignatureId(ListSignatureResponse listSignatureResponse)
		{
			invoiceSignatureId = listSignatureResponse.signature;
			return true;
		}

		internal static long[] getInvoiceIdList()
		{
			long[] idList = { getInvoiceId() };
			return idList;
		}

		private static long getInvoiceId()
		{
			return invoiceId;
		}

		internal static bool setInvoiceSignatureIdWithReason(ListSignatureResponse listSignatureResponse)
		{
			invoiceSignatureIdWithReason = listSignatureResponse.signature;
			return true;
		}

		internal static LocalService.InvoiceIdWithReason[] getInvoiceIdWithReasonsList_LocalService()
		{
			LocalService.InvoiceIdWithReason invoiceIdWithReason = new LocalService.InvoiceIdWithReason();
			invoiceIdWithReason.id = getInvoiceId();
			invoiceIdWithReason.reason = "reason";
			LocalService.InvoiceIdWithReason[] invoiceIdWithReasonsList = { invoiceIdWithReason };
			return invoiceIdWithReasonsList;					
		}

		internal static InvoiceService.InvoiceIdWithReason[] getInvoiceIdWithReasonsList_InvoiceService()
		{
			InvoiceService.InvoiceIdWithReason invoiceIdWithReason = new InvoiceService.InvoiceIdWithReason();
			invoiceIdWithReason.id = getInvoiceId();
			invoiceIdWithReason.reason = "reason";
			InvoiceService.InvoiceIdWithReason[] invoiceIdWithReasonsList = { invoiceIdWithReason };
			return invoiceIdWithReasonsList;
		}

		internal static InvoiceService.InvoiceDirection getDirection()
		{
			return InvoiceService.InvoiceDirection.OUTBOUND;
		}



		internal static InvoiceService.InvoiceKey[] getinvoiceKeyList()
		{
			setInvoiceDate(DateTime.Now);
			setInvoiceNum("7348253030453186403");
			InvoiceService.InvoiceKey invoiceKey = new InvoiceService.InvoiceKey();
			invoiceKey.date = getInvoiceDate();
			invoiceKey.num = getInvoiceNum();
			InvoiceService.InvoiceKey[] keyList = { invoiceKey };
			return keyList;
		}

		internal static bool setInvoiceNum(string num)
		{
			invoiceNum = num;
			return true;
		}

		internal static DateTime getlastEventDate()
		{
			return new DateTime(2018, 01, 01);
		}

		internal static long getlastInvoiceId()
		{
			return 0;
		}

		internal static bool setInvoiceDate(DateTime date)
		{
			invoiceDate = String.Format("{0}.{1}.{2}",date.Day,date.Month,date.Year);
			return true;
		}

		internal static bool getfullInfoOnStatusChange()
		{
			return false;
		}

		internal static int getlimit()
		{
			return 10;
		}

		private static string getInvoiceNum()
		{
			return invoiceNum;
		}

		private static string getInvoiceDate()
		{
			return invoiceDate;
		}

		internal static invoiceUploadInfo[] getInvoiceUploadInfoList()
		{
			invoiceUploadInfo InvoiceUploadInfo = new invoiceUploadInfo();
			InvoiceUploadInfo.invoiceBody = getInvoiceBodyString();
			InvoiceUploadInfo.version = ConfigManagerFacade.getESFVersion();
			InvoiceUploadInfo.signature = getInvoiceSignature();
			InvoiceUploadInfo.signatureType = getSignatureType();
			invoiceUploadInfo[] invoiceUploadInfoList = { InvoiceUploadInfo };
			return invoiceUploadInfoList;
		}

		private static SignatureType getSignatureType()
		{
			return SignatureType.COMPANY;
		}

		private static string getInvoiceSignature()
		{
			return invoiceSignature;
		}

		private static string getInvoiceBodyString()
		{
			/*string invoiceBodyPath = @"C:\Users\viktor.kassov\source\repos\ESF_kz\ESF_kz\bin\Debug\InvoiceBodyTestExample.xml";
			string invoiceBodyString = "";
			using (StreamReader sr = new StreamReader(invoiceBodyPath))
			{
				invoiceBodyString = sr.ReadToEnd();
			}*/

			invoiceContainerV2 inContainerV2 = new invoiceContainerV2();	
			

			InvoiceV2 invoiceV2 = new InvoiceV2();
			invoiceV2.invoiceType = InvoiceType.ORDINARY_INVOICE;
			invoiceV2.date = DateTime.Now;
			invoiceV2.num = "invoice num";
			invoiceV2.operatorFullname = "Kassov Viktor";
				RelatedInvoice relatedInvoice = new RelatedInvoice();
				relatedInvoice.date = DateTime.Now;
				relatedInvoice.num = "relatedInv num";
				relatedInvoice.registrationNumber = "registrat NUmber";
			invoiceV2.relatedInvoice = relatedInvoice;
			invoiceV2.turnoverDate = DateTime.Now;
			invoiceV2.addInf = "addInf";
				ConsigneeV2 consigneeV2 = new ConsigneeV2();
				consigneeV2.address = "Consegnee Adress";
				consigneeV2.countryCode = "KZ";
				consigneeV2.name = "Consegnee Name";
				consigneeV2.tin = "COnsegnee Tin";
			invoiceV2.consignee = consigneeV2;
				Consignor consignor = new Consignor();
				consignor.address = "Consegnor Address";
				consignor.name = "Consignor Name";
				consignor.tin = "Consignor Tin";
			invoiceV2.consignor = consignor;
			invoiceV2.customerAgentAddress = "customerAgentAddress";
			invoiceV2.customerAgentDocDate = DateTime.Now;
			invoiceV2.customerAgentDocNum = "customerAgentDocNum";
			invoiceV2.customerAgentName = "customerAgentName";
			invoiceV2.customerAgentTin = "customerAgentTin";
				ParticipantV2 customerParticipant1 = new ParticipantV2();
				customerParticipant1.tin = "Participant #1 tin";
				customerParticipant1.reorganizedTin = "Participant #1 reorganized Tin";
					ProductShare productShare1 = new ProductShare();
					productShare1.additional = "additional";
					productShare1.exciseAmount = 100;
					productShare1.ndsAmount = 20;
					productShare1.priceWithoutTax = 120;
					productShare1.priceWithTax = 120;
					productShare1.productNumber = 1;
					productShare1.quantity = 5;
					productShare1.turnoverSize = 600;
					List<ProductShare> productShares = new List<ProductShare>();
					productShares.Add(productShare1);
				customerParticipant1.productShares = productShares;
				List<ParticipantV2> customerParticipantsList = new List<ParticipantV2>();
				customerParticipantsList.Add(customerParticipant1);
			invoiceV2.customerParticipants = customerParticipantsList;
				CustomerV2 customerV2 = new CustomerV2();
				customerV2.address = "CUstomer Address";
				customerV2.branchTin = "Customer branchTiN";
				customerV2.countryCode = "KZ";
				customerV2.name = "customerName";
				customerV2.reorganizedTin = "customerreorgtin";
				customerV2.shareParticipation = 0.22f;
					CustomerType customerType = CustomerType.BROKER;
					CustomerType customerType1 = CustomerType.JOINT_ACTIVITY_PARTICIPANT;
					List<CustomerType> statuses = new List<CustomerType>();			
					statuses.Add(customerType);
					statuses.Add(customerType1);
				customerV2.statuses = statuses;
				customerV2.tin = "customerTin";
				customerV2.trailer = "custtrailer";				
				List<CustomerV2> customerV2s = new List<CustomerV2>();
				customerV2s.Add(customerV2);
			invoiceV2.customers = customerV2s;
			invoiceV2.datePaper = DateTime.Now;
			invoiceV2.deliveryDocDate = DateTime.Now;
			invoiceV2.deliveryDocNum = "DeliveryDocNum";
				DeliveryTermV2 deliveryTermV2 = new DeliveryTermV2();
				deliveryTermV2.contractDate = DateTime.Now;
				deliveryTermV2.contractNum = "ContractNum";
				deliveryTermV2.deliveryConditionCode = "deliveryConditionCode";
				deliveryTermV2.destination = "destination";
				deliveryTermV2.hasContract = true;
				deliveryTermV2.term = "term";
				deliveryTermV2.transportTypeCode = "transportTypeCode";
				deliveryTermV2.warrant = "wRRnt";
				deliveryTermV2.warrantDate = DateTime.Now;
			invoiceV2.deliveryTerm = deliveryTermV2;

				ProductSetV2 productSetV2 = new ProductSetV2();
				productSetV2.currencyCode = "currentCode";
				productSetV2.currencyRate = 0.25f;
				productSetV2.ndsRateType = NdsRateType.WITHOUT_NDS_NOT_KZ;
					ProductV2 product = new ProductV2();
					product.additional = "additional";
					product.catalogTruId = "catalogTruId";
					product.description = "description";
					product.exciseAmount = 10;
					product.exciseRate = 0.10f;
					product.kpvedCode = "kpvedcode";
					product.ndsAmount = 10.2f;
					product.ndsRate = 1;
					product.priceWithoutTax = 10;
					product.priceWithTax = 20.3f;
					product.productDeclaration = "declration";
					product.productNumberInDeclaration = "numInDec";
					product.tnvedName = "tnvedName";
					product.truOriginCode = TruOriginCode.three;
					product.turnoverSize = 40.36f;
					product.unitCode = "unitcode";
					product.unitNomenclature = "unitNomen";
					product.unitPrice = 20.3f;
					List<ProductV2> productV2s = new List<ProductV2>();
					productV2s.Add(product);
				productSetV2.products = productV2s;
				productSetV2.totalExciseAmount = 100;
				productSetV2.totalNdsAmount = 100;
				productSetV2.totalPriceWithoutTax = 100;
				productSetV2.totalPriceWithTax = 200;
				productSetV2.totalTurnoverSize = 200;
			invoiceV2.productSet = productSetV2;
				PublicOffice publicOffice = new PublicOffice();
				publicOffice.bik = "bik";
				publicOffice.iik = "iik";
				publicOffice.payPurpose = "paypurp";
				publicOffice.productCode = "productCOde";
			invoiceV2.publicOffice = publicOffice;
			invoiceV2.reasonPaper = PaperReasonType.MISSING_REQUIREMENT;
			invoiceV2.sellerAgentAddress = "sellerAgentAddress";
			invoiceV2.sellerAgentDocDate = DateTime.Now;
			invoiceV2.sellerAgentDocNum = "sellerAgentDocNum";
			invoiceV2.sellerAgentName = "sellerAgentName";
			invoiceV2.sellerAgentTin = "sellerAgentTin";
				
			invoiceV2.sellerParticipants = customerParticipantsList;
				SellerV2 sellerV2 = new SellerV2();
				sellerV2.address = "sellerAddress";
				sellerV2.bank = "sellerBank";
				sellerV2.bik = "sellerBik";
				sellerV2.branchTin = "branchTin";
				sellerV2.certificateNum = "sellerCertNum";
				sellerV2.certificateSeries = "sellerCertSeries";
				sellerV2.iik = "iik";
				sellerV2.isBranchNonResident = true;
				sellerV2.kbe = "kbe";
				sellerV2.name = "sellerName";
				sellerV2.reorganizedTin = "reorgTin";
				sellerV2.shareParticipation = 0.25f;
					SellerType sellerType = SellerType.JOINT_ACTIVITY_PARTICIPANT;
					List<SellerType> sellerTypes = new List<SellerType>();
					sellerTypes.Add(sellerType);
				sellerV2.statuses = sellerTypes;
				sellerV2.tin = "tin";
				sellerV2.trailer = "trailer";
				List<SellerV2> sellerV2s = new List<SellerV2>();
				sellerV2s.Add(sellerV2);
			invoiceV2.sellers = sellerV2s;

			InvoiceV2[] invoiceV2s = { invoiceV2 };
			inContainerV2.invoiceSet = invoiceV2s;

			string str = "";
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(invoiceContainerV2));

			using (FileStream fs = new FileStream("testW.xml", FileMode.OpenOrCreate))
			using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
			{				
				xmlSerializer.Serialize(sw, inContainerV2);
			}

			using (FileStream fs = new FileStream("testW.xml", FileMode.OpenOrCreate))
			using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
			{	
				str = sr.ReadToEnd();
			}

			return str;
		}

		internal static string getX509SignCertificate()
		{
			return "MIIGfTCCBGWgAwIBAgIUE6Hd9dsBffeRpzivUvIsDNqVnnswDQYJKoZIhvcNAQELBQAwUjELMAkGA1UEBhMCS1oxQzBBBgNVBAMMOtKw0JvQotCi0KvSmiDQmtCj05jQm9CQ0J3QlNCr0KDQo9Co0Ksg0J7QoNCi0JDQm9Cr0pogKFJTQSkwHhcNMjAwNjE3MDgzMjM4WhcNMjEwNjE3MDgzMjM4WjCBvzEkMCIGA1UEAwwb0J/QmNCd0KfQo9CaINCS0JjQotCQ0JvQmNCZMRUwEwYDVQQEDAzQn9CY0J3Qp9Cj0JoxGDAWBgNVBAUTD0lJTjc2MDgxNjMwMDQxNTELMAkGA1UEBhMCS1oxHDAaBgNVBAcME9Cd0KPQoC3QodCj0JvQotCQ0J0xHDAaBgNVBAgME9Cd0KPQoC3QodCj0JvQotCQ0J0xHTAbBgNVBCoMFNCS0JDQodCY0JvQrNCV0JLQmNCnMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAquWvE35HanVNEsngkRQhnzS8z3ge+L6pCrpeta1ThvUeNS2ErKeSMNPWFGEW4W5ObJFcMstRvLfu2BGLSSompxxQv/YnHZnpw4ppwrWkbnhClH5BjLafs2k0wU151dn5Y/eZyHEWoiyXQjcdhzpCp0IjlZ1oz7X0JX2q48k5onRDM/jszvyE9j/gAk6itcfarlg4oHeA78QR6J6XoGZ2tle/ru+EynQW22Kq5COpAz6mnajUFprRB0eWvCrhZLLVm4lAQQhpNTfK2HrTNrld8CeWjrMCE93YKauqBT7EowbxQlCm0TJfyh5TZ1iztcvU3vpXPrh167IKQnEcpqn4TQIDAQABo4IB2zCCAdcwDgYDVR0PAQH/BAQDAgbAMB0GA1UdJQQWMBQGCCsGAQUFBwMEBggqgw4DAwQBATAPBgNVHSMECDAGgARbanQRMB0GA1UdDgQWBBSvjm+L4COozANRmFIqcMpyA6cFmjBeBgNVHSAEVzBVMFMGByqDDgMDAgMwSDAhBggrBgEFBQcCARYVaHR0cDovL3BraS5nb3Yua3ovY3BzMCMGCCsGAQUFBwICMBcMFWh0dHA6Ly9wa2kuZ292Lmt6L2NwczBWBgNVHR8ETzBNMEugSaBHhiFodHRwOi8vY3JsLnBraS5nb3Yua3ovbmNhX3JzYS5jcmyGImh0dHA6Ly9jcmwxLnBraS5nb3Yua3ovbmNhX3JzYS5jcmwwWgYDVR0uBFMwUTBPoE2gS4YjaHR0cDovL2NybC5wa2kuZ292Lmt6L25jYV9kX3JzYS5jcmyGJGh0dHA6Ly9jcmwxLnBraS5nb3Yua3ovbmNhX2RfcnNhLmNybDBiBggrBgEFBQcBAQRWMFQwLgYIKwYBBQUHMAKGImh0dHA6Ly9wa2kuZ292Lmt6L2NlcnQvbmNhX3JzYS5jZXIwIgYIKwYBBQUHMAGGFmh0dHA6Ly9vY3NwLnBraS5nb3Yua3owDQYJKoZIhvcNAQELBQADggIBAIBBjwdQlHOb4r09Jl/KrVBWV6r+/B6mkRIjn7jdoz1zRoFCDqi/W6XCQ8+PORNSBlCUS+9YitDUlL3lqFYeeOVMPUHCVWsEArgrgwc+HJ4GI+ywp/SurvXn6Wqsb4bHsGT1UXmDOk1y8SMC5+kqO/IHMOrsOQir5DpMBUB0xi97iWSoQDwgv9wnkQkwBbONWu/SkfsnwXjyiz9R4HEbzj8dzpXjbQlArqpK4AF20eqXSRp6rVb4t5SoQXCz7zfSOlBPjt++IbQwqXdEzTOq0f04+s8y/3ehrcvHip9GXabuoahX2/j+8LYehUSa1u9dGwalaEO0cUMK6LJsxJGKhlE/wiFw44IIj5WyqM2fKY3Rj0pQqOUA3P1yN21xS/Wvvi7JnKILkaxb+p40t5Z9dyPX8LsSAIjMa0AntJ2C253nqHgZx+ng3X9ZlOWfDsIZo4bYJaxITHT/51NZVE2pjPKrrN5yQzWjOF0xa95WZHg8y9ho6FejPyzXmS7GStcJ5VFkcowrvNR+OpIHIGJc3VVeb3jEIdJUGOu3DdHZ7qXMtPUC/R4aofTp9wxjLjgYaE87pOB74gw2Iao0C2T122VVSNMsCpY3qx20lnwUgx+5WBbMb74K5z0683ycSANsWAq+QfsPhYl6H3Vl14NXniwl5BZmqYFYP8C6QJtt4sI/";
		}

		internal static InvoiceService.QueryInvoiceCriteria getQueryInvoiceCriteria()
		{
			InvoiceService.QueryInvoiceCriteria queryInvoiceCriteria = new InvoiceService.QueryInvoiceCriteria();
			queryInvoiceCriteria.direction = getDirection();
			queryInvoiceCriteria.dateFrom = getDateFrom();
			queryInvoiceCriteria.dateTo = getDateTo();
			queryInvoiceCriteria.asc = getAsc();
			return queryInvoiceCriteria;
		}

		private static bool getAsc()
		{
			return true;
		}

		private static DateTime getDateTo()
		{
			return DateTime.Now;
		}

		private static DateTime getDateFrom()
		{
			return new DateTime(2020, 9, 1);
		}

		internal static bool setInvoiceId(SyncInvoiceResponse syncInvoiceResponse)
		{
			invoiceId = syncInvoiceResponse.acceptedSet[0].id;
			return true;
		}

		internal static bool setInvoiceSignature(SignatureResponse signatureResponse)
		{
			invoiceSignature = signatureResponse.invoiceHashList[0].signature;
			return true;
		}
		internal static string getInvoiceSignatureId()
		{
			return invoiceSignatureId;
		}
		internal static string getInvoiceSignatureIdWithReason()
		{
			return invoiceSignatureIdWithReason;
		}

		internal static string[] getInvoiceBodies()
		{
			string[] invoiceBodies = { getInvoiceBodyString() };
			return invoiceBodies;
		}

		internal static string getSignCertificatePin()
		{
			return "Aa123456";
		}

		internal static string getSignCertificatePath()
		{
			return @"C:\Users\viktor.kassov\source\repos\ESF_kz\ESF_kz\bin\Debug\Сертификат\ИП Пинчук ВВ до 17.06.21\ИП Пинчук ВВ до 17.06.21\RSA256_af8e6f8be023a8cc035198522a70ca7203a7059a.p12";
		}

		internal static void setSessionId(string id)
		{
			SessionDataManagerFacade.sessionId = id;
		}

		private static void clearSessionId()
		{
			SessionDataManagerFacade.sessionId = null;
		}

		internal static bool isEmptySessionId()
		{
			return SessionDataManagerFacade.sessionId == null;
		}

		internal static void setCurrentUserProfilesData(profileInfo[] list)
		{
			profileInfoList = list;
		}

		internal static void setCurrentUserData(User user)
		{
			currentUser = user;
		}

		internal static profileInfo[] getCurrentUserProfilesData()
		{
			return profileInfoList;
		}

		internal static User getCurrentUserData()
		{
			return currentUser;
		}

		private static void clearCurrentUserProfilesData()
		{
			//todo
		}

		private static void clearCurrentUserData()
		{
			//todo
		}

		internal static void clearSessionData()
		{
			clearCurrentUserData();
			clearCurrentUserProfilesData();
			clearSessionId();
		}
	}
}
