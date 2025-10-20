using Lab8;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class fCamera : Form
	{
		public Camera TheCamera;

		public fCamera(Camera c)
		{
			TheCamera = c;
			InitializeComponent();
		}

		private void fCamera_Load(object sender, EventArgs e)
		{
			if (TheCamera != null)
			{
				tbModel.Text = TheCamera.Model;
				tbManufacturer.Text = TheCamera.Manufacturer;
				tbMegapixels.Text = TheCamera.Megapixels.ToString("0.##");
				tbBattery.Text = TheCamera.BatteryCapacity.ToString();
				tbWeight.Text = TheCamera.Weight.ToString("0.##");
				tbPrice.Text = TheCamera.Price.ToString("0.##");
				tbYear.Text = TheCamera.ReleaseYear.ToString();
				chbHasWiFi.Checked = TheCamera.HasWiFi;
				chbHasInterchangeableLens.Checked = TheCamera.HasInterchangeableLens;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!ValidateAndFill(TheCamera))
				return;

			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private bool ValidateAndFill(Camera cam)
		{
			if (cam == null)
			{
				MessageBox.Show("Внутрішня помилка. Об’єкт камери не створено.", "Помилка",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Прості перевірки
			cam.Model = (tbModel.Text ?? "").Trim();
			cam.Manufacturer = (tbManufacturer.Text ?? "").Trim();

			if (!TryParseDouble(tbMegapixels.Text, out var megapixels) || megapixels <= 0)
			{
				MessageBox.Show("Вкажіть коректні мегапікселі (> 0).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbMegapixels.Focus();
				return false;
			}

			if (!int.TryParse(tbBattery.Text?.Trim(), out var battery) || battery <= 0)
			{
				MessageBox.Show("Вкажіть коректну ємність батареї (ціле > 0).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbBattery.Focus();
				return false;
			}

			if (!TryParseDouble(tbWeight.Text, out var weight) || weight <= 0)
			{
				MessageBox.Show("Вкажіть коректну вагу (> 0).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbWeight.Focus();
				return false;
			}

			if (!TryParseDecimal(tbPrice.Text, out var price) || price <= 0)
			{
				MessageBox.Show("Вкажіть коректну ціну (> 0).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbPrice.Focus();
				return false;
			}

			if (!int.TryParse(tbYear.Text?.Trim(), out var year) || year < 1900 || year > DateTime.Now.Year)
			{
				MessageBox.Show($"Рік має бути у діапазоні 1900..{DateTime.Now.Year}.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbYear.Focus();
				return false;
			}

			// Запис у властивості (класи вже коригують значення у сеттерах при потребі)
			cam.Megapixels = megapixels;
			cam.BatteryCapacity = battery;
			cam.Weight = weight;
			cam.Price = price;
			cam.ReleaseYear = year;
			cam.HasWiFi = chbHasWiFi.Checked;
			cam.HasInterchangeableLens = chbHasInterchangeableLens.Checked;

			return true;
		}

		private static bool TryParseDouble(string text, out double value)
		{
			text = (text ?? "").Trim();
			if (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
				return true;
			if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
				return true;
			var swapped = text.Replace(',', '.');
			return double.TryParse(swapped, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
		}

		private static bool TryParseDecimal(string text, out decimal value)
		{
			text = (text ?? "").Trim();
			if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
				return true;
			if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
				return true;
			var swapped = text.Replace(',', '.');
			return decimal.TryParse(swapped, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
		}
	}
}
