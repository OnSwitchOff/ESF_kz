using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESF_kz.Forms
{
	public partial class ProductForm : Form
	{
		public ProductForm()
		{
			InitializeComponent();
			foreach(TruOriginCode code in Enum.GetValues(typeof(TruOriginCode)))
			{
				cbProductTruOriginCode.Items.Add(code.ToString());
			}
			FormManagerFacade.setProductForm(this);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			ProductV2 product = FormManagerFacade.getProductFromProductForm();			
			FormManagerFacade.AddNewProductRow(product);
			this.Close();			
		}

		internal ProductV2 getProductFromForm()
		{
			ProductV2 product = new ProductV2();
			SessionDataManagerFacade.EnumFieldInintitalize(ref product.truOriginCode, cbProductTruOriginCode.Text);
			product.description = tbProductDescription.Text;
			product.tnvedName = tbProductTnvedName.Text;
			product.unitCode = tbProductUnitCode.Text;
			product.unitNomenclature = tbProductUnitNomenclature.Text;
			product.quantity = float.Parse(tbProductQuantity.Text);
			product.unitPrice = float.Parse(tbProductUnitPrice.Text);
			product.priceWithoutTax = product.quantity * product.unitPrice;		
			product.exciseRate = float.Parse(tbProductExciseRate.Text);
			product.exciseAmount = product.priceWithoutTax * product.exciseRate/100;
			product.turnoverSize = product.priceWithoutTax + product.exciseAmount;
			product.ndsRate = int.Parse(tbProductNdsRate.Text);
			product.ndsAmount = product.turnoverSize * product.ndsRate / 100;
			product.priceWithTax = product.turnoverSize + product.ndsAmount;
			product.productDeclaration = tbProductProductDeclaration.Text;
			product.productNumberInDeclaration = tbProductNumberInDeclaration.Text;
			product.catalogTruId = tbProductCatalogTruId.Text;
			product.additional = tbProductAdditional.Text;
			return product;
		}

		private void tbProductQuantity_Validated(object sender, EventArgs e)
		{
			ValidatingManager.ValidateFloatTextBox(tbProductQuantity,epProductFormQuantity);			
		}

		private void tbProductUnitPrice_Validated(object sender, EventArgs e)
		{
			ValidatingManager.ValidateFloatTextBox(tbProductUnitPrice, epProductUnitPrice);
		}

		private void tbProductExciseRate_Validated(object sender, EventArgs e)
		{
			ValidatingManager.ValidateFloatTextBox(tbProductExciseRate, epProductExciseRate);
		}

		private void tbProductNdsRate_Validated(object sender, EventArgs e)
		{
			ValidatingManager.ValidateIntegerTextBox(tbProductNdsRate, epProductNdsRate);
		}

		internal void setTruOriginCode(TruOriginCode truOriginCode)
		{
			cbProductTruOriginCode.Text = truOriginCode.ToString();
		}

		internal void setDescription(string description)
		{
			tbProductDescription.Text = description;
		}

		internal void setTnvedName(string tnvedName)
		{
			tbProductTnvedName.Text = tnvedName;
		}

		internal void setUnitCode(string unitCode)
		{
			tbProductUnitCode.Text = unitCode;
		}

		internal void setUnitNomenclature(string unitNomenclature)
		{
			tbProductUnitNomenclature.Text = unitNomenclature;
		}

		internal void setQuantity(float quantity)
		{
			tbProductQuantity.Text = quantity.ToString();
		}

		internal void setUnitPrice(float unitPrice)
		{
			tbProductUnitPrice.Text = unitPrice.ToString();
		}

		internal void setExciseRate(float exciseRate)
		{
			tbProductExciseRate.Text = exciseRate.ToString();
		}

		internal void setNdsRate(int ndsRate)
		{
			tbProductNdsRate.Text = ndsRate.ToString();
		}

		internal void setProductDeclaration(string productDeclaration)
		{
			tbProductProductDeclaration.Text = productDeclaration;
		}

		internal void setProductNumberInDeclaration(string productNumberInDeclaration)
		{
			tbProductNumberInDeclaration.Text = productNumberInDeclaration;
		}

		internal void setCatalogTruId(string catalogTruId)
		{
			tbProductCatalogTruId.Text = catalogTruId;
		}

		internal void setAdditional(string additional)
		{
			tbProductAdditional.Text = additional;
		}
	}
}
