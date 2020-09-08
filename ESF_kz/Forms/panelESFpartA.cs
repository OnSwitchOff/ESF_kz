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
	public partial class panelESFpartA : UserControl
	{
		
		private const string DOWN_TIME = "Простой системы";
		private const string UNLAWFUL_REMOVAL_REGISTRATIONE = "Блокирование доступа к Системе";
		private const string MISSING_REQUIREMENT = "Отсутствовало требование по выписке ЭСФ";

		public panelESFpartA()
		{
			InitializeComponent();
			//Проверка -1.1 Номер учетной системы-
			tbAccSysNum_Validating(this.tbPartA_AccSysNum,null);
			//Иницализация -2. Дата выписки- текущей датой
			this.dtpPartA_Date.Value = DateTime.Now;


			//Добавление делегата проверки -1.1 Номер учетной системы-
			this.tbPartA_AccSysNum.Validating += tbAccSysNum_Validating;			
			//Добавление делегата проверки -Причина выписки на бумажном носителе-
			this.combxPartA_PaperESFReason.Validating += CombxPartA_PaperESFReason_Validating;
			//Добавление делегата проверки -2.1 Дата выписки на бумажном носителе-
			this.dtpPartA_PaperESFDate.Validating += DtpPartA_PaperESFDate_Validating;
		}


		//Делегата проверки -Причина выписки на бумажном носителе-
		private void CombxPartA_PaperESFReason_Validating(object sender, CancelEventArgs e)
		{
			switch (combxPartA_PaperESFReason.Text)
			{
				case MISSING_REQUIREMENT:
				case UNLAWFUL_REMOVAL_REGISTRATIONE:
				case DOWN_TIME:
					epPartA_PaperESFReason.Clear();
					break;
				default:
					epPartA_PaperESFReason.SetError(combxPartA_PaperESFReason, "Выберите причину");
					break;
			}
		}


		//Делегата проверки -2.1 Дата выписки на бумажном носителе-
		private void DtpPartA_PaperESFDate_Validating(object sender, CancelEventArgs e)
		{
			bool flag = false;
			string alertMsg = "";

			bool isLargeCompany = false;//??????
			bool isNDSPayer = false;//????			
			bool isOlderThanFiveYears = DateTime.Now > dtpPartA_PaperESFDate.Value.AddYears(5);
			bool isOlderThan_2018_01_01 = dtpPartA_PaperESFDate.Value < new DateTime(2018, 1, 1);
			bool isOlderThan_2019_01_01 = dtpPartA_PaperESFDate.Value < new DateTime(2018, 1, 1);
			bool isChosenMissingRequirement = combxPartA_PaperESFReason.Text == MISSING_REQUIREMENT; ;



			if (isChosenMissingRequirement)
			{
				if (isOlderThanFiveYears)
				{
					alertMsg = "старше 5 лет";
				}
				else
				{
					//1. Если дата бумажного СФ, на который	необходимо выписать исправленный и дополнительный ЭСФ, является до 01.01.2018 года(но не больше 5 лет с текущей даты), то проверки осуществлять не нужно.
					if (isOlderThan_2018_01_01)
					{
						flag = true;
					}
					//2. Если дата бумажного СФ, на который необходимо выписать исправленный и дополнительный ЭСФ, равна 01.01.2018 года и позже, то нужно проверить входит ли Пользователь в список крупных компаний.Если пользователь входит в 
					//список крупных компаний, то выходит сообщение: "Вы не можете вводить бумажный СФ с причиной "Отсутствовало требование по выписке ЭСФ".
					else if (!isOlderThan_2018_01_01 && isLargeCompany)
					{
						alertMsg = "Вы не можете вводить бумажный СФ с причиной \"Отсутствовало требование по выписке ЭСФ\"";
					}
					//3.Если дата бумажного СФ, на который необходимо выписать исправленный и дополнительный ЭСФ, равна 01.01.2019 года и позже(но не больше 5 лет с текущей даты), то необходимо проверить
					//является ли Пользователь плательщиком НДС на дату выписки бумажного счетафактуры.При ошибке сообщение: "Вы не можете вводить бумажный СФ с причиной "Отсутствовало требование повыписке ЭСФ"".
					else if (!isOlderThan_2019_01_01 && !isNDSPayer)
					{
						alertMsg = "Вы не можете вводить бумажный СФ с причиной \"Отсутствовало требование повыписке ЭСФ\"";
					}
					else
					{
						flag = true;
					}					
				}
			}

			if(!flag)
			{
				epPartA_PaperESFDate.SetError(dtpPartA_PaperESFDate, alertMsg);
			}
			else
			{
				epPartA_PaperESFDate.Clear();
			}
		}

		//Делегат проверки -1.1 Номер учетной системы-
		private void tbAccSysNum_Validating(object sender, CancelEventArgs e)
		{
			Regex regex = new Regex(@"^\d{1,30}$");
			bool flag = regex.IsMatch(tbPartA_AccSysNum.Text);
			if (!flag)
			{
				epPartA_Date.SetError(tbPartA_AccSysNum, "Номер учетной системы отсутствует");
			}
			else
			{
				epPartA_Date.Clear();
			}
		}	

		private void dtpDate_Validating(object sender, CancelEventArgs e)
		{

		}
		

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void chbxPartA_isPaperESF_CheckedChanged(object sender, EventArgs e)
		{
			if(this.chbxPartA_isPaperESF.Checked)
			{
				l_PaperESFDate.Enabled = true;
				l_PaperESFReason.Enabled = true;
				combxPartA_PaperESFReason.Enabled = true;
				CombxPartA_PaperESFReason_Validating(this.combxPartA_PaperESFReason, null);
			}
			else
			{
				l_PaperESFDate.Enabled = false;
				l_PaperESFReason.Enabled = false;
				combxPartA_PaperESFReason.Enabled = false;
				combxPartA_PaperESFReason.Text = "";
				dtpPartA_PaperESFDate.Value = DateTime.Now;
				dtpPartA_PaperESFDate.Enabled = false;
				epPartA_PaperESFDate.Clear();
				epPartA_PaperESFReason.Clear();
			}
		}

		private void combxPartA_PaperESFReason_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (combxPartA_PaperESFReason.Text)
			{
				case DOWN_TIME:
				case UNLAWFUL_REMOVAL_REGISTRATIONE:
				case MISSING_REQUIREMENT:
					dtpPartA_PaperESFDate.Enabled = true;
					DtpPartA_PaperESFDate_Validating(epPartA_PaperESFDate, null);
					break;
				default:
					dtpPartA_PaperESFDate.Enabled = false;
					break;
			}
		}

		private void dtpPartA_TurnoverDate_ValueChanged(object sender, EventArgs e)
		{

		}

		private void chbxPartA_isCorrectedESF_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chbxPartA_isCorrectedESF.Checked)
			{
				chbxPartA_isAddedESF.Checked = false;
				l_CorrectedESFDate.Enabled = true;
				l_CorrectedESFAccSysNum.Enabled = true;
				l_CorrectedESFNum.Enabled = true;
				FillCorrectedESFData();				
			}
			else
			{
				l_CorrectedESFDate.Enabled = false;
				l_CorrectedESFAccSysNum.Enabled = false;
				l_CorrectedESFNum.Enabled = false;
				ClearCorrectedESFData();
			}
		}



		private void ClearCorrectedESFData()
		{
			
		}

		private void FillCorrectedESFData()
		{
			
		}

		private void chbxPartA_isAddedESF_CheckedChanged(object sender, EventArgs e)
		{
			if (this.chbxPartA_isAddedESF.Checked)
			{
				chbxPartA_isCorrectedESF.Checked = false;
				l_AddedESFDate.Enabled = true;
				l_AddedESFAccSysNum.Enabled = true;
				l_AddedESFNum.Enabled = true;
				FillAddedESFData();
			}
			else
			{
				l_AddedESFDate.Enabled = false;
				l_AddedESFAccSysNum.Enabled = false;
				l_AddedESFNum.Enabled = false;
				ClearAddedESFData();
			}
		}

		private void ClearAddedESFData()
		{
			
		}

		private void FillAddedESFData()
		{

		}

		private void tbPartA_Num_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
