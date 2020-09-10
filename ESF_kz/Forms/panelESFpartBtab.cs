using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ESF_kz.Forms
{
	public partial class panelESFpartBtab : AbstractUCESFpanelTab
	{
		private Dictionary<TextBox, bool> tbPartB1_isCorrect = new Dictionary<TextBox,bool>();

		public panelESFpartBtab()
		{
			InitializeComponent();

			tbPartB1_isCorrect.Add(tbPartB1_kbe, false);
			tbPartB1_isCorrect.Add(tbPartB1_iik, false);
			tbPartB1_isCorrect.Add(tbPartB1_bik, false);
			tbPartB1_isCorrect.Add(tbPartB1_bank, false);

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
			chbxPartB_isJointActivityParticipant.Enabled = false;
			Regex regex = new Regex(@"^\d{12}$");
			bool flag = regex.IsMatch(tbPartB_tin.Text);
			bool isEmpty = tbPartB_tin.Text == "";
			string message = "";
			if (!flag || isEmpty)
			{
				message = "ИИН/БИН поставщика отсутствует или неверного формата";
				epPartB_tin.SetError(tbPartB_tin, message);
				return;
			}
			else if (!checkAvailabilityIn(tbPartB_tin.Text))
			{
				message = "ИИН/БИН поставщика не найден в БД ИС ЭСФ";
				epPartB_tin.SetError(tbPartB_tin, message);
				return;
			}
			else if (checkForBlocking(tbPartB_tin.Text))
			{
				message = "Выписка ЭСФ заблокирована";
				epPartB_tin.SetError(tbPartB_tin, message);
				return;
			}
			else
			{
				chbxPartB_isJointActivityParticipant.Enabled = true;
				epPartB_tin.Clear();
			}
		}


		/*Проверка наличия признака блокировки работы в ИС ЭСФ. Механизм описан в СТПО шифр 398.13024001364901.00.01.03-01.2017.*/
		private bool checkForBlocking(string bin)
		{
			return false;
		}

		private void tbPartB_reorganizedTin_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^\d{12}$");
			bool flag = regex.IsMatch(tbPartB_reorganizedTin.Text);
			bool isEmpty = tbPartB_reorganizedTin.Text == "";
			string message = "";
			if (!flag || isEmpty)
			{
				message = "БИН реорганизованного лица отсутствует или неверного формата";
				epPartB_reorganizedTin.SetError(tbPartB_reorganizedTin, message);
				return;
			}
			else if (!checkAvailabilityIn(tbPartB_reorganizedTin.Text))
			{
				message = "БИН реорганизованного лица поставщика не найден в БД ИС ЭСФ";
				epPartB_reorganizedTin.SetError(tbPartB_reorganizedTin, message);
				return;
			}
			else
			{
				epPartB_reorganizedTin.Clear();
			}
		}

		/* проверка наличия БИН в БД ИС ЭСФ
		 * Механизм реорганизации описан в СТПО шифр 398.13024001364901.00.02.01-01.2017.*/
		private bool checkAvailabilityIn(string bin)
		{
			return true;
		}

		private void tbPartB_name_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^.{3,450}$");
			bool flag = regex.IsMatch(tbPartB_name.Text);
			bool isEmpty = tbPartB_name.Text == "";
			if (isEmpty)
			{
				epPartB_name.SetError(tbPartB_name, "Наименование поставщика отсутствует");
			}
			if (!flag)
			{
				epPartB_name.SetError(tbPartB_name, "Наименование поставщика неверного формата");
			}
			else
			{
				epPartB_name.Clear();
			}
		}

		private void tbPartB_shareParticipation_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^[0][.]\d{0,5}[1-9]$");
			bool flag = regex.IsMatch(tbPartB_shareParticipation.Text);
			if (!flag)
			{
				epPartB_shareParticipation.SetError(tbPartB_shareParticipation, "Укажите долю участия в формате десятичной дроби < 1");
			}
			else
			{
				epPartB_shareParticipation.Clear();
			}
		}

		private void tbPartB_address_TextChanged(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^(.{3,450})?$");
			bool flag = regex.IsMatch(tbPartB_address.Text);
			if (!flag)
			{
				epPartB_address.SetError(tbPartB_address, "Неверный формат адреса");
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
				epPartB_certificateSeries.SetError(tbPartB_certificateSeries, "Серия должна состоять из 5 цифр");
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
				epPartB_certificateNum.SetError(tbPartB_certificateNum, "Номер должен состоять из 7 цифр");
			}
			else
			{
				epPartB_certificateNum.Clear();
			}
		}

		/*Проверка указанной серии и номера свидетельства НДС в данных БД ИС ЭСФ.*/
		private bool isNDSPayer(string series,string number)
		{
			return true;
		}

		private void tbPartB1_kbe_TextChanged(object sender, EventArgs e)
		{
			tbPartB1_isCorrect[tbPartB1_kbe] = false;
			tbPartB1_validation();
		}

		private void tbPartB1_validation()
		{
			bool isEmpty_kbe = tbPartB1_kbe.Text == "";
			bool isEmpty_iik = tbPartB1_iik.Text == "";
			bool isEmpty_bik = tbPartB1_bik.Text == "";
			bool isEmpty_bank = tbPartB1_bank.Text == "";
			bool isEmptyTemp = true;
			bool isSomeNotEmpty = !isEmpty_iik || !isEmpty_bik || !isEmpty_bank || !isEmpty_kbe;
			Regex regex=null;
			ErrorProvider tempEP = null;
			string message = "";

			Dictionary<TextBox, bool> temp = new Dictionary<TextBox, bool>();
			foreach (KeyValuePair<TextBox, bool> item in tbPartB1_isCorrect)
			{
				temp.Add(item.Key,item.Value);
			}
			foreach (KeyValuePair<TextBox,bool> item in temp)
			{
				if (item.Value)
				{
					continue;
				}
				switch (item.Key.Name)
				{
					case "tbPartB1_kbe":
						regex = new Regex(@"^\d{0,2}$");
						tempEP = epPartB1_kbe;
						isEmptyTemp = tbPartB1_kbe.Text == "";
						message = "Neverniy format ili otsutstvuet";
						break;
					case "tbPartB1_iik":
						regex = new Regex(@"^.{20}$");
						tempEP = epPartB1_iik;
						isEmptyTemp = tbPartB1_iik.Text == "";
						message = "Neverniy format ili otsutstvuet";
						break;
					case "tbPartB1_bik":
						regex = new Regex(@"^.{0,8}$");
						tempEP = epPartB1_bik;
						isEmptyTemp = tbPartB1_bik.Text == "";
						message = "Neverniy format ili otsutstvuet";
						break;
					case "tbPartB1_bank":
						regex = new Regex(@"^.{1,200}$");
						tempEP = epPartB1_bank;
						isEmptyTemp = tbPartB1_bank.Text == "";
						message = "Neverniy format ili otsutstvuet";
						break;
					default:
						break;
				}
				if (regex!=null && tempEP!=null)
				{
					ESF_form esfform = (ESF_form)this.TopLevelControl;
					panelESFpartC partC = esfform.getPannel<panelESFpartC>();
					panelESFpartCtab partCtab = partC.getTab();
					if (partCtab.isPublicOffice() || isSomeNotEmpty)
					{
						bool flag = regex.IsMatch(item.Key.Text);
						if (!flag || isEmptyTemp)
						{
							tempEP.SetError(item.Key, message);
							tbPartB1_isCorrect[item.Key] = false;
						}
						else
						{
							tempEP.Clear();
							tbPartB1_isCorrect[item.Key] = true;
						}
					}						
				}				
			}
		}

		private void tbPartB1_iik_TextChanged(object sender, EventArgs e)
		{
			tbPartB1_isCorrect[tbPartB1_iik] = false;
			tbPartB1_validation();
		}

		private void tbPartB1_bik_TextChanged(object sender, EventArgs e)
		{

			tbPartB1_isCorrect[tbPartB1_bik] = false;
			tbPartB1_validation();
		}

		private void tbPartB1_bank_TextChanged(object sender, EventArgs e)
		{
			tbPartB1_isCorrect[tbPartB1_bank] = false;
			tbPartB1_validation();
		}

		private void chbxPartB_isSharingAgreementParticipant_CheckedChanged(object sender, EventArgs e)
		{
			TabControl tabControl = (TabControl)this.Parent.Parent;
			if (chbxPartB_isSharingAgreementParticipant.Checked)
			{
				tabControl.TabPages[0].Text = "Participant #1";
				tbPartB_shareParticipation.Enabled = true;
				numUpDown_participantCounter.Enabled = true;

			}
			else
			{
				tabControl.TabPages[0].Text = "Seller";
				tbPartB_shareParticipation.Enabled = false;
				tbPartB_shareParticipation.Text = "";
				numUpDown_participantCounter.Value = 1;
				numUpDown_participantCounter.Enabled = false;
			}
		}

		private void chbxPartB_isCommitent_CheckedChanged(object sender, EventArgs e)
		{
			if(chbxPartB_isCommitent.Checked)
			{
				chbxPartB_isBroker.Checked = false;
			}
		}

		private void chbxPartB_isBroker_CheckedChanged(object sender, EventArgs e)
		{
			if(chbxPartB_isBroker.Checked)
			{
				chbxPartB_isCommitent.Checked = false;
			}
		}

		private void chbxPartB_isJointActivityParticipant_CheckedChanged(object sender, EventArgs e)
		{
			TabControl tabControl = (TabControl)this.Parent.Parent;
			if (chbxPartB_isJointActivityParticipant.Checked)
			{
				if(!isJointActivityParticipant(tbPartB_tin.Text))
				{
					chbxPartB_isJointActivityParticipant.Checked = false;
				}
				else
				{					
					tabControl.TabPages[0].Text = "Participant #1";
					numUpDown_participantCounter.Enabled = true;	
				}
			}
			else
			{
				tabControl.TabPages[0].Text = "Seller";
				numUpDown_participantCounter.Value = 1;
				numUpDown_participantCounter.Enabled = false;
			}
		}

		private bool isJointActivityParticipant(string bin)
		{
			return true;
		}

		private void chbxPartB_isPrincipal_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void numUpDown_participantCounter_ValueChanged(object sender, EventArgs e)
		{
			panelESFpartB PanelESFpartB = (panelESFpartB)this.Parent.Parent.Parent;
			TabControl tabControl = PanelESFpartB.getTabControll(); 
			if(tabControl.TabCount < numUpDown_participantCounter.Value)
			{
				int dif = (int)numUpDown_participantCounter.Value - tabControl.TabCount;
				for (int i = 0; i < dif; i++)
				{
					panelESFpartBtab PanelESFPartBtab = PanelESFpartB.CreateTab("Participant #" + (tabControl.TabCount + 1));
					PanelESFPartBtab.numUpDown_participantCounter.Visible = false;
					PanelESFPartBtab.chbxPartB_isSharingAgreementParticipant.Enabled = false;
					PanelESFPartBtab.chbxPartB_isSharingAgreementParticipant.Checked = chbxPartB_isSharingAgreementParticipant.Checked;
					PanelESFPartBtab.chbxPartB_isJointActivityParticipant.Checked = chbxPartB_isJointActivityParticipant.Checked;
					PanelESFPartBtab.chbxPartB_isJointActivityParticipant.Enabled = false;
					PanelESFPartBtab.l_participantCounter.Visible = false;
				}				
			}
			else
			{
				int dif = tabControl.TabCount - (int)numUpDown_participantCounter.Value;
				for (int i = 0; i < dif; i++)
				{
					tabControl.TabPages.Remove(tabControl.TabPages[tabControl.TabCount - 1]);
				}
				if(numUpDown_participantCounter.Value == 1)
				{
					chbxPartB_isSharingAgreementParticipant.Checked = false;
					chbxPartB_isJointActivityParticipant.Checked = false;
				}
			}
		}
	}
}
