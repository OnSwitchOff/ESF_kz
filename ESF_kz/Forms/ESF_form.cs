using ESF_kz.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESF_kz
{
	public partial class ESF_form : Form
	{
		public ESF_form()
		{
			InitializeComponent();
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}

		private void btnESFpartA_Click(object sender, EventArgs e)
		{
			this.PanelESFpartA.BringToFront();			
		}

		private void btnESFpartB_Click(object sender, EventArgs e)
		{			
			this.PanelESFpartB.BringToFront();
		}

		private void btnESFpartC_Click(object sender, EventArgs e)
		{
			panelESFpartCtab PannelESFPartCtab1 = new panelESFpartCtab();
			panelESFpartCtab PannelESFPartCtab2 = new panelESFpartCtab();
			PannelESFPartCtab1.Dock = DockStyle.Fill;
			PannelESFPartCtab2.Dock = DockStyle.Fill;
			if (this.PanelESFpartC.getTabControll().TabPages.Count < 2)
			{
				this.PanelESFpartC.getTabControll().TabPages.Add("taB 1");
				this.PanelESFpartC.getTabControll().TabPages.Add("taB 2");
			}
			this.PanelESFpartC.getTabControll().TabPages[0].Controls.Add(PannelESFPartCtab1);
			this.PanelESFpartC.getTabControll().TabPages[1].Controls.Add(PannelESFPartCtab2);
			this.PanelESFpartC.BringToFront();
		}

		private void btnESFpartD_Click(object sender, EventArgs e)
		{
			this.PanelESFpartD.BringToFront();
		}

		private void btnESFpartE_Click(object sender, EventArgs e)
		{
			this.PanelESFpartE.BringToFront();
		}

		private void btnESFpartF_Click(object sender, EventArgs e)
		{
			this.PanelESFpartF.BringToFront();
		}

		private void btnESFpartG_Click(object sender, EventArgs e)
		{
			this.PanelESFpartG.BringToFront();
		}

		private void btnESFpartH_Click(object sender, EventArgs e)
		{
			panelESFPartHtab PannelESFPartHtab1 = new panelESFPartHtab();
			panelESFPartHtab PannelESFPartHtab2 = new panelESFPartHtab();
			PannelESFPartHtab1.Dock = DockStyle.Fill;
			PannelESFPartHtab2.Dock = DockStyle.Fill;
			if (this.PanelESFpartH.getTabControll().TabPages.Count < 2)
			{
				this.PanelESFpartH.getTabControll().TabPages.Add("taB 1");
				this.PanelESFpartH.getTabControll().TabPages.Add("taB 2");
			}				
			this.PanelESFpartH.getTabControll().TabPages[0].Controls.Add(PannelESFPartHtab1);
			this.PanelESFpartH.getTabControll().TabPages[1].Controls.Add(PannelESFPartHtab2);
			this.PanelESFpartH.BringToFront();
		}

		private void btnESFpartI_Click(object sender, EventArgs e)
		{
			this.PanelESFpartI.BringToFront();
		}

		private void btnESFpartJ_Click(object sender, EventArgs e)
		{
			this.PanelESFpartJ.BringToFront();
		}

		private void btnESFpartK_Click(object sender, EventArgs e)
		{
			this.PanelESFpartK.BringToFront();
		}

		private void btnESFpartL_Click(object sender, EventArgs e)
		{
			this.PanelESFpartL.BringToFront();
		}

	}
}
