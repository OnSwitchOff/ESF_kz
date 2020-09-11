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
	public partial class panelESFpartJ : AbstractUCESFpanel
	{
		public panelESFpartJ()
		{
			InitializeComponent();
		}



		private void tbPartJ_customerAgentTin_TextChanged(object sender, EventArgs e)
		{
			tbPartJ_customerAgentTin_Validating();
		}

		private void tbPartJ_customerAgentTin_Validating()
		{
			ESF_form esfform = (ESF_form)this.TopLevelControl;
			panelESFpartC partC = esfform.getPannel<panelESFpartC>();
			panelESFpartCtab panelCtab = partC.getTab();

			Regex regex = new Regex(@"^.{12}$");
			bool flag = regex.IsMatch(tbPartJ_customerAgentTin.Text);
			if(!flag)
			{
				epPartJ_customerAgentTin.SetError(tbPartJ_customerAgentTin, "Neverniy format");
				panelCtab.chbxPartC_isPrincipal_setState(false);
			}
			else
			{
				epPartJ_customerAgentTin.Clear();
				panelCtab.chbxPartC_isPrincipal_setState(true);
			}
		}
	}
}
