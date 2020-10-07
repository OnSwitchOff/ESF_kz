using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESF_kz
{
	static class ParsingManager
	{
		internal static float ParseStringToFLoat(string str)
		{
			return float.Parse(str);
		}

		internal static T ParseStringToEnum<T>(string str) where T: Enum
		{
			return  (T)Enum.Parse(typeof(T), str);
		}

		internal static string getInvoiceBodyString(InvoiceV2 invoice)
		{
			string result;
			XNamespace a = "abstractInvoice.esf";
			XNamespace v2 = "v2.esf";
			XAttribute xA = new XAttribute(XNamespace.Xmlns + "a", a.NamespaceName);
			XAttribute xV2 = new XAttribute(XNamespace.Xmlns + "v2", v2.NamespaceName);
			XElement xInvoice = new XElement(v2 + "invoice", xA, xV2);

			//XElement num = new XElement("num", "123");
			//xInvoice.Add(num);

			foreach (FieldInfo fi in typeof(InvoiceV2).GetFields())
			{
				object value = invoice.GetType().GetField(fi.Name).GetValue(invoice);
				if(value != null)
				{
					switch (fi.FieldType.ToString())
					{
						case "System.String":
							if (value != "")
							{
								XElement stringEl = new XElement(fi.Name, value);
								xInvoice.Add(stringEl);
							}							
							break;
						case "System.DateTime":
							XElement dateEl = new XElement(fi.Name, ((DateTime)value).ToString("dd.MM.yyyy"));
							xInvoice.Add(dateEl);
							break;
						default:
							Regex objectRegex = new Regex(@"^ESF_kz[.]");							
							bool isObject = objectRegex.IsMatch(fi.FieldType.ToString());
							Regex listRegex = new Regex(@"System[.]Collections[.]Generic[.]List`1[[]ESF_kz[.]\w*[]]$");
							bool isList = listRegex.IsMatch(fi.FieldType.ToString());
							if (isObject)
							{
								Regex typeRegex = new Regex(@".*Type$");
								if (typeRegex.IsMatch(fi.FieldType.ToString()))
								{
									XElement enumEl = new XElement(fi.Name, value.ToString());
									xInvoice.Add(enumEl);
								}
								else
								{
									var attrs = fi.GetCustomAttributes();
									Match m2 = Regex.Match(fi.FieldType.ToString(), "^ESF_kz[.](.*?)$");
									string tagName = m2.Groups[1].ToString().Replace("V2","");
									tagName = fi.Name;
									xInvoice.Add(getXmlStringByObject(value, tagName));
								}								
							}
							else if (isList)
							{
								string lisTagName = fi.Name;
								xInvoice.Add(getXmlStringByList(value, lisTagName));
							}							
							break;
					}
				}	
			}
			result = xInvoice.ToString();
			return result;
		}

		private static object getXmlStringByList(object value, string tagName)
		{
			XElement listEl = new XElement(tagName);
		
			foreach (var item in value as IEnumerable<object>)
			{
				string itemTag = item.GetType().Name.ToString();
				listEl.Add(getXmlStringByObject(item, itemTag));
			}

			return listEl;
		}

		private static XElement getXmlStringByObject(object value, string tagName)
		{
			XElement classEl = new XElement(tagName);

			foreach  (FieldInfo fi in value.GetType().GetFields())
			{
				object fieldValue = value.GetType().GetField(fi.Name).GetValue(value);
				if (fieldValue !=null)
				{
					switch (fi.FieldType.ToString())
					{
						case "System.String":
							if(fieldValue!="")
							{
								XElement stringEl = new XElement(fi.Name, fieldValue);
								classEl.Add(stringEl);
							}							
							break;
						case "System.DateTime":
							XElement dateEl = new XElement(fi.Name, ((DateTime)fieldValue).ToString("dd.MM.yyyy"));
							classEl.Add(dateEl);
							break;
						default:
							Regex objectRegex = new Regex(@"^ESF_kz[.]");
							bool isObject = objectRegex.IsMatch(fi.FieldType.ToString());
							Regex listRegex = new Regex(@"System[.]Collections[.]Generic[.]List`1[[]ESF_kz[.]\w*[]]$");
							bool isList = listRegex.IsMatch(fi.FieldType.ToString());
							if (isObject)
							{
								Regex typeRegex = new Regex(@".*Type$");

								if (typeRegex.IsMatch(fi.FieldType.ToString()))
								{
									XElement enumEl = new XElement(fi.Name, fieldValue.ToString());
									classEl.Add(enumEl);
								}
								else
								{
									Match m2 = Regex.Match(fi.FieldType.ToString(), "^ESF_kz[.](.*?)$");
									string tag = m2.Groups[1].ToString().Replace("V2", "");
									tag = fi.Name;
									classEl.Add(getXmlStringByObject(fieldValue, tag));
								}								
							}
							else if (isList)
							{
								string lisTagName = fi.Name;
								classEl.Add(getXmlStringByList(fieldValue, lisTagName));
							}							
							break;
					}
				}
			}

			return classEl;
		}
	}
}
