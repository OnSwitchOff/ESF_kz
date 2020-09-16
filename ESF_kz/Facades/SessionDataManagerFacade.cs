using ESF_kz.LocalService;
using ESF_kz.UploadInvoiceService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		internal static T[] getInvoiceIdWithReasonsList<T>() where T : class, new()
		{
			if (typeof(T) == typeof(LocalService.InvoiceIdWithReason))
			{
				var invoiceIdWithReason = new LocalService.InvoiceIdWithReason();
				invoiceIdWithReason.id = getInvoiceId();
				invoiceIdWithReason.reason = "reason";

				object[] invoiceIdWithReasonsList = { invoiceIdWithReason };
				return invoiceIdWithReasonsList as T[];
			}
			else if (typeof(T) == typeof(InvoiceService.InvoiceIdWithReason))
			{
				var invoiceIdWithReason = new InvoiceService.InvoiceIdWithReason();
				invoiceIdWithReason.id = getInvoiceId();
				invoiceIdWithReason.reason = "reason";

				object[] invoiceIdWithReasonsList = { invoiceIdWithReason };
				return invoiceIdWithReasonsList as T[];
			}
			return null;			
		}

		internal static InvoiceService.InvoiceDirection getDirection()
		{
			return InvoiceService.InvoiceDirection.OUTBOUND;
		}



		internal static InvoiceService.InvoiceKey[] getinvoiceKeyList()
		{
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
			invoiceDate = String.Format("{0}.{1}.{2}",date.Year,date.Month,date.Day);
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
			string invoiceBodyPath = @"C:\Users\viktor.kassov\source\repos\ESF_kz\ESF_kz\bin\Debug\InvoiceBodyTestExample.txt";
			string invoiceBodyString = "";
			using (StreamReader sr = new StreamReader(invoiceBodyPath))
			{
				invoiceBodyString = sr.ReadToEnd();
			}
			return invoiceBodyString;
		}

		internal static string getX509SignCertificate()
		{
			return "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";
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
			SessionDataManagerFacade.sessionId = "";
		}

		internal static bool isEmptySessionId()
		{
			return SessionDataManagerFacade.sessionId == "";
		}

		internal static void setCurrentUserProfilesData()
		{
			//todo
		}

		internal static void setCurrentUserData()
		{
			//todo
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
