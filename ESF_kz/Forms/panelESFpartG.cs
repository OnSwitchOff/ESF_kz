using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESF_kz.Forms
{
	public partial class panelESFpartG : AbstractUCESFpanel
	{
		enum column
		{
			rowNumber,
			typeTRN,
			nameTRN,
			fullnameTRN,
			TNVED,
			measure,
			quantity,
			pricePerOne,
			priceWithoutTax,
			exciseRate,
			exciseAmount,
			turnoverSize,
			ndsRate,
			ndsAmount,
			priceWithTax,
			productDeclaration,
			productNumberInDeclaration,
			catalogTruId,
			additional
		}

		public panelESFpartG()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{

		}

		internal string getProductSetCurrentCode()
		{
			return tbPartG_currencyCode.Text;
		}

		internal bool setProductSetCurrentCode(string code)
		{
			try
			{
				tbPartG_currencyCode.Text = code;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductSetCurrencyRate()
		{
			return float.Parse(tbPartG_currencyRate.Text);
		}

		internal bool setProductSetCurrencyRate(string rate)
		{
			try
			{
				tbPartG_currencyRate.Text = rate;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal int getProductsCount()
		{
			return GetDataGrid().Rows.Count;
		}

		internal DataGridView GetDataGrid()
		{
			return dataGridView1;
		}

		internal string getProductAdditional(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.additional].Value.ToString();
		}

		internal bool setProductAdditional(int productNum,string additional)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.additional].Value = additional;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductCatalogTruId(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.catalogTruId].Value.ToString();
		}

		internal bool setProductCatalogTruId(int productNum, string TRUid)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.catalogTruId].Value = TRUid;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductDescription(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.nameTRN].Value.ToString();
		}


		internal bool setProductDescription(int productNum, string nameTRN)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.nameTRN].Value = nameTRN;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductExciseAmount(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.exciseAmount].Value;
		}

		internal bool setProductExciseAmount(int productNum, float exciseAmount)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.exciseAmount].Value = exciseAmount;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductExciseRate(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.exciseRate].Value;
		}

		internal string getProductKpvedCode(int productNum)
		{
			throw new NotImplementedException();
		}

		internal float getProductNDSAmount(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.ndsAmount].Value;
		}

		internal bool setProductNDSAmount(int productNum, float ndsAmount)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.ndsAmount].Value = ndsAmount;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal int getProductNDSRate(int productNum)
		{
			return (int)GetDataGrid().Rows[productNum].Cells[(int)column.ndsRate].Value;
		}

		internal bool setProductNDSRate(int productNum, int ndsRate)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.ndsAmount].Value = ndsRate;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductPriceWithoutTax(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.priceWithoutTax].Value;
		}

		internal bool setProductPriceWithoutTax(int productNum, float priceWithoutTax)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.priceWithoutTax].Value = priceWithoutTax;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductDeclaration(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.productDeclaration].Value.ToString();
		}

		internal bool setProductDeclaration(int productNum, string declaration)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.productDeclaration].Value = declaration;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductPriceWithTax(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.priceWithTax].Value;
		}

		internal bool setProductPriceWithTax(int productNum, float priceWithTax)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.priceWithTax].Value = priceWithTax;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductNumberInDexlaration(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.productNumberInDeclaration].Value.ToString();
		}

		internal bool setProductNumberInDexlaration(int productNum,string num)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.productNumberInDeclaration].Value = num;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductTnvedName(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.fullnameTRN].Value.ToString();
		}

		internal bool setProductTnvedName(int productNum, string tnvedName)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.fullnameTRN].Value = tnvedName;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal TruOriginCode getProductTruOriginCode(int productNum)
		{
			return (TruOriginCode)GetDataGrid().Rows[productNum].Cells[(int)column.typeTRN].Value;
		}

		internal bool setProductTruOriginCode(int productNum, TruOriginCode code)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.typeTRN].Value = code;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductTurnoverSize(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.turnoverSize].Value;
		}

		internal bool setProductTurnoverSize(int productNum, float turnoverSize)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.turnoverSize].Value = turnoverSize;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductUnitCode(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.TNVED].Value.ToString();
		}

		internal bool setProductUnitCode(int productNum, string tnved)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.TNVED].Value = tnved;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal string getProductUnitNominclature(int productNum)
		{
			return GetDataGrid().Rows[productNum].Cells[(int)column.measure].Value.ToString();
		}

		internal bool setProductUnitNominclature(int productNum, string measure)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.measure].Value = measure;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getProductUnitPrice(int productNum)
		{
			return (float)GetDataGrid().Rows[productNum].Cells[(int)column.pricePerOne].Value;
		}

		internal bool setProductUnitPrice(int productNum, float unitPrice)
		{
			try
			{
				GetDataGrid().Rows[productNum].Cells[(int)column.pricePerOne].Value =unitPrice;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
