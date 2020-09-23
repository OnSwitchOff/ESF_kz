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
	public partial class panelESFpartHtab : AbstractUCESFpanelTab
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


		public panelESFpartHtab()
		{
			InitializeComponent();
		}

		internal DataGridView GetDataGrid()
		{
			return dataGridView1;
		}

		internal string getCustomerProductShareAdditional(int productShareNumber)
		{
			return dataGridView1.Rows[productShareNumber].Cells[(int)column.additional].Value.ToString();
		}

		internal bool setCustomerProductShareAdditional(int productShareNumber, string additional)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.additional].Value = additional;
				return true;
			}
			catch (Exception)
			{
				return false;
			}			
		}

		internal float getCustomerProductShareExciseAmount(int productShareNumber)
		{
			return (float)dataGridView1.Rows[productShareNumber].Cells[(int)column.exciseAmount].Value;
		}

		internal bool setCustomerProductShareExciseAmount(int productShareNumber, float exciseAmount)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.exciseAmount].Value = exciseAmount;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		
		}

		internal float getCustomerProductShareNDSAmount(int productShareNumber)
		{
			return (float)dataGridView1.Rows[productShareNumber].Cells[(int)column.ndsAmount].Value;
		}

		internal bool setCustomerProductShareNDSAmount(int productShareNumber, float ndsAmount)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.ndsAmount].Value = ndsAmount;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getCustomerProductSharePriceWithoutTax(int productShareNumber)
		{
			return (float)dataGridView1.Rows[productShareNumber].Cells[(int)column.priceWithoutTax].Value;
		}

		internal bool setCustomerProductSharePriceWithoutTax(int productShareNumber, float priceWithoutTax)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.priceWithoutTax].Value = priceWithoutTax;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getCustomerProductSharePriceWithTax(int productShareNumber)
		{
			return (float)dataGridView1.Rows[productShareNumber].Cells[(int)column.priceWithTax].Value;
		}

		internal bool setCustomerProductSharePriceWithTax(int productShareNumber, float priceWithTax)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.priceWithTax].Value = priceWithTax;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal int getProductShareProductNumber(int productShareNumber)
		{
			return (int)dataGridView1.Rows[productShareNumber].Cells[(int)column.rowNumber].Value;
		}

		internal bool setProductShareProductNumber(int productShareNumber, int productNumber)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.rowNumber].Value = productNumber;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getCustomerProductShareQuantity(int productShareNumber)
		{
			return (float)dataGridView1.Rows[productShareNumber].Cells[(int)column.quantity].Value;
		}

		internal bool setCustomerProductShareQuantity(int productShareNumber, float qtty)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.quantity].Value = qtty;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		internal float getCustomerProductShareTurnoverSize(int productShareNumber)
		{
			return (float)dataGridView1.Rows[productShareNumber].Cells[(int)column.turnoverSize].Value;
		}

		internal bool setCustomerProductShareTurnoverSize(int productShareNumber, float turnoverSize)
		{
			try
			{
				dataGridView1.Rows[productShareNumber].Cells[(int)column.turnoverSize].Value = turnoverSize;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
