using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESF_kz
{
	static class ValidatingManager
	{
		internal static bool enumIsDefined<T>(string str) where T:Enum
		{
			return Enum.IsDefined(typeof(T), str);
		}

		internal static bool ValidateFloatTextBox(TextBox tbProduct, ErrorProvider epProductForm)
		{
			bool result = false;
			Regex regex = new Regex(@"^(\d+)([.]?)(\d*)[1-9]$");
			bool isEmpty = tbProduct.Text == "";
			bool isCorrectFormat = regex.IsMatch(tbProduct.Text);
			if (isEmpty)
			{
				epProductForm.SetError(tbProduct, "Empty value");
			}
			else if (!isCorrectFormat)
			{
				epProductForm.SetError(tbProduct, "Wrong format(must be float)");
			}
			else
			{
				epProductForm.Clear();
				result = true;
			}
			return result;
		}

		internal static bool ValidateIntegerTextBox(TextBox tbProduct, ErrorProvider epProductForm)
		{
			bool result = false;
			Regex regex = new Regex(@"^\d*$");
			bool isEmpty = tbProduct.Text == "";
			bool isCorrectFormat = regex.IsMatch(tbProduct.Text);
			if (isEmpty)
			{
				epProductForm.SetError(tbProduct, "Empty value");
			}
			else if (!isCorrectFormat)
			{
				epProductForm.SetError(tbProduct, "Wrong format(must be integer)");
			}
			else
			{
				epProductForm.Clear();
				result = true;
			}
			return result;
		}
	}
}
