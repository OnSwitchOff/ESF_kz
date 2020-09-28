﻿using ESF_kz.InvoiceService;
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
		private static DateTime invoiceDate;
		private static string invoiceNum;
		private static InvoiceType invoiceType;
		private static User currentUser;
		private static profileInfo[] profileInfoList;

		internal static bool setInvoiceType(InvoiceType type)
		{
			invoiceType = type;
			return true;
		}

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

		internal static invoiceContainerV2 ParseInvoiceXML(XmlDocument xDoc)
		{
			string[] tmp = new string[] { };
			int day, month, year;

			XmlElement xRoot = xDoc.DocumentElement;//invoiceContainer
			invoiceContainerV2 invoiceContainer = new invoiceContainerV2();
			invoiceContainer.invoiceSet = new List<InvoiceV2>();
			XmlNode xInvoiceSet = xRoot.FirstChild;//invoiceSet

			foreach(XmlNode invoice in xInvoiceSet)
			{
				if(invoice.Name == "invoice")
				{
					InvoiceV2 invoiceV2 = new InvoiceV2();
					foreach (XmlNode item in invoice)
					{
						if(item.InnerText != "")
						{
							switch (item.Name)
							{
								case "date":
									tmp = item.InnerText.Split('.');
									day = int.Parse(tmp[0]);
									month = int.Parse(tmp[1]);
									year = int.Parse(tmp[2]);
									invoiceV2.date = new DateTime(year, month, day);
									break;
								case "invoiceType":
									if (item.InnerText == InvoiceType.ORDINARY_INVOICE.ToString())
										invoiceV2.invoiceType = InvoiceType.ORDINARY_INVOICE;
									else if (item.InnerText == InvoiceType.ADDITIONAL_INVOICE.ToString())
										invoiceV2.invoiceType = InvoiceType.ADDITIONAL_INVOICE;
									else if (item.InnerText == InvoiceType.FIXED_INVOICE.ToString())
										invoiceV2.invoiceType = InvoiceType.FIXED_INVOICE;
									break;
								case "num":
									invoiceV2.num = item.InnerText;
									break;
								case "operatorFullname":
									invoiceV2.operatorFullname = item.InnerText;
									break;
								case "relatedInvoice":
									invoiceV2.relatedInvoice = new RelatedInvoice();
									foreach (XmlNode subItem in item)
									{
										if (subItem.InnerText != "")
										{
											switch (subItem.Name)
											{
												case "date":
													tmp = subItem.InnerText.Split('.');
													day = int.Parse(tmp[0]);
													month = int.Parse(tmp[1]);
													year = int.Parse(tmp[2]);
													invoiceV2.relatedInvoice.date = new DateTime(year, month, day);
													break;
												case "num":
													invoiceV2.relatedInvoice.num = subItem.InnerText;
													break;
												case "registrationNumber":
													invoiceV2.relatedInvoice.registrationNumber = subItem.InnerText;
													break;
												default:
													break;
											}
										}										
									}
									break;
								case "turnoverDate":
									tmp = item.InnerText.Split('.');
									day = int.Parse(tmp[0]);
									month = int.Parse(tmp[1]);
									year = int.Parse(tmp[2]);
									invoiceV2.turnoverDate= new DateTime(year, month, day);
									break;
								case "addInf":
									invoiceV2.addInf = item.InnerText;
									break;
								case "consignee":
									invoiceV2.consignee = new ConsigneeV2();
									foreach (XmlNode subItem in item)
									{
										if (subItem.InnerText != "")
										{
											switch (subItem.Name)
											{
												case "address":
													invoiceV2.consignee.address = subItem.InnerText;
													break;
												case "countryCode":
													invoiceV2.consignee.countryCode = subItem.InnerText;
													break;
												case "name":
													invoiceV2.consignee.name = subItem.InnerText;
													break;
												case "tin":
													invoiceV2.consignee.tin = subItem.InnerText;
													break;
												default:
													break;
											}
										}
									}
									break;
								case "consignor":
									invoiceV2.consignor = new Consignor();
									foreach (XmlNode subItem in item)
									{
										if (subItem.InnerText != "")
										{
											switch (subItem.Name)
											{
												case "address":
													invoiceV2.consignor.address = subItem.InnerText;
													break;
												case "name":
													invoiceV2.consignor.name = subItem.InnerText;
													break;
												case "tin":
													invoiceV2.consignor.tin = subItem.InnerText;
													break;
												default:
													break;
											}
										}
									}
									break;
								case "customerAgentAddress":
									invoiceV2.customerAgentAddress = item.InnerText;
									break;
								case "customerAgentDocDate":
									tmp = item.InnerText.Split('.');
									day = int.Parse(tmp[0]);
									month = int.Parse(tmp[1]);
									year = int.Parse(tmp[2]);
									invoiceV2.customerAgentDocDate = new DateTime(year,month,day);
									break;
								case "customerAgentName":
									invoiceV2.customerAgentName = item.InnerText;
									break;
								case "customerAgentTin":
									invoiceV2.customerAgentTin = item.InnerText;
									break;
								case "customerParticipants":
									invoiceV2.customerParticipants = new List<ParticipantV2>();
									foreach (XmlNode participant in item)
									{
										ParticipantV2 customerParticipant = new ParticipantV2();
										foreach(XmlNode node in participant)
										{
											switch (node.Name)
											{
												case "productShares":
													customerParticipant.productShares = new List<ProductShare>();
													foreach (XmlNode share in node)
													{
														ProductShare productShare = new ProductShare();														
														foreach (XmlNode subnode in share)
														{
															switch (subnode.Name)
															{
																case "additional":
																	productShare.additional = subnode.InnerText;
																	break;
																case "exciseAmount":
																	productShare.exciseAmount = float.Parse(subnode.InnerText);
																	break;
																case "ndsAmount":
																	productShare.ndsAmount = float.Parse(subnode.InnerText);
																	break;
																case "priceWithTax":
																	productShare.priceWithTax = float.Parse(subnode.InnerText);
																	break;
																case "priceWithoutTax":
																	productShare.priceWithoutTax = float.Parse(subnode.InnerText);
																	break;
																case "productNumber":
																	productShare.productNumber = int.Parse(subnode.InnerText);
																	break;
																case "quantity":
																	productShare.quantity = int.Parse(subnode.InnerText);
																	break;
																case "turnoverSize":
																	productShare.turnoverSize = float.Parse(subnode.InnerText);
																	break;
																default:
																	break;
															}
														}
														customerParticipant.productShares.Add(productShare);
													}
													break;
												case "reorganizedTin":
													customerParticipant.reorganizedTin = node.InnerText;
													break;
												case "tin":
													customerParticipant.tin = node.InnerText;
													break;
												default:
													break;
											}
										}
										invoiceV2.customerParticipants.Add(customerParticipant);
									}
									break;
								case "customers":
									invoiceV2.customers = new List<CustomerV2>();
									foreach(XmlNode customer in item)
									{
										CustomerV2 customerV2 = new CustomerV2();
										foreach (XmlNode node in customer)
										{
											if(node.InnerText != "")
											{
												switch (node.Name)
												{
													case "address":
														customerV2.address = node.InnerText;
														break;
													case "branchTin":
														customerV2.branchTin = node.InnerText;
														break;
													case "countryCode":
														customerV2.countryCode = node.InnerText;
														break;
													case "name":
														customerV2.name = node.InnerText;
														break;
													case "reorganizedTin":
														customerV2.reorganizedTin = node.InnerText;
														break;
													case "shareParticipation":
														customerV2.shareParticipation = float.Parse(node.InnerText);
														break;
													case "statuses":
														customerV2.statuses = new List<CustomerType>();
														foreach(XmlNode status in node)
														{
															CustomerType customerType = new CustomerType();
															customerType = (CustomerType)Enum.Parse(typeof(CustomerType), status.InnerText);
															customerV2.statuses.Add(customerType);
														}
														break;
													case "tin":
														customerV2.tin = node.InnerText;
														break;
													case "trailer":
														customerV2.trailer = node.InnerText;
														break;
													default:
														break;
												}
											}											
										}
										invoiceV2.customers.Add(customerV2);
									}
									break;
								case "datePaper":
									tmp = item.InnerText.Split('.');
									day = int.Parse(tmp[0]);
									month = int.Parse(tmp[1]);
									year = int.Parse(tmp[2]);
									invoiceV2.datePaper = new DateTime(year, month, day);
									break;
								case "deliveryDocDate":
									tmp = item.InnerText.Split('.');
									day = int.Parse(tmp[0]);
									month = int.Parse(tmp[1]);
									year = int.Parse(tmp[2]);
									invoiceV2.deliveryDocDate = new DateTime(year, month, day);
									break;
								case "deliveryDocNum":
									invoiceV2.deliveryDocNum = item.InnerText;
									break;
								case "deliveryTerm":
									invoiceV2.deliveryTerm = new DeliveryTermV2();
									foreach (XmlNode node in item)
									{
										if (node.InnerText != "")
										{
											switch (node.Name)
											{
												case "contractDate":
													tmp = node.InnerText.Split('.');
													day = int.Parse(tmp[0]);
													month = int.Parse(tmp[1]);
													year = int.Parse(tmp[2]);
													invoiceV2.deliveryTerm.contractDate = new DateTime(year, month, day);
													break;
												case "contractNum":
													invoiceV2.deliveryTerm.contractNum = node.InnerText;
													break;
												case "deliveryConditionCode":
													invoiceV2.deliveryTerm.deliveryConditionCode = node.InnerText;
													break;
												case "destination":
													invoiceV2.deliveryTerm.destination = node.InnerText;
													break;
												case "hasContract":
													invoiceV2.deliveryTerm.hasContract = bool.Parse(node.InnerText);
													break;
												case "term":
													invoiceV2.deliveryTerm.term = node.InnerText;
													break;
												case "transportTypeCode":
													invoiceV2.deliveryTerm.transportTypeCode = node.InnerText;
													break;
												case "warrant":
													invoiceV2.deliveryTerm.warrant = node.InnerText;
													break;
												case "warrantDate":
													tmp = node.InnerText.Split('.');
													day = int.Parse(tmp[0]);
													month = int.Parse(tmp[1]);
													year = int.Parse(tmp[2]);
													invoiceV2.deliveryTerm.warrantDate = new DateTime(year, month, day);
													break;
												default:
													break;
											}
										}
									}
									break;
								case "productSet":
									invoiceV2.productSet = new ProductSetV2();
									foreach (XmlNode node in item)
									{
										if (node.InnerText != "")
										{
											switch (node.Name)
											{
												case "currencyCode":
													invoiceV2.productSet.currencyCode = node.InnerText;
													break;
												case "currencyRate":
													invoiceV2.productSet.currencyRate = float.Parse(node.InnerText);
													break;
												case "ndsRateType":
													invoiceV2.productSet.ndsRateType = (NdsRateType)Enum.Parse(typeof(NdsRateType), node.InnerText);
													break;
												case "products":
													invoiceV2.productSet.products = new List<ProductV2>();
													foreach (XmlNode product in node)
													{
														ProductV2 productV2 = new ProductV2();
														foreach (XmlNode subnode in product)
														{
															switch (subnode.Name)
															{
																case "additional":
																	productV2.additional = subnode.InnerText;
																	break;
																case "catalogTruId":
																	productV2.catalogTruId = subnode.InnerText;
																	break;
																case "description":
																	productV2.description = subnode.InnerText;
																	break;
																case "exciseAmount":
																	productV2.exciseAmount = float.Parse(subnode.InnerText);
																	break;
																case "exciseRate":
																	productV2.exciseRate= float.Parse(subnode.InnerText);
																	break;
																case "kpvedCode":
																	productV2.kpvedCode = subnode.InnerText;
																	break;
																case "ndsAmount":
																	productV2.ndsAmount = float.Parse(subnode.InnerText);
																	break;
																case "ndsRate":
																	productV2.ndsRate = int.Parse(subnode.InnerText);
																	break;
																case "priceWithTax":
																	productV2.priceWithTax= float.Parse(subnode.InnerText);
																	break;
																case "priceWithoutTax":
																	productV2.priceWithoutTax = float.Parse(subnode.InnerText);
																	break;
																case "productDeclaration":
																	productV2.productDeclaration = subnode.InnerText;
																	break;
																case "productNumberInDeclaration":
																	productV2.productNumberInDeclaration = subnode.InnerText;
																	break;
																case "quantity":
																	productV2.quantity = float.Parse(subnode.InnerText);
																	break;
																case "tnvedName":
																	productV2.tnvedName = subnode.InnerText;
																	break;
																case "truOriginCode":
																	productV2.truOriginCode = (TruOriginCode)Enum.Parse(typeof(TruOriginCode), subnode.InnerText);
																	break;
																case "turnoverSize":
																	productV2.turnoverSize = float.Parse(subnode.InnerText);
																	break;
																case "unitCode":
																	productV2.unitCode = subnode.InnerText;
																	break;
																case "unitNominclature":
																	productV2.unitNomenclature = subnode.InnerText;
																	break;
																case "unitPrice":
																	productV2.unitPrice = float.Parse(subnode.InnerText);
																	break;
																default:
																	break;
															}
														}
														invoiceV2.productSet.products.Add(productV2);
													}
													break;
												case "totalExciseAmount":
													invoiceV2.productSet.totalExciseAmount = float.Parse(node.InnerText);
													break;
												case "totalNdsAmount":
													invoiceV2.productSet.totalNdsAmount = float.Parse(node.InnerText);
													break;
												case "totalPriceWithTax":
													invoiceV2.productSet.totalPriceWithTax = float.Parse(node.InnerText);
													break;
												case "totalPriceWithoutTax":
													invoiceV2.productSet.totalPriceWithoutTax = float.Parse(node.InnerText);
													break;
												case "totalTurnoverSize":
													invoiceV2.productSet.totalTurnoverSize = float.Parse(node.InnerText);
													break;
												default:
													break;
											}
										}
									}
									break;
								case "publicOffice":
									invoiceV2.publicOffice = new PublicOffice();
									foreach (XmlNode node in item)
									{
										if (node.InnerText != "")
										{
											switch (node.Name)
											{
												case "bik":
													invoiceV2.publicOffice.bik = node.InnerText;
													break;
												case "iik":
													invoiceV2.publicOffice.iik = node.InnerText;
													break;
												case "payPurpose":
													invoiceV2.publicOffice.payPurpose = node.InnerText;
													break;
												case "productCode":
													invoiceV2.publicOffice.productCode = node.InnerText;
													break;
												default:
													break;
											}
										}
									}
									break;
								case "reasonPaper":
									invoiceV2.reasonPaper = (PaperReasonType)Enum.Parse(typeof(PaperReasonType), item.InnerText);
									break;
								case "sellerAgentAddress":
									invoiceV2.sellerAgentAddress = item.InnerText;
									break;
								case "sellerAgentDocDate":
									tmp = item.InnerText.Split('.');
									day = int.Parse(tmp[0]);
									month = int.Parse(tmp[1]);
									year = int.Parse(tmp[2]);
									invoiceV2.sellerAgentDocDate = new DateTime(year, month, day);
									break;
								case "sellerAgentDocNum":
									invoiceV2.sellerAgentDocNum = item.InnerText;
									break;
								case "sellerAgentName":
									invoiceV2.sellerAgentName = item.InnerText;
									break;
								case "sellerAgentTin":
									invoiceV2.sellerAgentTin = item.InnerText;
									break;
								case "sellerParticipants":
									invoiceV2.sellerParticipants = new List<ParticipantV2>();
									foreach (XmlNode participant in item)
									{
										ParticipantV2 sellerParticipant = new ParticipantV2();
										foreach (XmlNode node in participant)
										{
											switch (node.Name)
											{
												case "productShares":
													sellerParticipant.productShares = new List<ProductShare>();
													foreach (XmlNode share in node)
													{
														ProductShare productShare = new ProductShare();
														foreach (XmlNode subnode in share)
														{
															switch (subnode.Name)
															{
																case "additional":
																	productShare.additional = subnode.InnerText;
																	break;
																case "exciseAmount":
																	productShare.exciseAmount = float.Parse(subnode.InnerText);
																	break;
																case "ndsAmount":
																	productShare.ndsAmount = float.Parse(subnode.InnerText);
																	break;
																case "priceWithTax":
																	productShare.priceWithTax = float.Parse(subnode.InnerText);
																	break;
																case "priceWithoutTax":
																	productShare.priceWithoutTax = float.Parse(subnode.InnerText);
																	break;
																case "productNumber":
																	productShare.productNumber = int.Parse(subnode.InnerText);
																	break;
																case "quantity":
																	productShare.quantity = int.Parse(subnode.InnerText);
																	break;
																case "turnoverSize":
																	productShare.turnoverSize = float.Parse(subnode.InnerText);
																	break;
																default:
																	break;
															}
														}
														sellerParticipant.productShares.Add(productShare);
													}
													break;
												case "reorganizedTin":
													sellerParticipant.reorganizedTin = node.InnerText;
													break;
												case "tin":
													sellerParticipant.tin = node.InnerText;
													break;
												default:
													break;
											}
										}
										invoiceV2.sellerParticipants.Add(sellerParticipant);
									}
									break;

								case "sellers":
									invoiceV2.sellers = new List<SellerV2>();
									foreach (XmlNode seller in item)
									{
										SellerV2 sellerV2 = new SellerV2();
										foreach (XmlNode subitem in seller)
										{
											if (subitem.InnerText != "")
											{
												switch (subitem.Name)
												{
													case "address":
														sellerV2.address = subitem.InnerText;
														break;
													case "bank":
														sellerV2.bank = subitem.InnerText;
														break;
													case "bik":
														sellerV2.bik = subitem.InnerText;
														break;
													case "branchTin":
														sellerV2.branchTin = subitem.InnerText;
														break;
													case "certificateNum":
														sellerV2.certificateNum = subitem.InnerText;
														break;
													case "certificateSeries":
														sellerV2.certificateSeries = subitem.InnerText;
														break;
													case "iik":
														sellerV2.iik = subitem.InnerText;
														break;
													case "isBranchNonResident":
														sellerV2.isBranchNonResident = bool.Parse(subitem.InnerText);
														break;
													case "kbe":
														sellerV2.kbe = subitem.InnerText;
														break;
													case "name":
														sellerV2.name = subitem.InnerText;
														break;
													case "reorganizedTin":
														sellerV2.reorganizedTin = subitem.InnerText;
														break;
													case "shareParticipation":
														sellerV2.shareParticipation = float.Parse(subitem.InnerText);
														break;
													case "statuses":
														sellerV2.statuses = new List<SellerType>();
														foreach (XmlNode status in subitem)
														{
															sellerV2.statuses.Add((SellerType)Enum.Parse(typeof(SellerType), status.InnerText));
														}
														break;
													case "tin":
														sellerV2.tin = subitem.InnerText;
														break;
													case "trailer":
														sellerV2.trailer = subitem.InnerText;
														break;
													default:
														break;
												}
											}
										}
										invoiceV2.sellers.Add(sellerV2);
									}
									break;
								default:
									break;
							}
						}						
					}
					invoiceContainer.invoiceSet.Add(invoiceV2);
				}
			}
			return invoiceContainer;
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
			DateTime temp = getInvoiceDate();
			invoiceKey.date = String.Format("{0}.{1}.{2}", temp.Day, temp.Month, temp.Year);
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
			invoiceDate = date;
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

		private static DateTime getInvoiceDate()
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

		private static UploadInvoiceService.SignatureType getSignatureType()
		{
			return UploadInvoiceService.SignatureType.COMPANY;
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

			string str = "";
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(invoiceContainerV2));

			using (FileStream fs = new FileStream("testW.xml", FileMode.OpenOrCreate))
			using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
			{				
				xmlSerializer.Serialize(sw, getInvoiceContainer());
			}

			using (FileStream fs = new FileStream("testW.xml", FileMode.OpenOrCreate))
			using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
			{	
				str = sr.ReadToEnd();
			}

			return str;
		}

		private static List<SellerV2> getSellersV2()
		{
			List<SellerV2> sellerV2s = new List<SellerV2>();
			int tempSellersCount = getSellersCount();
			for (int sellerNum = 0; sellerNum < tempSellersCount; sellerNum++)
			{
				SellerV2 sellerV2 = new SellerV2();
				sellerV2.address = SessionDataManagerFacade.getSellerAddress(sellerNum);// "sellerAddress";
				sellerV2.bank = SessionDataManagerFacade.getSellerBank(sellerNum);// "sellerBank";
				sellerV2.bik = SessionDataManagerFacade.getSellerBik(sellerNum);// "sellerBik";
				sellerV2.branchTin = SessionDataManagerFacade.getSellerBranchTin(sellerNum);// "branchTin";
				sellerV2.certificateNum = getSellerCertificateNum(sellerNum);// "sellerCertNum";
				sellerV2.certificateSeries = SessionDataManagerFacade.getSellerCertificateSeries(sellerNum); //"sellerCertSeries";
				sellerV2.iik = SessionDataManagerFacade.getSellerIik(sellerNum);// "iik";
				sellerV2.isBranchNonResident = SessionDataManagerFacade.getSellerIsBranchNonResident(sellerNum);//true;
				sellerV2.kbe = SessionDataManagerFacade.getSellerKbe(sellerNum);// "kbe";
				sellerV2.name = SessionDataManagerFacade.getSellerName(sellerNum);// "sellerName";
				sellerV2.reorganizedTin = SessionDataManagerFacade.getSellerReorgTin(sellerNum);// "reorgTin";
				sellerV2.shareParticipation = SessionDataManagerFacade.getSellerShareParticipation(sellerNum);// 0.25f;																									 
				sellerV2.statuses = SessionDataManagerFacade.getSellerStatuses(sellerNum);//sellerTypes;
				sellerV2.tin = SessionDataManagerFacade.getSellerTin(sellerNum);// "tin";
				sellerV2.trailer = SessionDataManagerFacade.getSellerTrailer(sellerNum); //"trailer";
				sellerV2s.Add(sellerV2);
			}
			return sellerV2s;
		}

		private static string getSellerTrailer(int sellerNum)
		{
			return FormManagerFacade.getSellerTrailer(sellerNum);
		}

		private static string getSellerTin(int sellerNum)
		{
			return FormManagerFacade.getSellerTin(sellerNum);
		}

		private static List<SellerType> getSellerStatuses(int sellerNum)
		{			
			List<SellerType> sellerTypes = new List<SellerType>();
			int sellerTypesCount = getSellerStatusesCount(sellerNum);
			for (int statusId = 0; statusId < sellerTypesCount; statusId++)
			{
				SellerType sellerType = getSellerStatusById(sellerNum, statusId);
				sellerTypes.Add(sellerType);
			}			
			return sellerTypes;
		}

		private static SellerType getSellerStatusById(int sellerNum, int statusId)
		{
			return FormManagerFacade.getSellerStatusById(sellerNum, statusId);
		}

		private static int getSellerStatusesCount(int sellerNum)
		{
			return FormManagerFacade.getSellerStatusesCount(sellerNum);
		}

		private static float getSellerShareParticipation(int sellerNum)
		{
			return FormManagerFacade.getSellerShareParticipation(sellerNum);
		}

		private static string getSellerReorgTin(int sellerNum)
		{
			return FormManagerFacade.getSellerReorgTin(sellerNum);
		}

		private static string getSellerKbe(int sellerNum)
		{
			return FormManagerFacade.getSellerKbe(sellerNum);
		}

		private static string getSellerName(int sellerNum)
		{
			return FormManagerFacade.getSellerName(sellerNum);
		}

		private static bool getSellerIsBranchNonResident(int sellerNum)
		{
			return FormManagerFacade.getSellerIsBranchNonResident(sellerNum);
		}

		private static string getSellerIik(int sellerNum)
		{
			return FormManagerFacade.getSellerIik(sellerNum);
		}

		private static string getSellerCertificateSeries(int sellerNum)
		{
			return FormManagerFacade.getSellerCertificateSeries(sellerNum);
		}

		private static string getSellerCertificateNum(int sellerNum)
		{
			return FormManagerFacade.getSellerCertificateNum(sellerNum);
		}

		private static string getSellerBranchTin(int sellerNum)
		{
			return FormManagerFacade.getSellerBranchTin(sellerNum);
		}

		private static string getSellerBik(int sellerNum)
		{
			return FormManagerFacade.getSellerBik(sellerNum);
		}

		private static string getSellerBank(int sellerNum)
		{
			return FormManagerFacade.getSellerBank(sellerNum);
		}

		private static string getSellerAddress(int sellerNum)
		{
			return FormManagerFacade.getSellerAddress(sellerNum);
		}

		private static int getSellersCount()
		{
			return FormManagerFacade.getSellersCount();
		}

		private static List<ParticipantV2> getSellerParticipants()
		{
			List<ParticipantV2> sellerParticipantsList = new List<ParticipantV2>();
			int count = getSellerParticipantsCount();

			for (int i = 1; i <= count; i++)
			{
				sellerParticipantsList.Add(getSellerParticipant(i));
			}

			return sellerParticipantsList;
		}

		private static ParticipantV2 getSellerParticipant(int number)
		{
			ParticipantV2 sellerParticipant = new ParticipantV2();
			sellerParticipant.tin = getSellerParticipantTin(number);//"Participant #1 tin";
			sellerParticipant.reorganizedTin = getSellerParticipantReorgTin(number);//"Participant #1 reorganized Tin";				
			sellerParticipant.productShares = getProductSharesBySellerParticipant(number);
			return sellerParticipant;
		}

		private static List<ProductShare> getProductSharesBySellerParticipant(int number)
		{
			List<ProductShare> productShares = new List<ProductShare>();
			int tmpCount = FormManagerFacade.getShareBySellerParticipantCount(number);
			for (int i = 0; i < tmpCount; i++)
			{
				ProductShare productShare = new ProductShare();
				productShare.additional = getSellerProductShareAdditional(number, i);//"additional";
				productShare.exciseAmount = getSellerProductShareExciseAmount(number, i);//100;
				productShare.ndsAmount = getSellerProductShareNDSAmount(number, i);// 20;
				productShare.priceWithoutTax = getSellerProductSharePriceWithoutTax(number, i);//120;
				productShare.priceWithTax = getSellerProductSharePriceWithhTax(number, i);// 120;
				productShare.productNumber = getSellerProductShareProductNumber(number, i);// 1;
				productShare.quantity = getSellerProductShareQuantity(number, i);// 5;
				productShare.turnoverSize = getSellerProductShareTurnoverSize(number, i); //600;				
				productShares.Add(productShare);
			}
			return productShares;
		}

		private static float getSellerProductShareTurnoverSize(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductShareTurnoverSize(sellerNumber, productSharNum);
		}

		private static float getSellerProductShareQuantity(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductShareQuantity(sellerNumber, productSharNum);
		}


		private static int getSellerProductShareProductNumber(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductShareProductNumber(sellerNumber, productSharNum);
		}

		private static float getSellerProductSharePriceWithhTax(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductSharePriceWithhTax(sellerNumber, productSharNum);
		}

		private static float getSellerProductSharePriceWithoutTax(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductSharePriceWithoutTax(sellerNumber, productSharNum);
		}

		private static float getSellerProductShareNDSAmount(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductShareNDSAmount(sellerNumber, productSharNum);
		}

		private static float getSellerProductShareExciseAmount(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductShareExciseAmount(sellerNumber, productSharNum);
		}

		private static string getSellerProductShareAdditional(int sellerNumber, int productSharNum)
		{
			return FormManagerFacade.getSellerProductShareAdditional(sellerNumber, productSharNum);
		}

		private static string getSellerParticipantReorgTin(int number)
		{
			return FormManagerFacade.getSellerParticipantReorgTin(number);
		}

		private static string getSellerParticipantTin(int number)
		{
			return FormManagerFacade.getSellerParticipantTin(number);
		}

		private static int getSellerParticipantsCount()
		{
			return FormManagerFacade.getSellerParticipantsCount();
		}

		private static string getInvoiceSellerAgentTin()
		{
			return FormManagerFacade.getInvoiceSellerAgentTin();
		}

		private static string getInvoiceSellerAgentName()
		{
			return FormManagerFacade.getInvoiceSellerAgentName();
		}

		private static string getInvoiceSellerAgentDocNum()
		{
			return FormManagerFacade.getInvoiceSellerAgentDocNum();
		}

		private static DateTime getInvoiceSellerAgentDocDate()
		{
			return FormManagerFacade.getInvoiceSellerAgentDocDate();
		}

		private static string getInvoiceSellerAgentAddress()
		{
			return FormManagerFacade.getInvoiceSellerAgentAddress();
		}

		private static string getSellerCertificateSeries()
		{
			return FormManagerFacade.getSellerCertificateSeries();
		}

		private static PaperReasonType getReasonPaper()
		{
			return FormManagerFacade.getReasonPaper();
		}

		private static PublicOffice getPublicOffice()
		{
			PublicOffice publicOffice = new PublicOffice();
			publicOffice.bik = SessionDataManagerFacade.getPublicOfficeBik(); //"bik";
			publicOffice.iik = SessionDataManagerFacade.getPublicOfficeIik();// "iik";
			publicOffice.payPurpose = SessionDataManagerFacade.getPublicOfficePayPurpose();// "paypurp";
			publicOffice.productCode = SessionDataManagerFacade.getPublicOfficeProductCode();// "productCOde";
			return publicOffice;
		}

		private static string getPublicOfficeProductCode()
		{
			return FormManagerFacade.getPublicOfficeProductCode();
		}

		private static string getPublicOfficePayPurpose()
		{
			return FormManagerFacade.getPublicOfficePayPurpose();
		}

		private static string getPublicOfficeIik()
		{
			return FormManagerFacade.getPublicOfficeIik();
		}

		private static string getPublicOfficeBik()
		{
			return FormManagerFacade.getPublicOfficeBik();
		}

		private static ProductSetV2 getProductSetV2()
		{
			ProductSetV2 productSetV2 = new ProductSetV2();
			productSetV2.currencyCode = getProductSetCurrentCode();// "currentCode";
			productSetV2.currencyRate = getProductSetCurrencyRate();// 0.25f;
			productSetV2.ndsRateType = getProductSetNdsRateType();//.WITHOUT_NDS_NOT_KZ;				
			productSetV2.products = getProductsV2();
			productSetV2.totalExciseAmount = getProductSetTotalExciseAmount();// 100;
			productSetV2.totalNdsAmount = getProductSetTotalNDSAmount();// 100;
			productSetV2.totalPriceWithoutTax = getProductSetTotalPriceWithoutTax();// 100;
			productSetV2.totalPriceWithTax = getProductSetTotalPriceWithTax();// 200;
			productSetV2.totalTurnoverSize = getProductSetTotalTurnoverSize();// 200;

			return productSetV2;
		}

		private static float getProductSetTotalTurnoverSize()
		{
			return FormManagerFacade.getProductSetTotalTurnoverSize();
		}

		private static float getProductSetTotalPriceWithTax()
		{
			return FormManagerFacade.getProductSetTotalPriceWithTax();
		}

		private static float getProductSetTotalPriceWithoutTax()
		{
			return FormManagerFacade.getProductSetTotalPriceWithoutTax();
		}

		private static float getProductSetTotalNDSAmount()
		{
			return FormManagerFacade.getProductSetTotalNDSAmount();
		}

		private static float getProductSetTotalExciseAmount()
		{
			return FormManagerFacade.getProductSetTotalExciseAmount();
		}

		private static List<ProductV2> getProductsV2()
		{
			List<ProductV2> productV2s = new List<ProductV2>();
			int productsCount = getProductsCount();
			for (int productNum = 0; productNum < productsCount; productNum++)
			{
				ProductV2 product = new ProductV2();
				product.additional = getProductAdditional(productNum);//"additional";
				product.catalogTruId = getProductCatalogTruId(productNum);//"catalogTruId";
				product.description = getProductDescription(productNum);//"description";
				product.exciseAmount = getProductExciseAmount(productNum);// 10;
				product.exciseRate = getProductExciseRate(productNum);// 0.10f;
				product.kpvedCode = getProductKpvedCode(productNum);// "kpvedcode";
				product.ndsAmount = getProductNDSAmount(productNum);// 10.2f;
				product.ndsRate = getProductNDSRAte(productNum);// 1;
				product.priceWithoutTax = getProductPriceWithoutTax(productNum);// 10;
				product.priceWithTax = getProductPriceWithTax(productNum);// 20.3f;
				product.productDeclaration = getProductDeclaration(productNum);// "declration";
				product.productNumberInDeclaration = getProductNumberInDexlaration(productNum);// "numInDec";
				product.tnvedName = getProductTnvedName(productNum);// "tnvedName";
				product.truOriginCode = getProductTruOriginCode(productNum);// TruOriginCode.three;
				product.turnoverSize = getProductTurnoverSize(productNum); //40.36f;
				product.unitCode = getProductUnitCode(productNum);// "unitcode";
				product.unitNomenclature = getProductUnitNominclature(productNum);// "unitNomen";
				product.unitPrice = getProductUnitPrice(productNum);// 20.3f;			
				productV2s.Add(product);
			}
			return productV2s;
		}

		private static float getProductUnitPrice(int productNum)
		{
			return FormManagerFacade.getProductUnitPrice(productNum);
		}

		private static string getProductUnitNominclature(int productNum)
		{
			return FormManagerFacade.getProductUnitNominclature(productNum);
		}

		private static string getProductUnitCode(int productNum)
		{
			return FormManagerFacade.getProductUnitCode(productNum);
		}

		private static float getProductTurnoverSize(int productNum)
		{
			return FormManagerFacade.getProductTurnoverSize(productNum);
		}

		private static TruOriginCode getProductTruOriginCode(int productNum)
		{
			return FormManagerFacade.getProductTruOriginCode(productNum);
		}

		private static string getProductTnvedName(int productNum)
		{
			return FormManagerFacade.getProductTnvedName(productNum);
		}

		private static string getProductNumberInDexlaration(int productNum)
		{
			return FormManagerFacade.getProductNumberInDexlaration(productNum);
		}

		private static float getProductPriceWithTax(int productNum)
		{
			return FormManagerFacade.getProductPriceWithTax(productNum);
		}

		private static string getProductDeclaration(int productNum)
		{
			return FormManagerFacade.getProductDeclaration(productNum);
		}

		private static float getProductPriceWithoutTax(int productNum)
		{
			return FormManagerFacade.getProductPriceWithoutTax(productNum);
		}

		private static int getProductNDSRAte(int productNum)
		{
			return FormManagerFacade.getProductNDSRAte(productNum);
		}

		private static float getProductNDSAmount(int productNum)
		{
			return FormManagerFacade.getProductNDSAmount(productNum);
		}

		private static string getProductKpvedCode(int productNum)
		{
			return FormManagerFacade.getProductKpvedCode(productNum);
		}

		private static float getProductExciseRate(int productNum)
		{
			return FormManagerFacade.getProductExciseRate(productNum);
		}

		private static float getProductExciseAmount(int productNum)
		{
			return FormManagerFacade.getProductExciseAmount(productNum);
		}

		private static string getProductDescription(int productNum)
		{
			return FormManagerFacade.getProductDescription(productNum);
		}

		private static string getProductCatalogTruId(int productNum)
		{
			return FormManagerFacade.getProductCatalogTruId(productNum);
		}

		private static string getProductAdditional(int productNum)
		{
			return FormManagerFacade.getProductAdditional(productNum);
		}

		private static int getProductsCount()
		{
			return FormManagerFacade.getProductsCount();
		}

		private static NdsRateType getProductSetNdsRateType()
		{
			return FormManagerFacade.getProductSetNdsRateType();
		}

		private static float getProductSetCurrencyRate()
		{
			return FormManagerFacade.getProductSetCurrencyRate();
		}

		private static string getProductSetCurrentCode()
		{
			return FormManagerFacade.getProductSetCurrentCode();
		}

		private static DeliveryTermV2 getDeliveryTermV2()
		{
			DeliveryTermV2 deliveryTermV2 = new DeliveryTermV2();
			deliveryTermV2.contractDate = getDeliveryTermContractDate();//DateTime.Now;
			deliveryTermV2.contractNum = getDeliveryTermContractNum();//"ContractNum";
			deliveryTermV2.deliveryConditionCode = getDeliveryTermConditiomCode();// "deliveryConditionCode";
			deliveryTermV2.destination = getDeliveryTermDestination();// "destination";
			deliveryTermV2.hasContract = getDeliveryTermHasContract();// true;
			deliveryTermV2.term = getDeliveryTermTerm();// "term";
			deliveryTermV2.transportTypeCode = getDeliveryTermTransportTypeCode(); //"transportTypeCode";
			deliveryTermV2.warrant = getDeliveryTermWarrant();// "wRRnt";
			deliveryTermV2.warrantDate = getDeliveryTermWarrantDate();// DateTime.Now;
			return deliveryTermV2;
		}

		private static DateTime getDeliveryTermWarrantDate()
		{
			return FormManagerFacade.getDeliveryTermWarrantDate();
		}

		private static string getDeliveryTermWarrant()
		{
			return FormManagerFacade.getDeliveryTermWarrant();
		}

		private static string getDeliveryTermTransportTypeCode()
		{
			return FormManagerFacade.getDeliveryTermTransportTypeCode();
		}

		private static string getDeliveryTermTerm()
		{
			return FormManagerFacade.getDeliveryTermTerm();
		}

		private static bool getDeliveryTermHasContract()
		{
			return FormManagerFacade.getDeliveryTermHasContract();
		}

		private static string getDeliveryTermDestination()
		{
			return FormManagerFacade.getDeliveryTermDestination();
		}

		private static string getDeliveryTermConditiomCode()
		{
			return FormManagerFacade.getDeliveryTermConditiomCode();
		}

		private static string getDeliveryTermContractNum()
		{
			return FormManagerFacade.getDeliveryTermContractNum();
		}

		private static DateTime getDeliveryTermContractDate()
		{
			return FormManagerFacade.getDeliveryTermContractDate();
		}

		private static string getInvoiceDeliveryDocNum()
		{
			return FormManagerFacade.getInvoiceDeliveryDocNum();
		}

		private static DateTime getInvoiceDeliveryDocDate()
		{
			return FormManagerFacade.getInvoiceDeliveryDocDate();
		}

		private static DateTime getInvoiceDatePaper()
		{
			return FormManagerFacade.getInvoiceDatePaper();
		}

		private static List<CustomerV2> getCustomers()
		{
			List<CustomerV2> customerV2s = new List<CustomerV2>();
			int tempCount = getCustomersCount();
			for (int customerNumber = 0; customerNumber < tempCount; customerNumber++)
			{
				CustomerV2 customerV2 = new CustomerV2();
				customerV2.address = getCustomerAddress(customerNumber);// "CUstomer Address";
				customerV2.branchTin = getCustomerBranchTin(customerNumber);// "Customer branchTiN";
				customerV2.countryCode = getCustomerCountryCode(customerNumber);// "KZ";
				customerV2.name = getCustomerName(customerNumber);// "customerName";
				customerV2.reorganizedTin = getCustomerReorgTin(customerNumber);// "customerreorgtin";
				customerV2.shareParticipation = getCustomerShareParticipation(customerNumber);//0.22f;				
				customerV2.statuses = getCustomerStatusesByCustomer(customerNumber);// statuses;
				customerV2.tin = getCustomerTin(customerNumber); //"customerTin";
				customerV2.trailer = getCustomerTrailer(customerNumber); //"custtrailer";				
				customerV2s.Add(customerV2);
			}			
			return customerV2s;
		}

		private static string getCustomerTrailer(int customerNumber)
		{
			return FormManagerFacade.getCustomerTrailer(customerNumber);
		}

		private static string getCustomerTin(int customerNumber)
		{
			return FormManagerFacade.getCustomerTin(customerNumber);
		}

		private static List<CustomerType> getCustomerStatusesByCustomer(int customerNumber)
		{
			List<CustomerType> statuses = new List<CustomerType>();
			int tempCount = getCustomerStatusesCount(customerNumber);
			for (int statusId = 0; statusId < tempCount; statusId++)
			{
				CustomerType customerType = getCustomerStatusById(customerNumber, statusId);
				statuses.Add(customerType);
			}
			return statuses;
		}

		private static CustomerType getCustomerStatusById(int customerNumber, int statusId)
		{
			return FormManagerFacade.getCustomerStatusById(customerNumber, statusId);
		}

		private static int getCustomerStatusesCount(int customerNumber)
		{
			return FormManagerFacade.getCustomerStatusesCount(customerNumber);
		}

		private static float getCustomerShareParticipation(int customerNumber)
		{
			return FormManagerFacade.getCustomerShareParticipation(customerNumber);
		}

		private static string getCustomerReorgTin(int customerNumber)
		{
			return FormManagerFacade.getCustomerReorgTin(customerNumber);
		}

		private static string getCustomerName(int customerNumber)
		{
			return FormManagerFacade.getCustomerName(customerNumber);
		}

		private static string getCustomerCountryCode(int customerNumber)
		{
			return FormManagerFacade.getCustomerCountryCode(customerNumber);
		}

		private static string getCustomerAddress(int customerNumber)
		{
			return FormManagerFacade.getCustomerAddress(customerNumber);
		}

		private static string getCustomerBranchTin(int customerNumber)
		{
			return FormManagerFacade.getCustomerBranchTin(customerNumber);
		}

		private static int getCustomersCount()
		{
			return FormManagerFacade.getCustomersCount();
		}

		private static List<ParticipantV2> getCustomerParticipants()
		{

			List<ParticipantV2> customerParticipantsList = new List<ParticipantV2>();
			int count = getCustomerParticipantsCount();

			for (int i = 1; i <= count; i++)
			{
				customerParticipantsList.Add(getCustomerParticipant(i));
			}			

			return customerParticipantsList;
		}

		private static ParticipantV2 getCustomerParticipant(int number)
		{
			ParticipantV2 customerParticipant = new ParticipantV2();
			customerParticipant.tin = getCustomerParticipantTin(number);//"Participant #1 tin";
			customerParticipant.reorganizedTin = getCustomerParticipantReorgTin(number);//"Participant #1 reorganized Tin";				
			customerParticipant.productShares = getProductSharesByCustomerParticipant(number);
			return customerParticipant;
		}

		private static List<ProductShare> getProductSharesByCustomerParticipant(int number)
		{
			List<ProductShare> productShares = new List<ProductShare>();
			int tmpCount = FormManagerFacade.getShareByCustomerParticipantCount(number);
			for (int i = 0; i < tmpCount; i++)
			{
				ProductShare productShare = new ProductShare();
				productShare.additional = getCustomerProductShareAdditional(number,i);//"additional";
				productShare.exciseAmount = getCustomerProductShareExciseAmount(number, i);//100;
				productShare.ndsAmount = getCustomerProductShareNDSAmount(number, i);// 20;
				productShare.priceWithoutTax = getCustomerProductSharePriceWithoutTax(number, i);//120;
				productShare.priceWithTax = getCustomerProductSharePriceWithhTax(number, i);// 120;
				productShare.productNumber = getCustomerProductShareProductNumber(number, i);// 1;
				productShare.quantity = getCustomerProductShareQuantity(number, i);// 5;
				productShare.turnoverSize = getCustomerProductShareTurnoverSize(number, i); //600;				
				productShares.Add(productShare);
			}			
			return productShares;
		}

		private static float getCustomerProductShareTurnoverSize(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductShareTurnoverSize(participantNumber, productShareNumber);
		}

		private static float getCustomerProductShareQuantity(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductShareQuantity(participantNumber, productShareNumber);
		}

		private static int getCustomerProductShareProductNumber(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductShareProductNumber(participantNumber, productShareNumber);
		}

		private static float getCustomerProductSharePriceWithhTax(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductSharePriceWithhTax(participantNumber, productShareNumber);
		}

		private static float getCustomerProductSharePriceWithoutTax(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductSharePriceWithoutTax(participantNumber, productShareNumber);
		}

		private static float getCustomerProductShareNDSAmount(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductShareNDSAmount(participantNumber, productShareNumber);
		}

		private static float getCustomerProductShareExciseAmount(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductShareExciseAmount(participantNumber, productShareNumber);
		}

		private static string getCustomerProductShareAdditional(int participantNumber, int productShareNumber)
		{
			return FormManagerFacade.getCustomerProductShareAdditional(participantNumber, productShareNumber);
		}

		private static string getCustomerParticipantReorgTin(int number)
		{
			return FormManagerFacade.getCustomerParticipantReorgTin(number);
		}

		private static string getCustomerParticipantTin(int number)
		{
			return FormManagerFacade.getCustomerParticipantTin(number);
		}

		private static int getCustomerParticipantsCount()
		{
			return FormManagerFacade.getCustomerParticipantsCount();
		}

		private static string getCustomerAgentTin()
		{
			return FormManagerFacade.getCustomerAgentTin();
		}

		private static string getCustomerAgentName()
		{
			return FormManagerFacade.getCustomerAgentName();
		}

		private static string getCustomerAgentDocNum()
		{
			return FormManagerFacade.getCustomerAgentDocNum();
		}

		private static DateTime getCustomerAgentDocDate()
		{
			return FormManagerFacade.getCustomerAgentDocDate();
		}

		private static string getCustomerAgentAddress()
		{
			return FormManagerFacade.getCustomerAgentAddress();
		}

		private static Consignor getConsignor()
		{
			Consignor consignor = new Consignor();
			consignor.address = getConsignorAddress();// "Consegnor Address";
			consignor.name = getConsignorName(); //"Consignor Name";
			consignor.tin = getConsignorTin();//"Consignor Tin";
			return consignor;
		}

		private static string getConsignorTin()
		{
			return FormManagerFacade.getConsignorTin();
		}

		private static string getConsignorName()
		{
			return FormManagerFacade.getConsignorName();
		}

		private static string getConsignorAddress()
		{
			return FormManagerFacade.getConsignorAddress();
		}

		private static ConsigneeV2 getConsignee()
		{
			ConsigneeV2 consigneeV2 = new ConsigneeV2();
			consigneeV2.address = getConsigneeAddress();//"Consegnee Adress";
			consigneeV2.countryCode = getConsigneeCountryCode();//"KZ";
			consigneeV2.name = getConsigneeName();// "Consegnee Name";
			consigneeV2.tin = getConsigneeTin();// "COnsegnee Tin";
			return consigneeV2;
		}

		private static string getConsigneeTin()
		{
			return FormManagerFacade.getConsigneeTin();
		}

		private static string getConsigneeName()
		{
			return FormManagerFacade.getConsigneeName();
		}

		private static string getConsigneeCountryCode()
		{
			return FormManagerFacade.getConsigneeCountryCode();
		}

		private static string getConsigneeAddress()
		{
			return FormManagerFacade.getConsigneeAddress();
		}

		private static string getInvoiceAddInf()
		{
			return FormManagerFacade.getInvoiceAddInf();
		}

		private static DateTime getInvoiceTurnoverDate()
		{
			return FormManagerFacade.getInvoiceTurnoverDate();
		}

		private static RelatedInvoice getRelatedInvoice()
		{
			RelatedInvoice relatedInvoice = new RelatedInvoice();
			relatedInvoice.date = getRelatedInvoiceDate();//DateTime.Now;
			relatedInvoice.num = getRelatedInvoiceNum();//"relatedInv num";
			relatedInvoice.registrationNumber = getRelatedInvoiceRegistrationNum();// "registrat NUmber";
			return relatedInvoice;
		}

		private static string getRelatedInvoiceRegistrationNum()
		{
			return FormManagerFacade.getRelatedInvoiceRegistrationNum();
		}

		private static string getRelatedInvoiceNum()
		{
			return FormManagerFacade.getRelatedInvoiceNum();
		}

		private static DateTime getRelatedInvoiceDate()
		{
			return FormManagerFacade.getRelatedInvoiceDate();
		}

		private static string getOperatorFullname()
		{
			return FormManagerFacade.getOperatorFullname();
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

		internal static invoiceContainerV2 getInvoiceContainer()
		{
			invoiceContainerV2 inContainerV2 = new invoiceContainerV2();
			List<InvoiceV2> invoiceV2s = new List<InvoiceV2>();
			invoiceV2s.Add(getInvoice());
			inContainerV2.invoiceSet = invoiceV2s;
			return inContainerV2;
		}

		private static InvoiceV2 getInvoice()
		{
			InvoiceV2 invoiceV2 = new InvoiceV2();
			invoiceV2.invoiceType = getInvoiceType();//InvoiceType.ORDINARY_INVOICE;
			invoiceV2.date = getInvoiceDate();// DateTime.Now;
			invoiceV2.num = getInvoiceNum();//"invoice num";
			invoiceV2.operatorFullname = getOperatorFullname();//"Kassov Viktor";				
			invoiceV2.relatedInvoice = getRelatedInvoice();
			invoiceV2.turnoverDate = getInvoiceTurnoverDate();//DateTime.Now;
			invoiceV2.addInf = getInvoiceAddInf();//"addInf";				
			invoiceV2.consignee = getConsignee();
			invoiceV2.consignor = getConsignor();
			invoiceV2.customerAgentAddress = getCustomerAgentAddress();//"customerAgentAddress";
			invoiceV2.customerAgentDocDate = getCustomerAgentDocDate();//DateTime.Now;
			invoiceV2.customerAgentDocNum = getCustomerAgentDocNum();// "customerAgentDocNum";
			invoiceV2.customerAgentName = getCustomerAgentName();//"customerAgentName";
			invoiceV2.customerAgentTin = getCustomerAgentTin();//"customerAgentTin";				
			invoiceV2.customerParticipants = getCustomerParticipants();
			invoiceV2.customers = getCustomers();
			invoiceV2.datePaper = getInvoiceDatePaper();// DateTime.Now;
			invoiceV2.deliveryDocDate = getInvoiceDeliveryDocDate();//DateTime.Now;
			invoiceV2.deliveryDocNum = getInvoiceDeliveryDocNum();//"DeliveryDocNum";				
			invoiceV2.deliveryTerm = getDeliveryTermV2();
			invoiceV2.productSet = getProductSetV2();
			invoiceV2.publicOffice = getPublicOffice();
			invoiceV2.reasonPaper = getReasonPaper();// PaperReasonType.MISSING_REQUIREMENT;
			invoiceV2.sellerAgentAddress = getInvoiceSellerAgentAddress();// "sellerAgentAddress";
			invoiceV2.sellerAgentDocDate = getInvoiceSellerAgentDocDate();// DateTime.Now;
			invoiceV2.sellerAgentDocNum = getInvoiceSellerAgentDocNum();// "sellerAgentDocNum";
			invoiceV2.sellerAgentName = getInvoiceSellerAgentName();// "sellerAgentName";
			invoiceV2.sellerAgentTin = getInvoiceSellerAgentTin();// "sellerAgentTin";				
			invoiceV2.sellerParticipants = getSellerParticipants();
			invoiceV2.sellers = getSellersV2();
			return invoiceV2;
		}

		private static InvoiceType getInvoiceType()
		{
			return invoiceType;
		}
	}
}
