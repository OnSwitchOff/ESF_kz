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
		public panelESFpartCtab()
		{
			InitializeComponent();
		}

		private void numUpDown_participantCounter_ValueChanged(object sender, EventArgs e)
		{
			
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

			if(isNonResident)
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
					}
				}

			}

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
	}
}
