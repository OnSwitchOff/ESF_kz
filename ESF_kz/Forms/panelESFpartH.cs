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
	public partial class panelESFpartH : AbstractUCESFpanel
	{
		public panelESFpartH()
		{
			InitializeComponent();
		}

		public panelESFpartHtab CreateTab(string title)
		{
			panelESFpartHtab PanelESFPartHtab = new panelESFpartHtab();
			PanelESFPartHtab.setESFform(this.getESFform());
			PanelESFPartHtab.Dock = DockStyle.Fill;
			this.tabControl1.TabPages.Add(title);
			this.tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(PanelESFPartHtab);
			return PanelESFPartHtab;
		}

		public panelESFpartHtab CreateFirstTab(string title)
		{
			panelESFpartHtab PanelESFPartHtab = new panelESFpartHtab();
			PanelESFPartHtab.setESFform(this.getESFform());
			PanelESFPartHtab.Dock = DockStyle.Fill;
			this.tabControl1.TabPages.Add(title);
			this.tabControl1.TabPages[0].Controls.Add(PanelESFPartHtab);
			return PanelESFPartHtab;
		}

		public TabControl getTabControll()
		{
			return this.tabControl1;
		}

		public panelESFpartHtab getTab()
		{
			return (panelESFpartHtab)(this.tabControl1.TabPages[0].Controls[0]);
		}

		public panelESFpartHtab getTab(int num)
		{
			return (panelESFpartHtab)(this.tabControl1.TabPages[num - 1].Controls[0]);
		}
	}
}
