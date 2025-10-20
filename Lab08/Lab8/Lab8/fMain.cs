using Lab8;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class fMain : Form
	{
		private readonly List<Camera> _items = new List<Camera>();

		public fMain()
		{
			InitializeComponent();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			// За бажанням можна показати підказку користувачу
			tbCamerasInfo.Text = "Список камер буде з’являтися тут...\r\n";
		}

		private void btnAddCamera_Click(object sender, EventArgs e)
		{
			var cam = new Camera();                 // новий екземпляр
			using (var dlg = new fCamera(cam))      // модальне вікно для введення
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					_items.Add(cam);
					AppendCamera(cam);
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Припинити роботу застосунку?", "Підтвердження",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void AppendCamera(Camera c)
		{
			// Вимога лабораторної: показати властивості + результат одного з методів.
			// Виведемо ToString() і метод GetPricePerMegapixel() та EstimatePhotosPerCharge() (буде лиш плюс).
			var sb = new StringBuilder();
			sb.AppendLine(c.ToString());
			sb.AppendLine($"Ціна за Мп: {c.GetPricePerMegapixel():0.00} USD/Мп | Фотографій на заряді (оцінка): {c.EstimatePhotosPerCharge()}");
			sb.AppendLine(new string('-', 80));
			tbCamerasInfo.AppendText(sb.ToString());
		}
	}
}
