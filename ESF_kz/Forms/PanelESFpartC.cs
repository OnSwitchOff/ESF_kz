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
	public partial class panelESFpartC : AbstractUCESFpanel
	{
		public panelESFpartC()
		{
			InitializeComponent();
		}
		public TabControl getTabControll()
		{
			return this.tabControl1;
		}
		public panelESFpartCtab getTab()
		{
			return (panelESFpartCtab)(this.tabControl1.TabPages[0].Controls[0]);
		}
	}
}
