using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
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

		private readonly ToolStripButton btnSaveAsText;
		private readonly ToolStripButton btnSaveAsBinary;
		private readonly ToolStripButton btnOpenFromText;
		private readonly ToolStripButton btnOpenFromBinary;
		private readonly ToolStripSeparator sepFiles;

		private readonly ToolStripButton btnExit;

		private readonly BindingSource bindingSource;
		private readonly DataGridView grid;

		private readonly List<Camera> data = new List<Camera>();

		private readonly SaveFileDialog saveFileDialog = new SaveFileDialog();
		private readonly OpenFileDialog openFileDialog = new OpenFileDialog();

		public MainForm()
		{
			Name = "fMain";
			Text = "Лабораторна робота №10 — Камери (net48)";
			StartPosition = FormStartPosition.CenterScreen;
			Width = 1100;
			Height = 600;

			toolStrip = new ToolStrip
			{
				GripStyle = ToolStripGripStyle.Hidden,
				ImageScalingSize = new Size(20, 20)
			};

			btnAdd = new ToolStripButton("Додати запис") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnEdit = new ToolStripButton("Редагувати запис") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			sep1 = new ToolStripSeparator();
			btnDelete = new ToolStripButton("Видалити запис") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnClear = new ToolStripButton("Очистити таблицю") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			sep2 = new ToolStripSeparator();

			btnSaveAsText = new ToolStripButton("Зберегти TXT") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnSaveAsBinary = new ToolStripButton("Зберегти BIN") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnOpenFromText = new ToolStripButton("Відкрити TXT") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			btnOpenFromBinary = new ToolStripButton("Відкрити BIN") { DisplayStyle = ToolStripItemDisplayStyle.Text };
			sepFiles = new ToolStripSeparator();

			btnExit = new ToolStripButton("Вийти")
			{
				Alignment = ToolStripItemAlignment.Right,
				DisplayStyle = ToolStripItemDisplayStyle.Text
			};

			toolStrip.Items.AddRange(new ToolStripItem[]
			{
				btnAdd,
				btnEdit,
				sep1,
				btnDelete,
				btnClear,
				sep2,
				btnSaveAsText,
				btnSaveAsBinary,
				btnOpenFromText,
				btnOpenFromBinary,
				sepFiles,
				btnExit
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

			btnSaveAsText.Click += OnSaveAsText;
			btnSaveAsBinary.Click += OnSaveAsBinary;
			btnOpenFromText.Click += OnOpenFromText;
			btnOpenFromBinary.Click += OnOpenFromBinary;
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
			// груба оцінка ширини всіх кнопок + відступи
			int buttonsSize = 9 * 120 + 4 * 10 + 30;
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

			Camera draft = new Camera(
				cam.Model,
				cam.Manufacturer,
				cam.Megapixels,
				cam.BatteryCapacity,
				cam.Weight,
				cam.Price,
				cam.ReleaseYear,
				cam.HasWiFi,
				cam.HasInterchangeableLens);

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

		private void OnSaveAsText(object sender, EventArgs e)
		{
			if (data.Count == 0)
			{
				MessageBox.Show(this, "Немає даних для збереження.", "Увага",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Усі файли (*.*)|*.*";
			saveFileDialog.Title = "Зберегти дані у текстовому форматі";
			saveFileDialog.InitialDirectory = Application.StartupPath;

			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				using (var sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
				{
					foreach (Camera cam in data)
					{
						sw.Write(cam.Model + "\t");
						sw.Write(cam.Manufacturer + "\t");
						sw.Write(cam.Megapixels.ToString(CultureInfo.InvariantCulture) + "\t");
						sw.Write(cam.BatteryCapacity.ToString(CultureInfo.InvariantCulture) + "\t");
						sw.Write(cam.Weight.ToString(CultureInfo.InvariantCulture) + "\t");
						sw.Write(cam.Price.ToString(CultureInfo.InvariantCulture) + "\t");
						sw.Write(cam.ReleaseYear.ToString(CultureInfo.InvariantCulture) + "\t");
						sw.Write(cam.HasWiFi.ToString() + "\t");
						sw.Write(cam.HasInterchangeableLens.ToString() + "\t");
						sw.WriteLine();
					}
				}

				MessageBox.Show(this, "Дані успішно збережено у текстовий файл.", "Готово",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Сталася помилка під час збереження:\n" + ex.Message,
					"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnSaveAsBinary(object sender, EventArgs e)
		{
			if (data.Count == 0)
			{
				MessageBox.Show(this, "Немає даних для збереження.", "Увага",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			saveFileDialog.Filter = "Файли даних камер (*.cams)|*.cams|Усі файли (*.*)|*.*";
			saveFileDialog.Title = "Зберегти дані у бінарному форматі";
			saveFileDialog.InitialDirectory = Application.StartupPath;

			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				using (var bw = new BinaryWriter(saveFileDialog.OpenFile()))
				{
					foreach (Camera cam in data)
					{
						bw.Write(cam.Model);
						bw.Write(cam.Manufacturer);
						bw.Write(cam.Megapixels);
						bw.Write(cam.BatteryCapacity);
						bw.Write(cam.Weight);
						bw.Write(cam.Price);
						bw.Write(cam.ReleaseYear);
						bw.Write(cam.HasWiFi);
						bw.Write(cam.HasInterchangeableLens);
					}
				}

				MessageBox.Show(this, "Дані успішно збережено у бінарний файл.", "Готово",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Сталася помилка під час збереження:\n" + ex.Message,
					"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnOpenFromText(object sender, EventArgs e)
		{
			openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Усі файли (*.*)|*.*";
			openFileDialog.Title = "Прочитати дані у текстовому форматі";
			openFileDialog.InitialDirectory = Application.StartupPath;

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				var newData = new List<Camera>();

				using (var sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						if (string.IsNullOrWhiteSpace(line))
							continue;

						string[] split = line.Split('\t');
						if (split.Length < 9)
							throw new FormatException("Неправильний формат рядка даних.");

						string model = split[0];
						string manufacturer = split[1];
						double megapixels = double.Parse(split[2], CultureInfo.InvariantCulture);
						int battery = int.Parse(split[3], CultureInfo.InvariantCulture);
						double weight = double.Parse(split[4], CultureInfo.InvariantCulture);
						decimal price = decimal.Parse(split[5], CultureInfo.InvariantCulture);
						int year = int.Parse(split[6], CultureInfo.InvariantCulture);
						bool hasWiFi = bool.Parse(split[7]);
						bool hasLens = bool.Parse(split[8]);

						var cam = new Camera(model, manufacturer, megapixels, battery, weight,
							price, year, hasWiFi, hasLens);
						newData.Add(cam);
					}
				}

				data.Clear();
				data.AddRange(newData);
				bindingSource.ResetBindings(false);

				MessageBox.Show(this, "Дані успішно завантажено з текстового файлу.", "Готово",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Сталася помилка під час читання:\n" + ex.Message,
					"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnOpenFromBinary(object sender, EventArgs e)
		{
			openFileDialog.Filter = "Файли даних камер (*.cams)|*.cams|Усі файли (*.*)|*.*";
			openFileDialog.Title = "Прочитати дані у бінарному форматі";
			openFileDialog.InitialDirectory = Application.StartupPath;

			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				var newData = new List<Camera>();

				using (var br = new BinaryReader(openFileDialog.OpenFile()))
				{
					while (br.BaseStream.Position < br.BaseStream.Length)
					{
						string model = br.ReadString();
						string manufacturer = br.ReadString();
						double megapixels = br.ReadDouble();
						int battery = br.ReadInt32();
						double weight = br.ReadDouble();
						decimal price = br.ReadDecimal();
						int year = br.ReadInt32();
						bool hasWiFi = br.ReadBoolean();
						bool hasLens = br.ReadBoolean();

						var cam = new Camera(model, manufacturer, megapixels, battery, weight,
							price, year, hasWiFi, hasLens);
						newData.Add(cam);
					}
				}

				data.Clear();
				data.AddRange(newData);
				bindingSource.ResetBindings(false);

				MessageBox.Show(this, "Дані успішно завантажено з бінарного файлу.", "Готово",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Сталася помилка під час читання:\n" + ex.Message,
					"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
