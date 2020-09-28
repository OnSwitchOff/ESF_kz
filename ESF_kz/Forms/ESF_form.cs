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
using System.Xml;

namespace ESF_kz
{
	public partial class ESF_form : Form
	{

		private void setESFformField(AbstractUCESFpanel esf_panel)
		{
			esf_panel.setESFform(this);
		}

		public ESF_form()
		{
			InitializeComponent();
			setESFformFieldForPanels();
			FormManagerFacade.setInvoiceForm(this);
		}

		private void setESFformFieldForPanels()
		{
			foreach (AbstractUCESFpanel item in this.splitContainer1.Panel2.Controls)
			{
				item.setESFform(this);
				
			}
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
			panelESFpartHtab PannelESFPartHtab1 = new panelESFpartHtab();
			panelESFpartHtab PannelESFPartHtab2 = new panelESFpartHtab();
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


		public T getPannel<T>()
		{
			T result = default(T);
			foreach (var item in this.splitContainer1.Panel2.Controls)
			{
				Type first = item.GetType();
				Type second = typeof(T);
				if (first.Name == second.Name)
					result = (T)item;
			}
			return result;
		}

		internal void SetEnableBtnESFpartI(bool state)
		{
			btnESFpartI.Enabled = state;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;
			// получаем выбранный файл
			string filename = openFileDialog1.FileName;
			// читаем файл в строку
			//string fileText = System.IO.File.ReadAllText(filename);
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(filename);
			invoiceContainerV2 ic = SessionDataManagerFacade.ParseInvoiceXML(xDoc);
			FormManagerFacade.fillInvoiceForm(ic);

			MessageBox.Show("Файл открыт");
		}
	}
}
