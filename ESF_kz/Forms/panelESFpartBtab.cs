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

			Regex regex = new Regex(@"\d{12}");
			bool flag = regex.IsMatch(tbPartB_tin.Text);
			if (!flag)
			{
				epPartB_tin.SetError(tbPartB_tin, "Номер учетной системы отсутствует");
			}
			else
			{
				epPartB_tin.Clear();
			}
		}
	}
}
