using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ESF_kz.Forms
{
	public partial class panelESFpartCtab : AbstractUCESFpanelTab
	{
		private const string NATIONAL_BANK_BIN = "941240001151";
		public panelESFpartCtab()
		{
			InitializeComponent();
		}

		private void numUpDown_participantCounter_ValueChanged(object sender, EventArgs e)
		{

			panelESFpartC PanelESFpartC = (panelESFpartC)this.Parent.Parent.Parent;
			TabControl tabControl = PanelESFpartC.getTabControll();
			if (tabControl.TabCount < numUpDown_participantCounter.Value)
			{
				int dif = (int)numUpDown_participantCounter.Value - tabControl.TabCount;
				for (int i = 0; i < dif; i++)
				{
					panelESFpartCtab PanelESFPartCtab = PanelESFpartC.CreateTab("Customer-Participant #" + (tabControl.TabCount + 1));
					PanelESFPartCtab.numUpDown_participantCounter.Visible = false;
					PanelESFPartCtab.chbxPartC_isSharingAgreementParticipant.Enabled = false;
					PanelESFPartCtab.chbxPartC_isSharingAgreementParticipant.Checked = chbxPartC_isSharingAgreementParticipant.Checked;
					PanelESFPartCtab.chbxPartC_isJointActivityParticipant.Checked = chbxPartC_isJointActivityParticipant.Checked;
					PanelESFPartCtab.chbxPartC_isJointActivityParticipant.Enabled = false;
					PanelESFPartCtab.l_participantCounter.Visible = false;
				}
			}
			else
			{
				int dif = tabControl.TabCount - (int)numUpDown_participantCounter.Value;
				for (int i = 0; i < dif; i++)
				{
					tabControl.TabPages.Remove(tabControl.TabPages[tabControl.TabCount - 1]);
				}
				if (numUpDown_participantCounter.Value == 1)
				{
					chbxPartC_isSharingAgreementParticipant.Checked = false;
					chbxPartC_isJointActivityParticipant.Checked = false;
				}
			}
		}

		public bool isPublicOffice()
		{
			return this.chbxPartC_isPublicOffice.Checked;
		}

		private void tbPartC_tin_TextChanged(object sender, EventArgs e)
		{
			tbPartC_tin_Validation();
		}

		private void tbPartC_tin_Validation()
		{
			Regex regex = null;
			bool isNonResident = chbxPartC_isNonResident.Checked;
			bool isRetail = chbxPartC_isRetail.Checked;
			bool isEmpty = tbPartC_tin.Text == "";
			string message = "";
			chbxPartC_isSharingAgreementParticipant.Enabled = false;
			if (isNonResident)
			{
				regex = new Regex(@"^\d{0-50}$");
				message = "Неверный формат";
			}
			else if(isRetail)
			{
				regex = new Regex(@"^(\d{0})|(\d{12})$");
				message = "Неверный формат";
			}
			else
			{
				regex = new Regex(@"^\d{12}$");
				message = "Неверный формат";
			}

			bool flag = regex.IsMatch(tbPartC_tin.Text);
			if(!flag)
			{
				epPartC_tin.SetError(tbPartC_tin, message);
			}
			else
			{
				if(!isNonResident )
				{
					if (!checkForExistInDB(tbPartC_tin.Text))
					{
						message = "ИИН/БИН получателя отсутствует в БДИС ЭСФ";
						epPartC_tin.SetError(tbPartC_tin, message);
					}
					else if (checkForBlocking(tbPartC_tin.Text))
					{
						message = "«Получатель заблокирован».";
						epPartC_tin.SetError(tbPartC_tin, message);
					}
					else
					{
						epPartC_tin.Clear();
						chbxPartC_isSharingAgreementParticipant.Enabled = true;
					}
				}

			}

		}

		internal void chbxPartC_isPrincipal_setState(bool flag)
		{
			chbxPartC_isPrincipal.Checked = flag;
		}

		//проверка на наличие ИИН/БИН в БД
		private bool checkForExistInDB(string text)
		{
			return true;
		}

		/*Проверка наличия признака блокировки работы в ИС ЭСФ. Механизм описан в СТПО шифр 398.13024001364901.00.01.03-01.2017.*/
		private bool checkForBlocking(string bin)
		{
			return false;
		}

		private void tbPartC_reorganizedTin_TextChanged(object sender, EventArgs e)
		{
			tbPartC_reorganizedTin_Validation();
		}

		private void tbPartC_reorganizedTin_Validation()
		{
			Regex regex = new Regex(@"^\d{12}$");
			bool isEmpty = tbPartC_reorganizedTin.Text == "";
			bool flag = regex.IsMatch(tbPartC_reorganizedTin.Text);
			string message = "";
			if(!isEmpty)
			{
				if(!flag)
				{
					message = "Неверный формат";
					epPartC_reorganizedTin.SetError(tbPartC_reorganizedTin, message);
				}
				else
				{
					if(!checkForExistInDB(tbPartC_reorganizedTin.Text))
					{
						message = "БИН реорганизованного лица получателя отсутствует в БД ИС ЭСФ";
						epPartC_reorganizedTin.SetError(tbPartC_reorganizedTin, message);
					}
						/*if(!isExistLinkToMainInDB())
						{
							message = "БИН реорганизованного лица получателя отсутствует в БД ИС ЭСФ";
							epPartC_reorganizedTin.SetError(tbPartC_reorganizedTin, message);
						}*/
					else
					{
						epPartC_reorganizedTin.Clear();
					}
				}
			}
		}
		/*Проверка наличия в БД связи структурной единицы с головным предприятием по данным ЕХД.При отсутствии связи сообщение: 
		 * "Указанный БИН не является структурной единицей (филиалом) получателя, указанного в поле 16 "ИИН/БИН*/
		private bool isExistLinkToMainInDB()
		{
			return true;
		}

		private void tbPartC_name_TextChanged(object sender, EventArgs e)
		{
			tbPartC_name_Validation();
		}

		private void tbPartC_name_Validation()
		{
			Regex regex = new Regex(@"^.{3,450}$");
			bool flag = regex.IsMatch(tbPartC_name.Text);
			string message = "";

			if (!flag)
			{
				message = "Наименование получателя отсутствует";
				epPartC_reorganizedTin.SetError(tbPartC_reorganizedTin, message);
			}
			else
			{
				epPartC_reorganizedTin.Clear();				
			}
			
		}

		private void tbPartC_shareParticipation_TextChanged(object sender, EventArgs e)
		{
			tbPartC_shareParticipation_Validation();
		}

		private void tbPartC_shareParticipation_Validation()
		{

			Regex regex = new Regex(@"^[0][.]\d{0,5}[1-9]$");
			bool flag = regex.IsMatch(tbPartC_shareParticipation.Text);
			if (!flag)
			{
				epPartC_shareParticipation.SetError(tbPartC_shareParticipation, "Укажите долю участия в формате десятичной дроби < 1");
			}
			else
			{
				epPartC_shareParticipation.Clear();
			}
			
		}

		private void chbxPartC_isJointActivityParticipant_CheckedChanged(object sender, EventArgs e)
		{
			TabControl tabControl = (TabControl)this.Parent.Parent;
			if (chbxPartC_isJointActivityParticipant.Checked)
			{
				tabControl.TabPages[0].Text = "Customer-Participant #1";
				tbPartC_shareParticipation.Enabled = true;
				numUpDown_participantCounter.Enabled = true;
				numUpDown_participantCounter.Value = 2;
			}
			else
			{
				tabControl.TabPages[0].Text = "Customer";
				tbPartC_shareParticipation.Enabled = false;
				tbPartC_shareParticipation.Text = "";
				numUpDown_participantCounter.Value = 1;
				numUpDown_participantCounter.Enabled = false;
			}
		}

		private void chbxPartC_isSharingAgreementParticipant_CheckedChanged(object sender, EventArgs e)
		{			
			if (chbxPartC_isSharingAgreementParticipant.Checked)
			{
				if (!checkForSharingAgreementParticipant(tbPartC_tin.Text))
				{
					chbxPartC_isSharingAgreementParticipant.Checked = false;
				}
			}
			chbxPartC_isRetail_Validating();

			TabControl tabControl = (TabControl)this.Parent.Parent;
			if (chbxPartC_isSharingAgreementParticipant.Checked)
			{
				tabControl.TabPages[0].Text = "Customer-Participant #1";
				tbPartC_shareParticipation.Enabled = true;
				numUpDown_participantCounter.Enabled = true;
				numUpDown_participantCounter.Value = 2;

			}
			else
			{
				tabControl.TabPages[0].Text = "Customer";
				tbPartC_shareParticipation.Enabled = false;
				tbPartC_shareParticipation.Text = "";
				numUpDown_participantCounter.Value = 1;
				numUpDown_participantCounter.Enabled = false;
			}
		}

		private bool checkForSharingAgreementParticipant(string tin)
		{
			return true;
		}

		private void tbPartc_countryCode_TextChanged(object sender, EventArgs e)
		{
			tbPartC_countryCode_Validation();
		}

		private void tbPartC_countryCode_Validation()
		{
			Regex regex = new Regex(@"^.{0,2}$");
			bool flag = regex.IsMatch(tbPartC_countryCode.Text);
			if (!flag)
			{
				epPartC_countryCode.SetError(tbPartC_countryCode, "neverniy format adressa");
			}
			else
			{
				epPartC_countryCode.Clear();
			}
		}

		private void tbPartC_address_TextChanged(object sender, EventArgs e)
		{
			tbPartC_address_Validation();
		}

		private void tbPartC_address_Validation()
		{
			Regex regex = new Regex(@"^.{3,450}$");
			bool flag = regex.IsMatch(tbPartC_address.Text);
			if (!flag)
			{
				epPartC_address.SetError(tbPartC_address, "neverniy format adressa");
			}
			else
			{
				epPartC_address.Clear();
			}
		}

		private void tbPartC_trailer_TextChanged(object sender, EventArgs e)
		{
			tbPartC_trailer_Validation();
		}

		private void tbPartC_trailer_Validation()
		{
			Regex regex = new Regex(@"^.{0,255}$");
			bool flag = regex.IsMatch(tbPartC_trailer.Text);
			if(!flag)
			{
				epPartC_trailer.SetError(tbPartC_trailer, "Neverniy format");
			}
			else
			{
				epPartC_trailer.Clear();
			}
		}

		private void chbxPartC_isCommitent_CheckedChanged(object sender, EventArgs e)
		{
			chbxPartC_isRetail_Validating();
			if (chbxPartC_isCommitent.Checked)
			{
				chbxPartC_isBroker.Checked = false;
			}
		}

		private void chbxPartC_isBroker_CheckedChanged(object sender, EventArgs e)
		{
			if (chbxPartC_isBroker.Checked)
			{
				chbxPartC_isCommitent.Checked = false;
			}
		}

		private void chbxPartC_isPrincipal_CheckedChanged(object sender, EventArgs e)
		{
			chbxPartC_isRetail_Validating();
		}

		private void chbxPartC_isRetail_CheckedChanged(object sender, EventArgs e)
		{
			chbxPartC_isRetail_Validating();	
		}

		private void chbxPartC_isRetail_Validating()
		{
			if (!hasPermission() && (chbxPartC_isCommitent.Checked || chbxPartC_isPrincipal.Checked || chbxPartC_isLessee.Checked || chbxPartC_isPublicOffice.Checked || chbxPartC_isSharingAgreementParticipant.Checked))
			{
				epPartC_CustomerType.SetError(l_PartC_CustomerType, "В категории получателя при выборе категории I дополнительно нельзя выбрать категории A, C, E, G, H.");
			}
			else
			{
				epPartC_CustomerType.Clear();
			}
		}

		private bool hasPermission()
		{
			return true;
		}

		private void chbxPartC_isLessee_CheckedChanged(object sender, EventArgs e)
		{
			chbxPartC_isRetail_Validating();
		}

		private void chbxPartC_isPublicOffice_CheckedChanged(object sender, EventArgs e)
		{
			chbxPartC_isRetail_Validating();
			if(chbxPartC_isPublicOffice.Checked)
			{
				tbPartC1_iik.Enabled = true;
				tbPartC1_productCode.Enabled = true;
				tbPartC1_payPurpose.Enabled = true;
				tbPartC1_bik.Text = "KKMFKZ2A";
			}
			else
			{
				tbPartC1_iik.Enabled = false;
				tbPartC1_productCode.Enabled = false;
				tbPartC1_payPurpose.Enabled = false;
				tbPartC1_bik.Text = "";
			}
			
		}

		private void tbPartC1_iik_TextChanged(object sender, EventArgs e)
		{
			tbPartC1_iik_Validation();
		}

		private void tbPartC1_iik_Validation()
		{
			Regex regex = new Regex(@"^.{0,20}$");
			bool flag = regex.IsMatch(tbPartC1_iik.Text);
			
			if(!flag)
			{
				epPartC1_iik.SetError(tbPartC1_iik, "neverniy format");
			}
			{
				epPartC1_iik.Clear();
			}
		}

		private void tbPartC1_productCode_TextChanged(object sender, EventArgs e)
		{
			tbPartC1_productCode_Validation();
		}

		private void tbPartC1_productCode_Validation()
		{
			Regex regex = new Regex(@"^\d{0,10}");
			bool flag = regex.IsMatch(tbPartC1_productCode.Text);

			if (!flag)
			{
				epPartC1_productCode.SetError(tbPartC1_productCode, "Neverniy format");

			}
			else
			{
				epPartC1_productCode.Clear();
			}
		}

		private void tbPartC1_payPurpose_TextChanged(object sender, EventArgs e)
		{
			tbPartC1_payPurpose_Validation();
		}

		private void tbPartC1_payPurpose_Validation()
		{
			/*string temp = tbPartC1_payPurpose.Text.Trim();
			Regex regex = new Regex(@"['\t']|['\n']|[':']{1}");
			temp = regex.Replace(temp," ");
			tbPartC1_payPurpose.Text = temp;*/

			Regex regex = new Regex(@".{1,240}");

			bool flag = regex.IsMatch(tbPartC1_payPurpose.Text);
			if (!flag)
			{
				epPartC1_payPurpose.SetError(tbPartC1_payPurpose, "otsutstvuet ili neverniy format");
			}
			else
			{
				epPartC1_payPurpose.Clear();
			}
		}
	}
}
