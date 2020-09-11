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
	public partial class panelESFpartI : AbstractUCESFpanel
	{
		public panelESFpartI()
		{
			InitializeComponent();
		}

		private void tbPartI_sellerAgentName_TextChanged(object sender, EventArgs e)
		{
			tbPartI_sellerAgentName_Validation();
		}

		private void tbPartI_sellerAgentName_Validation()
		{
			Regex regex = new Regex(@"^.{3,500}$");
			bool flag = regex.IsMatch(tbPartI_sellerAgentName.Text);
			if (!flag)
			{
				epPartI_sellerAgentName.SetError(tbPartI_sellerAgentName, "Wrong format");
			}
			else
			{
				epPartI_sellerAgentName.Clear();
			}
		}

		private void tbPartI_sellerAgentAddress_TextChanged(object sender, EventArgs e)
		{
			tbPartI_sellerAgentAddress_Validation();
		}

		private void tbPartI_sellerAgentAddress_Validation()
		{
			Regex regex = new Regex(@"^.{3,98}$");
			bool flag = regex.IsMatch(tbPartI_sellerAgentAddress.Text);
			if (!flag)
			{
				epPartI_sellerAgentAddress.SetError(tbPartI_sellerAgentAddress, "Wrong format");
			}
			else
			{
				epPartI_sellerAgentAddress.Clear();
			}
		}

		private void tbPartI_sellerAgentDocNum_TextChanged(object sender, EventArgs e)
		{
			tbPartI_sellerAgentDocNum_Validation();
		}

		private void tbPartI_sellerAgentDocNum_Validation()
		{
			Regex regex = new Regex(@"^.{0,18}$");
			bool flag = regex.IsMatch(tbPartI_sellerAgentDocNum.Text);
			if (!flag)
			{
				epPartI_sellerAgentDocNum.SetError(tbPartI_sellerAgentDocNum, "Wrong format");
			}
			else
			{
				epPartI_sellerAgentDocNum.Clear();
			}
		}
	}
}
