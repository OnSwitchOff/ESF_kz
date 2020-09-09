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
	public partial class panelESFpartB :  AbstractUCESFpanel
	{
		public panelESFpartB()
		{
			InitializeComponent();
			CreateFirstTab("Seller");			
		}

		public panelESFpartBtab CreateTab(string title)
		{
			panelESFpartBtab PanelESFPartBtab = new panelESFpartBtab();
			PanelESFPartBtab.setESFform(this.getESFform());
			PanelESFPartBtab.Dock = DockStyle.Fill;
			this.tabControl1.TabPages.Add(title);
			this.tabControl1.TabPages[tabControl1.TabCount-1].Controls.Add(PanelESFPartBtab);
			return PanelESFPartBtab;
		}

		public panelESFpartBtab CreateFirstTab(string title)
		{
			panelESFpartBtab PanelESFPartBtab = new panelESFpartBtab();
			PanelESFPartBtab.setESFform(this.getESFform());
			PanelESFPartBtab.Dock = DockStyle.Fill;
			this.tabControl1.TabPages.Add(title);
			this.tabControl1.TabPages[0].Controls.Add(PanelESFPartBtab);
			return PanelESFPartBtab;
		}

		public void RemoveLastTab()
		{

		}



		public TabControl getTabControll()
		{
			return this.tabControl1;
		}


	}
}
