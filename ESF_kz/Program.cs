using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESF_kz
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string ialogResult = (((detailsESFfieldAttribute)Attribute.GetCustomAttribute((typeof(ESF)).GetField("registrationNumber"), typeof(detailsESFfieldAttribute))).details);
			Application.Run(new Form1());
			
		}
	}
}
