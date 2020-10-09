using ESF_kz.InvoiceService;
using ESF_kz.SessionService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ESF_kz.Forms
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			new LogInForm().ShowDialog();
			InitializeComponent();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			SessionServiceOperationsFacade.StartSession();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			QueryInvoiceUpdateResponse queryInvoiceUpdateResponse = new QueryInvoiceUpdateResponse();
			InvoiceServiceOperationsFacade.QueryUpdates(out queryInvoiceUpdateResponse);
			ClearDataGrid();
			if (queryInvoiceUpdateResponse != null)
			{
				foreach (InvoiceInfo invoiceInfo in queryInvoiceUpdateResponse.invoiceInfoList)
				{
					FormManagerFacade.AddRowByInvoiceInfo(this, invoiceInfo);
				}
				SortDataGridBy("Date");
			}					
		}

		private void SortDataGridBy(string columnName)
		{
			this.dataGridView1.Sort(this.dataGridView1.Columns[columnName], ListSortDirection.Descending);
		}

		private void ClearDataGrid()
		{
			this.dataGridView1.Rows.Clear();
		}

		internal DataGridView getDataGrid()
		{
			return this.dataGridView1;
		}

		internal void AddRowByInvoiceInfo(InvoiceInfo invoiceInfo)
		{
			DataGridView grid = getDataGrid();
			int count = grid.Rows.Count;
			grid.Rows.Add();
			grid.Rows[count].Cells[0].Value = count+1;
			grid.Rows[count].Cells[2].Value = invoiceInfo.invoiceId;
			grid.Rows[count].Cells[3].Value = invoiceInfo.inputDate;
			grid.Rows[count].Cells[4].Value = invoiceInfo.invoiceStatus;
			grid.Rows[count].Cells[6].Value = invoiceInfo.cancelReason;
		}

		private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			/*string invoiceId = getDataGrid().Rows[e.RowIndex].Cells[2].Value.ToString();
			MessageBox.Show(invoiceId);
			SessionDataManagerFacade.setInvoiceId(long.Parse(invoiceId));
			QueryInvoiceResponse queryInvoiceResponse = new QueryInvoiceResponse();
			InvoiceServiceOperationsFacade.QueryInvoiceById(out queryInvoiceResponse);

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(queryInvoiceResponse.invoiceInfoList[0].invoiceBody);
			XmlNode newNode = doc.DocumentElement;			*/
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			UserInfoForm userInfoForm = new UserInfoForm();
			userInfoForm.Show();
			SessionServiceOperationsFacade.getCurrentUser();
			SessionServiceOperationsFacade.getCurrentUserProfile();
			User user = SessionDataManagerFacade.getCurrentUserData();
			profileInfo[] profileInfos = SessionDataManagerFacade.getCurrentUserProfilesData();
			FormManagerFacade.FillUserInfoForm(user);
			FormManagerFacade.FillProfileInfoForm(profileInfos);
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			MessageBox.Show(SessionServiceOperationsFacade.CurrentSessionStatus().ToString());
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
			if (SessionServiceOperationsFacade.CloseSessionByCredentials())
				MessageBox.Show("Closed");
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				string invoiceId = getDataGrid().Rows[e.RowIndex].Cells[2].Value.ToString();
				MessageBox.Show(invoiceId);
				SessionDataManagerFacade.setInvoiceId(long.Parse(invoiceId));
				QueryInvoiceResponse queryInvoiceResponse = new QueryInvoiceResponse();
				InvoiceServiceOperationsFacade.QueryInvoiceById(out queryInvoiceResponse);

				XmlDocument doc = new XmlDocument();
				doc.LoadXml(queryInvoiceResponse.invoiceInfoList[0].invoiceBody);
				XmlNode newNode = doc.DocumentElement;
				InvoiceV2 invoice = ParsingManager.ParseInvoiceBody(newNode);
				ESF_form invoiceForm = FormManagerFacade.FillInvoiceFormByInvoice(invoice);
				invoiceForm.Show();
			}			
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
			ESF_form invoiceForm = new ESF_form();
			FormManagerFacade.setInvoiceDate(DateTime.Now);
			invoiceForm.Show();
		}
	}
}
