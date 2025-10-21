using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab10
{
	public partial class MainForm : Form
	{
		private readonly ToolStrip toolStrip;
		private readonly ToolStripButton btnAdd;
		private readonly ToolStripButton btnEdit;
		private readonly ToolStripSeparator sep1;
		private readonly ToolStripButton btnDelete;
		private readonly ToolStripButton btnClear;
		private readonly ToolStripSeparator sep2;
		private readonly ToolStripButton btnExit;

		private readonly BindingSource bindingSource;
		private readonly DataGridView grid;

		private readonly List<Camera> data = new List<Camera>();

		public MainForm()
		{
			Name = "fMain";
			Text = "Лабораторна робота №10 — Камери (net48)";
			StartPosition = FormStartPosition.CenterScreen;
			Width = 1100;
			Height = 600;

			toolStrip = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, ImageScalingSize = new Size(20, 20) };

			btnAdd = new ToolStripButton("Додати запис") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnEdit = new ToolStripButton("Редагувати запис") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			sep1 = new ToolStripSeparator();
			btnDelete = new ToolStripButton("Видалити запис") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnClear = new ToolStripButton("Очистити таблицю") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			sep2 = new ToolStripSeparator();
			btnExit = new ToolStripButton("Вийти") { Alignment = ToolStripItemAlignment.Right, DisplayStyle = ToolStripItemDisplayStyle.Text };

			toolStrip.Items.AddRange(new ToolStripItem[]
			{
				btnAdd, btnEdit, sep1, btnDelete, btnClear, sep2, btnExit
			});

			bindingSource = new BindingSource();
			grid = new DataGridView
			{
				Dock = DockStyle.Fill,
				ReadOnly = true,
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				DataSource = bindingSource,
				AutoGenerateColumns = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				MultiSelect = false
			};

			Controls.Add(grid);
			Controls.Add(toolStrip);

			Load += OnLoad;
			Resize += OnResizeForm;
			btnAdd.Click += OnAdd;
			btnEdit.Click += OnEdit;
			btnDelete.Click += OnDelete;
			btnClear.Click += OnClear;
			btnExit.Click += OnExit;
		}

		private void OnLoad(object sender, EventArgs e)
		{
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = "Модель", Width = 160 });
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Manufacturer", HeaderText = "Виробник", Width = 160 });
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Megapixels", HeaderText = "Мп", Width = 60 });
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Ціна, USD", Width = 90 });
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReleaseYear", HeaderText = "Рік", Width = 60 });
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BatteryCapacity", HeaderText = "Батарея, mAh", Width = 110 });
			grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Weight", HeaderText = "Вага, г", Width = 80 });
			grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "HasWiFi", HeaderText = "Wi-Fi", Width = 60 });
			grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "HasInterchangeableLens", HeaderText = "Змін. об’єктив", Width = 110 });

			// демо-дані
			data.Add(new Camera("Alpha 7 IV", "Sony", 33, 2280, 658, 2499, 2021, true, true));
			data.Add(new Camera("EOS R6 Mark II", "Canon", 24.2, 2130, 670, 2499, 2022, true, true));
			data.Add(new Camera("X-T5", "Fujifilm", 40, 1600, 557, 1699, 2022, true, true));

			bindingSource.DataSource = data;
			RelayoutExitButton();
		}

		private void OnResizeForm(object sender, EventArgs e)
		{
			RelayoutExitButton();
		}

		private void RelayoutExitButton()
		{
			int buttonsSize = 5 * 120 + 2 * 10 + 30;
			int left = Math.Max(0, Width - buttonsSize);
			btnExit.Margin = new Padding(left, 0, 0, 0);
		}

		private Camera GetCurrentOrNull()
		{
			Camera cam = bindingSource.Current as Camera;
			return cam;
		}

		private void OnAdd(object sender, EventArgs e)
		{
			Camera cam = new Camera();
			using (EditCameraForm dlg = new EditCameraForm(cam, "Додати запис про камеру"))
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					data.Add(cam);
					bindingSource.ResetBindings(false);
				}
			}
		}

		private void OnEdit(object sender, EventArgs e)
		{
			Camera cam = GetCurrentOrNull();
			if (cam == null) return;

			Camera draft = new Camera(cam.Model, cam.Manufacturer, cam.Megapixels, cam.BatteryCapacity,
									  cam.Weight, cam.Price, cam.ReleaseYear, cam.HasWiFi, cam.HasInterchangeableLens);

			using (EditCameraForm dlg = new EditCameraForm(draft, "Редагувати запис"))
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					cam.Model = draft.Model;
					cam.Manufacturer = draft.Manufacturer;
					cam.Megapixels = draft.Megapixels;
					cam.BatteryCapacity = draft.BatteryCapacity;
					cam.Weight = draft.Weight;
					cam.Price = draft.Price;
					cam.ReleaseYear = draft.ReleaseYear;
					cam.HasWiFi = draft.HasWiFi;
					cam.HasInterchangeableLens = draft.HasInterchangeableLens;

					bindingSource.ResetCurrentItem();
				}
			}
		}

		private void OnDelete(object sender, EventArgs e)
		{
			Camera cam = GetCurrentOrNull();
			if (cam == null) return;

			if (MessageBox.Show(this, "Видалити поточний запис?", "Підтвердження",
								MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
			{
				data.Remove(cam);
				bindingSource.ResetBindings(false);
			}
		}

		private void OnClear(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Очистити таблицю?\n\nВсі дані будуть втрачені.",
								"Підтвердження", MessageBoxButtons.OKCancel,
								MessageBoxIcon.Question) == DialogResult.OK)
			{
				data.Clear();
				bindingSource.ResetBindings(false);
			}
		}

		private void OnExit(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Закрити застосунок?", "Вихід",
								MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Application.Exit();
			}
		}
	}
}
