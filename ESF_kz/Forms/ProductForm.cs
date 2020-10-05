using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESF_kz.Forms
{
	public partial class ProductForm : Form
	{
		public ProductForm()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			ProductV2 product = new ProductV2();
			product.truOriginCode = (TruOriginCode)Enum.Parse(typeof(TruOriginCode),tbProductTruOriginCode.Text);
			product.description = tbProductDescription.Text;
			product.tnvedName = tbProductTnvedName.Text;
			product.unitCode = tbProductUnitCode.Text;
			product.unitNomenclature = tbProductUnitNomenclature.Text;
			product.quantity = float.Parse(tbProductQuantity.Text);
			product.unitPrice = float.Parse(tbProductUnitPrice.Text);
			product.priceWithoutTax = float.Parse(tbProductPriceWithoutTax.Text);
			product.exciseRate = float.Parse(tbProductExciseRate.Text);
			product.exciseAmount = float.Parse(tbProductExciseAmount.Text);
			product.turnoverSize = float.Parse(tbProductTurnoverSize.Text);
			product.ndsRate = int.Parse(tbProductNdsRate.Text);
			product.ndsAmount = float.Parse(tbProductNdsAmount.Text);
			product.priceWithTax = float.Parse(tbProductPriceWithTax.Text);
			product.productDeclaration = tbProductProductDeclaration.Text;
			product.productNumberInDeclaration = tbProductNumberInDeclaration.Text;
			product.catalogTruId = tbProductTruOriginCode.Text;
			product.additional = tbProductAdditional.Text;
			FormManagerFacade.AddNewProductRow(product);
			this.Close();			
		}
	}
}
