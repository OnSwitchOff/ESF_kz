using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ESF_kz.Forms
{
	public partial class panelESFpartE : AbstractUCESFpanel
	{
		public panelESFpartE()
		{
			InitializeComponent();
		}

		private void rbPartE_hasContractTrue_CheckedChanged(object sender, EventArgs e)
		{
			rbPartE_hasContractFalse.Checked = !rbPartE_hasContractTrue.Checked;
			tbPartE_contractNum.Enabled = rbPartE_hasContractTrue.Checked;
			tbPartE_contractDate.Enabled = rbPartE_hasContractTrue.Checked;
		}

		private void rbPartE_hasContractFalse_CheckedChanged(object sender, EventArgs e)
		{
			rbPartE_hasContractTrue.Checked = !rbPartE_hasContractFalse.Checked;
		}

		private void tbPartE_contractNum_TextChanged(object sender, EventArgs e)
		{
			tbPartE_contractNum_Validation();
		}

		private void tbPartE_contractNum_Validation()
		{
			Regex regex = new Regex(@"^.{0,18}$");
			bool flag = regex.IsMatch(tbPartE_contractNum.Text);
			if (!flag)
			{
				epPartE_contractNum.SetError(tbPartE_contractNum, "Wrong format");
			}
			else
			{
				epPartE_contractNum.Clear();
			}
		}

		private void tbPartE_term_TextChanged(object sender, EventArgs e)
		{
			tbPartE_term_Validation();
		}

		private void tbPartE_term_Validation()
		{
			Regex regex = new Regex(@"^.{0,98}$");
			bool flag = regex.IsMatch(tbPartE_term.Text);
			if (!flag)
			{
				epPartE_term.SetError(tbPartE_term, "Wrong format");
			}
			else
			{
				epPartE_term.Clear();
			}
		}

		private void tbPartE_transportTypeCode_TextChanged(object sender, EventArgs e)
		{

		}

		private void tbPartE_warrant_TextChanged(object sender, EventArgs e)
		{
			tbPartE_warrant_Validation();
		}

		private void tbPartE_warrant_Validation()
		{
			Regex regex = new Regex(@".{0,18}");
		}

		private void tbPartE_deliveryConditionCode_TextChanged(object sender, EventArgs e)
		{
			tbPartE_deliveryConditionCode_Validation();
		}

		private void tbPartE_deliveryConditionCode_Validation()
		{
			Regex regex = new Regex(@"^.{0,3}$");
			bool flag = regex.IsMatch(tbPartE_deliveryConditionCode.Text);
			if (!flag)
			{
				epPartE_deliveryConditionCode.SetError(tbPartE_deliveryConditionCode, "Wrong format");
			}
			else
			{
				epPartE_deliveryConditionCode.Clear();
			}
		}

		private void tbPartE_destination_TextChanged(object sender, EventArgs e)
		{
			tbPartE_destination_Validation();
		}

		private void tbPartE_destination_Validation()
		{
			Regex regex = new Regex(@"^.{0,98}$");
			bool flag = regex.IsMatch(tbPartE_destination.Text);
			if (!flag)
			{
				epPartE_destination.SetError(tbPartE_destination, "Wrong format");
			}
			else
			{
				epPartE_destination.Clear();
			}
		}
	}
}
