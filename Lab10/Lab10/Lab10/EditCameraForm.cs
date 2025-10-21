using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab10
{
	public class EditCameraForm : Form
	{
		private readonly Camera camera;

		private readonly TextBox tbModel = new TextBox();
		private readonly TextBox tbManufacturer = new TextBox();
		private readonly NumericUpDown numMegapixels = new NumericUpDown();
		private readonly NumericUpDown numBattery = new NumericUpDown();
		private readonly NumericUpDown numWeight = new NumericUpDown();
		private readonly NumericUpDown numPrice = new NumericUpDown();
		private readonly NumericUpDown numYear = new NumericUpDown();
		private readonly CheckBox cbWiFi = new CheckBox { Text = "Wi-Fi" };
		private readonly CheckBox cbLens = new CheckBox { Text = "Змінний об’єктив" };
		private readonly Button btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK };
		private readonly Button btnCancel = new Button { Text = "Скасувати", DialogResult = DialogResult.Cancel };

		public EditCameraForm(Camera camera, string title)
		{
			this.camera = camera;

			Text = title;
			StartPosition = FormStartPosition.CenterParent;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			ClientSize = new Size(520, 360);

			TableLayoutPanel table = new TableLayoutPanel
			{
				Dock = DockStyle.Fill,
				ColumnCount = 2,
				RowCount = 10,
				Padding = new Padding(12),
				AutoSize = true
			};
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

			AddRow(table, 0, "Модель:", tbModel);
			AddRow(table, 1, "Виробник:", tbManufacturer);

			Configure(numMegapixels, 1, 200, 0.1m, 1);
			AddRow(table, 2, "Мегапікселі:", numMegapixels);

			Configure(numBattery, 500, 10000, 50, 1500);
			AddRow(table, 3, "Батарея, mAh:", numBattery);

			Configure(numWeight, 100, 5000, 10, 400);
			AddRow(table, 4, "Вага, г:", numWeight);

			Configure(numPrice, 1, 100000, 1, 500);
			AddRow(table, 5, "Ціна, USD:", numPrice);

			Configure(numYear, 1900, DateTime.Now.Year, 1, DateTime.Now.Year);
			AddRow(table, 6, "Рік випуску:", numYear);

			FlowLayoutPanel flagsPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
			flagsPanel.Controls.Add(cbWiFi);
			flagsPanel.Controls.Add(cbLens);
			AddRow(table, 7, "Опції:", flagsPanel);

			FlowLayoutPanel buttons = new FlowLayoutPanel
			{
				FlowDirection = FlowDirection.RightToLeft,
				Dock = DockStyle.Fill,
				AutoSize = true
			};
			btnOk.Click += OnOk;
			buttons.Controls.Add(btnOk);
			buttons.Controls.Add(btnCancel);
			table.Controls.Add(buttons, 0, 9);
			table.SetColumnSpan(buttons, 2);

			Controls.Add(table);

			// preload values
			tbModel.Text = camera.Model;
			tbManufacturer.Text = camera.Manufacturer;
			numMegapixels.Value = Coerce(numMegapixels, (decimal)camera.Megapixels);
			numBattery.Value = Coerce(numBattery, camera.BatteryCapacity);
			numWeight.Value = Coerce(numWeight, (decimal)camera.Weight);
			numPrice.Value = Coerce(numPrice, camera.Price);
			numYear.Value = Coerce(numYear, camera.ReleaseYear);
			cbWiFi.Checked = camera.HasWiFi;
			cbLens.Checked = camera.HasInterchangeableLens;

			AcceptButton = btnOk;
			CancelButton = btnCancel;
		}

		private static void Configure(NumericUpDown n, decimal min, decimal max, decimal step, decimal def)
		{
			n.Minimum = min;
			n.Maximum = max;
			n.DecimalPlaces = step < 1 ? 1 : 0;
			n.Increment = step;
			if (def < min) def = min;
			if (def > max) def = max;
			n.Value = def;
			n.ThousandsSeparator = true;
			n.Dock = DockStyle.Fill;
		}

		private static decimal Coerce(NumericUpDown n, decimal val)
		{
			if (val < n.Minimum) return n.Minimum;
			if (val > n.Maximum) return n.Maximum;
			return val;
		}

		private static decimal Coerce(NumericUpDown n, int val)
		{
			return Coerce(n, (decimal)val);
		}

		private static void AddRow(TableLayoutPanel t, int row, string label, Control editor)
		{
			t.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			Label lb = new Label { Text = label, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, AutoSize = true };
			editor.Dock = DockStyle.Fill;
			t.Controls.Add(lb, 0, row);
			t.Controls.Add(editor, 1, row);
		}

		private void OnOk(object sender, EventArgs e)
		{
			// переносимо дані у модель (властивості виконують валідацію)
			camera.Model = tbModel.Text;
			camera.Manufacturer = tbManufacturer.Text;
			camera.Megapixels = (double)numMegapixels.Value;
			camera.BatteryCapacity = (int)numBattery.Value;
			camera.Weight = (double)numWeight.Value;
			camera.Price = numPrice.Value;
			camera.ReleaseYear = (int)numYear.Value;
			camera.HasWiFi = cbWiFi.Checked;
			camera.HasInterchangeableLens = cbLens.Checked;
		}
	}
}
