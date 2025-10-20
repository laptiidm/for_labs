using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Lab8
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new fMain());
		}
	}
}
