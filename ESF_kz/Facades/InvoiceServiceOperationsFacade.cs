using ESF_kz.InvoiceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ESF_kz
{
	static class InvoiceServiceOperationsFacade
	{
		static private InvoiceServiceClient serviceClient;

		static private InvoiceServiceClient getServiceClient()
		{
			if(serviceClient == null  || ConfigManagerFacade.isInvoiceServiceConfigChanged())
			{
				string EndpointAddressString = ConfigManagerFacade.getInvoiceService_EndpointAddress();
				EndpointAddress invoiceServiceEndpointAddress = new EndpointAddress(EndpointAddressString);

				BasicHttpsBinding basicHttpBinding = new BasicHttpsBinding();
				basicHttpBinding.MaxReceivedMessageSize = ConfigManagerFacade.getInvoiceService_MaxReceivedMessageSize();
				basicHttpBinding.MaxBufferSize = ConfigManagerFacade.getInvoiceService_MaxBufferSize();
				basicHttpBinding.MaxBufferPoolSize = ConfigManagerFacade.getInvoiceService_MaxBufferPoolSize();
				basicHttpBinding.AllowCookies = ConfigManagerFacade.getInvoiceService_AllowCookies();

				XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
				readerQuotas.MaxArrayLength = ConfigManagerFacade.getInvoiceService_readerQuotasMaxArrayLength();
				readerQuotas.MaxStringContentLength = ConfigManagerFacade.getInvoiceService_readerQuotasMaxStringContentLength();
				readerQuotas.MaxDepth = ConfigManagerFacade.getInvoiceService_readerQuotasMaxDepth();
				basicHttpBinding.ReaderQuotas = readerQuotas;

				serviceClient = new InvoiceServiceClient(basicHttpBinding, invoiceServiceEndpointAddress);
			}

			return serviceClient;
		}

		static public bool EnterpriseValidation()
		{
			EnterpriseValidationRequest enterpriseValidationRequest = new EnterpriseValidationRequest();
			enterpriseValidationRequest.sessionId = SessionDataManagerFacade.getSessionId();

			EnterpriseKey enterpriseKey = new EnterpriseKey();
			enterpriseKey.tin = ConfigManagerFacade.getSellerTin();
			enterpriseKey.certificateNum = ConfigManagerFacade.getCertificateNum();
			enterpriseKey.certificateSeries = ConfigManagerFacade.getCertificateSeries();
			EnterpriseKey[] enterpriseKeyList = { enterpriseKey };
			enterpriseValidationRequest.enterpriseKeyList = enterpriseKeyList;

			EnterpriseValidationResponse enterpriseValidationResponse;
			enterpriseValidationResponse = getServiceClient().enterpriseValidation(enterpriseValidationRequest);

			return true;
		}

	}
}
