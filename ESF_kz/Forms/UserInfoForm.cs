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

namespace ESF_kz.Forms
{
	public partial class UserInfoForm : Form
	{
		public UserInfoForm()
		{
			InitializeComponent();
			FormManagerFacade.setUserInfoForm(this);
		}

		internal bool fillUserInfoForm(User user)
		{
			try
			{
				fillUserInfoTab();
				fillTaxpayerInfoTab();
				fillHeadOfficeInfoTab();
				fillSettlementAccountsTab();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void fillUserInfoTab()
		{
			tbUserLogin
		}

	}
}
