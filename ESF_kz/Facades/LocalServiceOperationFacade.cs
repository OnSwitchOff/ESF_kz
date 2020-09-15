using ESF_kz.LocalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESF_kz
{
	static class LocalServiceOperationFacade
	{
		static private LocalServiceClient serviceClient;

		static private LocalServiceClient getServiceClient()
		{
			if (serviceClient == null)
			{
				serviceClient = new LocalServiceClient();
			}

			return serviceClient;
		}

		static public bool GenerateInvoiceSignature()
		{
			SignatureRequest signatureRequest = new SignatureRequest();
			signatureRequest.version = ConfigManagerFacade.getESFVersion();
			signatureRequest.certificatePath = SessionDataManagerFacade.getSignCertificatePath();
			signatureRequest.certificatePin = SessionDataManagerFacade.getSignCertificatePin();
			signatureRequest.invoiceBodies = SessionDataManagerFacade.getInvoiceBodies();
			try
			{
				SignatureResponse signatureResponse = getServiceClient().generateSignature(signatureRequest);				
				return SessionDataManagerFacade.setInvoiceSignature(signatureResponse); ;
			}
			catch (Exception)
			{
				return false;
			}
			
		}
	}

	
}
