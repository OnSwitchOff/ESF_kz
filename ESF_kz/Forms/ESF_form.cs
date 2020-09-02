using ESF_kz.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
	}
}
