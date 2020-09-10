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
	public partial class panelESFpartCtab : AbstractUCESFpanelTab
	{
		public panelESFpartCtab()
		{
			InitializeComponent();
		}

		private void numUpDown_participantCounter_ValueChanged(object sender, EventArgs e)
		{
			
		}

		public bool isPublicOffice()
		{
			return this.chbxPartC_isPublicOffice.Checked;
		}

		private void tbPartC_tin_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^\d{1-50}$");
			bool isNonResident = chbxPartC_isNonResident.Checked;
			bool isRetail = chbxPartC_isRetail.Checked;
			bool flag = regex.IsMatch(tbPartC_tin.Text);
			bool isEmpty = tbPartC_tin.Text == "";
			string message = "";
			if ((!isNonResident && !isRetail) || !flag || isEmpty)
			{
				message = "ИИН/БИН поставщика отсутствует или неверного формата";
				epPartC_tin.SetError(tbPartC_tin, message);
				return;
			}
			else
			{
				epPartC_tin.Clear();
			}
		}
	}
}
