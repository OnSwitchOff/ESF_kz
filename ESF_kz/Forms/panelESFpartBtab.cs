using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ESF_kz.Forms
{
	public partial class panelESFpartBtab : UserControl
	{
		public panelESFpartBtab()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void textBox10_TextChanged(object sender, EventArgs e)
		{

		}

		private void tbPartB_tin_TextChanged(object sender, EventArgs e)
		{

			Regex regex = new Regex(@"^\d{12}$");
			bool flag = regex.IsMatch(tbPartB_tin.Text);
			bool isEmpty = tbPartB_tin.Text == "";
			if (!flag  && !isEmpty)
			{
				epPartB_tin.SetError(tbPartB_tin, "Номер");
			}
			else
			{
				epPartB_tin.Clear();
			}
		}

		private void tbPartB_reorganizedTin_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^\d{12}$");
			bool flag = regex.IsMatch(tbPartB_reorganizedTin.Text);
			bool isEmpty = tbPartB_reorganizedTin.Text == "";
			if (!flag && !isEmpty)
			{
				epPartB_reorganizedTin.SetError(tbPartB_reorganizedTin, "Номер");
			}
			else
			{
				epPartB_reorganizedTin.Clear();
			}
		}

		private void tbPartB_name_TextChanged(object sender, EventArgs e)
		{

			Regex regex = new Regex(@"^{3,450}$");
			bool flag = regex.IsMatch(tbPartB_name.Text);
			if (!flag)
			{
				epPartB_name.SetError(tbPartB_name, "Номер");
			}
			else
			{
				epPartB_name.Clear();
			}
		}

		private void tbPartB_shareParticipation_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^[0][.]\d{0,6}$");
			bool flag = regex.IsMatch(tbPartB_shareParticipation.Text);
			if (!flag)
			{
				epPartB_shareParticipation.SetError(tbPartB_shareParticipation, "Номер");
			}
			else
			{
				epPartB_shareParticipation.Clear();
			}
		}

		private void tbPartB_address_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^{3,450}$");
			bool flag = regex.IsMatch(tbPartB_address.Text);
			if (!flag)
			{
				epPartB_address.SetError(tbPartB_address, "Номер");
			}
			else
			{
				epPartB_address.Clear();
			}
		}

		private void tbPartB_certificateSeries_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^\d{5}$");
			bool flag = regex.IsMatch(tbPartB_certificateSeries.Text);
			if (!flag)
			{
				epPartB_certificateSeries.SetError(tbPartB_certificateSeries, "Номер");
			}
			else
			{
				epPartB_certificateSeries.Clear();
			}
		}

		private void tbPartB_certificateNum_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^\d{7}$");
			bool flag = regex.IsMatch(tbPartB_certificateNum.Text);
			if (!flag)
			{
				epPartB_certificateNum.SetError(tbPartB_certificateNum, "Номер");
			}
			else
			{
				epPartB_certificateNum.Clear();
			}
		}

		private void tbPartB1_kbe_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^\d{0,2}$");
			bool flag = regex.IsMatch(tbPartB1_kbe.Text);
			if (!flag)
			{
				epPartB1_kbe.SetError(tbPartB1_kbe, "Номер");
			}
			else
			{
				epPartB1_kbe.Clear();
			}
		}

		private void tbPartB1_iik_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^{20}$");
			bool flag = regex.IsMatch(tbPartB1_iik.Text);
			if (!flag)
			{
				epPartB1_iik.SetError(tbPartB1_iik, "Номер");
			}
			else
			{
				epPartB1_iik.Clear();
			}
		}

		private void tbPartB1_bik_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^{0,8}$");
			bool flag = regex.IsMatch(tbPartB1_bik.Text);
			if (!flag)
			{
				epPartB1_bik.SetError(tbPartB1_bik, "Номер");
			}
			else
			{
				epPartB1_bik.Clear();
			}
		}

		private void tbPartB1_bank_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^{1,200}$");
			bool flag = regex.IsMatch(tbPartB1_bank.Text);
			if (!flag)
			{
				epPartB1_bank.SetError(tbPartB1_bank, "Номер");
			}
			else
			{
				epPartB1_bank.Clear();
			}
		}
	}
}
