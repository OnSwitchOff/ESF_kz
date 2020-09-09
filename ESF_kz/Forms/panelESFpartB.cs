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
	public partial class panelESFpartB : UserControl
	{
		public panelESFpartB()
		{
			InitializeComponent();
			panelESFpartBtab PanelESFPartBtab = new panelESFpartBtab();
			PanelESFPartBtab.Dock = DockStyle.Fill;
			this.tabControl1.TabPages.Add("Seller");
			this.tabControl1.TabPages[0].Controls.Add(PanelESFPartBtab);
		}

		public TabControl getTabControll()
		{
			return this.tabControl1;
		}
	}
}
