using System;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class fMain : Form
	{
		public fMain()
		{
			InitializeComponent();
		}

		private void fMain_Load(object sender, EventArgs e)
		{
			// Зручності і захист від ручного редагування результатів
			tbY.ReadOnly = true;
			tbMin.ReadOnly = true;

			// Швидкі клавіші: Enter = Обчислити, Esc = Вихід
			this.AcceptButton = btnCalculate;
			this.CancelButton = btnExit;
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			// 1) Перевірка заповнення
			if (string.IsNullOrWhiteSpace(tbX1.Text) || string.IsNullOrWhiteSpace(tbX2.Text))
			{
				tbY.Text = "Не введено даних!";
				tbMin.Text = string.Empty;
				return;
			}

			// 2) Парсинг (кома або крапка)
			if (!TryParse(tbX1.Text, out double x1) || !TryParse(tbX2.Text, out double x2))
			{
				MessageBox.Show("Невірний формат числа. Використай крапку або кому.", "Помилка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 3) Перевірка знаменника: 34 - 9*x2^3 ≠ 0
			double denom = 34 - 9 * Math.Pow(x2, 3);
			if (Math.Abs(denom) < 1e-12)
			{
				MessageBox.Show("Знаменник дорівнює нулю. Обчислення неможливе.", "Помилка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 4) Обчислення:
			// y = (4 * sin(3 + x1*x2)) / (34 - 9*x2^3)
			double y = (4 * Math.Sin(3 + x1 * x2)) / denom;

			// 5) Вивід результатів
			tbY.Text = y.ToString("0.######");
			tbMin.Text = Math.Min(x1, x2).ToString("0.######");
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			tbX1.Text = string.Empty;
			tbX2.Text = string.Empty;
			tbY.Text = string.Empty;
			tbMin.Text = string.Empty;
			tbX1.Focus();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Допоміжний парсер: приймає і кому, і крапку
		private static bool TryParse(string s, out double value)
		{
			if (double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
				return true;

			if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
				return true;

			string swapped = s.Replace(',', '.');
			return double.TryParse(swapped, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
		}
	}
}
