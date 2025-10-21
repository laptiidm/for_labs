using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Lab09
{
	public partial class fMain : Form
	{
		public fMain()
		{
			InitializeComponent();
		}

		// y = 4*sin(3 + x1*x2) / (34 - 9*x2^3)
		private static double ComputeY(double x1, double x2)
		{
			double denom = 34 - 9 * Math.Pow(x2, 3);
			if (Math.Abs(denom) < 1e-12) return double.NaN; // недопустима точка
			return (4 * Math.Sin(3 + x1 * x2)) / denom;
		}

		private void btnCalc_Click(object sender, EventArgs e)
		{
			if (!TryReadInputs(out double x1min, out double x1max, out double dx1,
							   out double x2min, out double x2max, out double dx2))
				return;

			int cols = (int)Math.Truncate((x2max - x2min) / dx2) + 1;
			int rows = (int)Math.Truncate((x1max - x1min) / dx1) + 1;

			if (cols <= 0 || rows <= 0)
			{
				MessageBox.Show("Порожній діапазон. Перевір значення min/max та кроки.", "Помилка");
				return;
			}

			// Готуємо gv
			gv.Columns.Clear();
			gv.Rows.Clear();
			gv.ColumnCount = cols;
			gv.RowCount = rows;

			// Заголовки
			for (int r = 0; r < rows; r++)
			{
				double x1 = x1min + r * dx1;
				gv.Rows[r].HeaderCell.Value = x1.ToString("0.000");
			}
			gv.RowHeadersWidth = 80;

			for (int c = 0; c < cols; c++)
			{
				double x2 = x2min + c * dx2;
				gv.Columns[c].HeaderCell.Value = x2.ToString("0.000");
				gv.Columns[c].Width = 70;
			}

			// 
			double negativeSum = 0.0;
			for (int r = 0; r < rows; r++)
			{
				double x1 = x1min + r * dx1;
				for (int c = 0; c < cols; c++)
				{
					double x2 = x2min + c * dx2;
					double y = ComputeY(x1, x2);
					gv.Rows[r].Cells[c].Value = double.IsNaN(y) ? "NaN" : y.ToString("0.000");
					if (!double.IsNaN(y) && y < 0) negativeSum += y;
				}
			}

			MessageBox.Show($"Сума всіх від'ємних значень y: {negativeSum:0.000}", "Варіант 5");

			gv.ColumnCount = cols + 1;
			gv.RowCount = rows + 1;

			gv.Columns[cols].HeaderCell.Value = "AVG";
			gv.Columns[cols].Width = 80;
			gv.Rows[rows].HeaderCell.Value = "AVG";

			for (int r = 0; r < rows; r++)
			{
				double sum = 0.0;
				int cnt = 0;
				for (int c = 0; c < cols; c++)
				{
					if (double.TryParse(gv.Rows[r].Cells[c].Value?.ToString(), NumberStyles.Float,
						CultureInfo.InvariantCulture, out double val) ||
						double.TryParse(gv.Rows[r].Cells[c].Value?.ToString(), NumberStyles.Float,
						CultureInfo.CurrentCulture, out val))
					{
						if (!double.IsNaN(val))
						{
							sum += val;
							cnt++;
						}
					}
				}
				double avg = cnt > 0 ? sum / cnt : double.NaN;
				gv.Rows[r].Cells[cols].Value = double.IsNaN(avg) ? "NaN" : avg.ToString("0.000");
			}

			for (int c = 0; c < cols; c++)
			{
				double sum = 0.0;
				int cnt = 0;
				for (int r = 0; r < rows; r++)
				{
					if (double.TryParse(gv.Rows[r].Cells[c].Value?.ToString(), NumberStyles.Float,
						CultureInfo.InvariantCulture, out double val) ||
						double.TryParse(gv.Rows[r].Cells[c].Value?.ToString(), NumberStyles.Float,
						CultureInfo.CurrentCulture, out val))
					{
						if (!double.IsNaN(val))
						{
							sum += val;
							cnt++;
						}
					}
				}
				double avg = cnt > 0 ? sum / cnt : double.NaN;
				gv.Rows[rows].Cells[c].Value = double.IsNaN(avg) ? "NaN" : avg.ToString("0.000");
			}

			gv.Rows[rows].Cells[cols].Value = "";
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			tbx1min.Text = "";
			tbx1max.Text = "";
			tbx2min.Text = "";
			tbx2max.Text = "";
			tbdx1.Text = "";
			tbdx2.Text = "";
			gv.Rows.Clear();
			gv.Columns.Clear();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Закрити програму?", "Вихід",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private bool TryReadInputs(out double x1min, out double x1max, out double dx1,
								   out double x2min, out double x2max, out double dx2)
		{
			x1min = x1max = dx1 = x2min = x2max = dx2 = 0;

			bool ok =
				TryParse(tbx1min.Text, out x1min) &&
				TryParse(tbx1max.Text, out x1max) &&
				TryParse(tbdx1.Text, out dx1) &&
				TryParse(tbx2min.Text, out x2min) &&
				TryParse(tbx2max.Text, out x2max) &&
				TryParse(tbdx2.Text, out dx2);

			if (!ok)
			{
				MessageBox.Show("Невірний формат чисел. Дозволені кома або крапка.", "Помилка");
				return false;
			}

			if (dx1 <= 0 || dx2 <= 0)
			{
				MessageBox.Show("Кроки dX1 та dX2 мають бути > 0.", "Помилка");
				return false;
			}
			if (x1max < x1min || x2max < x2min)
			{
				MessageBox.Show("Максимум має бути ≥ мінімуму для обох змінних.", "Помилка");
				return false;
			}

			int approxCols = (int)Math.Truncate((x2max - x2min) / dx2) + 1;
			int approxRows = (int)Math.Truncate((x1max - x1min) / dx1) + 1;
			if (approxCols * approxRows > 15000)
			{
				var res = MessageBox.Show(
					$"Вийде дуже велика таблиця ({approxRows} × {approxCols}). Продовжити?",
					"Попередження",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning);
				if (res != DialogResult.OK) return false;
			}

			return true;
		}

		private static bool TryParse(string s, out double value)
		{
			s = (s ?? "").Trim();
			if (double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
				return true;
			if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
				return true;
			string swapped = s.Replace(',', '.');
			return double.TryParse(swapped, NumberStyles.Float, provider: CultureInfo.InvariantCulture, out value);
		}
	}
}
