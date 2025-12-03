using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinApp
{
	public class GameForm : Form
	{
		const int GridSize = 20;
		const int CanvasSize = 600;
		const int CellSize = CanvasSize / GridSize;

		List<string> levelFiles = new List<string> { "level1.txt", "level2.txt", "level3.txt" };
		int currentLevelIndex = 0;

		char[,] grid = new char[GridSize, GridSize];
		Point hedgehogPos = new Point(1, 1);
		int totalApplesInLevel = 0;
		int applesCollected = 0;

		Panel canvas;
		Label info;

		public GameForm()
		{
			this.Width = CanvasSize + 40;
			this.Height = CanvasSize + 120;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Лабіринт — Гра Їжачка";
			this.DoubleBuffered = true;
			this.KeyPreview = true;

			canvas = new Panel
			{
				Left = 10,
				Top = 10,
				Width = CanvasSize,
				Height = CanvasSize,
				BackColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle
			};
			canvas.Paint += Canvas_Paint;
			this.Controls.Add(canvas);

			info = new Label
			{
				Left = 10,
				Top = CanvasSize + 20,
				Width = CanvasSize,
				Height = 60,
				Text = "",
				Font = new Font("Segoe UI", 10),
				TextAlign = ContentAlignment.TopLeft
			};
			this.Controls.Add(info);

			this.KeyDown += GameForm_KeyDown;

			LoadLevel(currentLevelIndex);
		}

		private void UpdateInfoLabel()
		{
			string status = $"Рівень {currentLevelIndex + 1}/{levelFiles.Count}  |  Яблука: {applesCollected}/{totalApplesInLevel}\n";
			string controls = "Керування: W A S D — рух. Зберіть всі яблука та зайдіть у вихід.";
			info.Text = status + controls;
		}

		void LoadLevel(int index)
		{
			if (index >= levelFiles.Count)
			{
				MessageBox.Show("Вітаю! Ви пройшли всі рівні! Гра завершена.", "Перемога",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				currentLevelIndex = 0;
				LoadLevel(0);
				return;
			}

			string file = levelFiles[index];

			if (!File.Exists(file))
			{
				MessageBox.Show("Файл рівня не знайдено: " + file + ". Створюємо порожній рівень.");
				FillEmptyGrid();
				UpdateInfoLabel();
				return;
			}

			string[] lines = File.ReadAllLines(file);

			totalApplesInLevel = 0;
			applesCollected = 0;
			bool hedgehogFound = false;

			for (int y = 0; y < GridSize; y++)
			{
				string line = (y < lines.Length) ? lines[y].PadRight(GridSize, '.') : new string('.', GridSize);

				for (int x = 0; x < GridSize; x++)
				{
					char c = line[x];

					if (c == 'H')
					{
						hedgehogPos = new Point(x, y);
						grid[x, y] = '.';
						hedgehogFound = true;
					}
					else if (c == 'A')
					{
						grid[x, y] = 'A';
						totalApplesInLevel++;
					}
					else if (c == 'E') grid[x, y] = 'E';
					else if (c == '#') grid[x, y] = '#';
					else grid[x, y] = '.';
				}
			}

			if (!hedgehogFound)
				hedgehogPos = new Point(1, 1);

			UpdateInfoLabel();
			canvas.Invalidate();
		}

		void FillEmptyGrid()
		{
			applesCollected = 0;
			totalApplesInLevel = 0;

			for (int x = 0; x < GridSize; x++)
				for (int y = 0; y < GridSize; y++)
					grid[x, y] = (x == 0 || y == 0 || x == GridSize - 1 || y == GridSize - 1) ? '#' : '.';

			hedgehogPos = new Point(1, 1);
		}

		private void Canvas_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			for (int x = 0; x < GridSize; x++)
			{
				for (int y = 0; y < GridSize; y++)
				{
					Rectangle r = new Rectangle(x * CellSize, y * CellSize, CellSize, CellSize);

					if (grid[x, y] == '#')
						g.FillRectangle(Brushes.DarkSlateGray, r);
					else if (grid[x, y] == 'A')
					{
						g.FillRectangle(Brushes.WhiteSmoke, r);
						g.FillEllipse(Brushes.Red, r.X + 5, r.Y + 5, CellSize - 10, CellSize - 10);
					}
					else if (grid[x, y] == 'E')
					{
						g.FillRectangle(Brushes.LightGreen, r);
						using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
						using (Font exitFont = new Font("Segoe UI", 10, FontStyle.Bold))
						{
							g.DrawString("EXIT", exitFont, Brushes.DarkGreen, r, sf);
						}
					}
					else
						g.FillRectangle(Brushes.WhiteSmoke, r);

					g.DrawRectangle(Pens.LightGray, r);
				}
			}

			Rectangle hed = new Rectangle(
				hedgehogPos.X * CellSize + 4,
				hedgehogPos.Y * CellSize + 4,
				CellSize - 8, CellSize - 8);

			g.FillEllipse(Brushes.SaddleBrown, hed);

			Point[] spike = new Point[] {
				new Point(hed.X + hed.Width / 2, hed.Y - 5),
				new Point(hed.X + hed.Width - 5, hed.Y + 5),
				new Point(hed.X + 5, hed.Y + 5)
			};
			g.FillPolygon(Brushes.Black, spike);

			g.FillEllipse(Brushes.Black, hed.X + hed.Width - 8, hed.Y + hed.Height / 2 - 2, 4, 4);

			g.FillEllipse(Brushes.Black, hed.X + 6, hed.Y + 6, 4, 4);
		}

		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			int dx = 0, dy = 0;

			if (e.KeyCode == Keys.W) dy = -1;
			else if (e.KeyCode == Keys.S) dy = 1;
			else if (e.KeyCode == Keys.A) dx = -1;
			else if (e.KeyCode == Keys.D) dx = 1;
			else if (e.KeyCode == Keys.Up) dy = -1;
			else if (e.KeyCode == Keys.Down) dy = 1;
			else if (e.KeyCode == Keys.Left) dx = -1;
			else if (e.KeyCode == Keys.Right) dx = 1;
			else return;

			MoveHedgehog(dx, dy);
		}

		void MoveHedgehog(int dx, int dy)
		{
			int nx = hedgehogPos.X + dx;
			int ny = hedgehogPos.Y + dy;

			if (nx < 0 || ny < 0 || nx >= GridSize || ny >= GridSize)
				return;

			if (grid[nx, ny] == '#')
				return;

			hedgehogPos = new Point(nx, ny);

			if (grid[nx, ny] == 'A')
			{
				applesCollected++;
				grid[nx, ny] = '.';
			}

			if (grid[nx, ny] == 'E')
			{
				if (applesCollected == totalApplesInLevel)
				{
					currentLevelIndex++;
					LoadLevel(currentLevelIndex);
					return;
				}
				else
				{
					MessageBox.Show("Спочатку зберіть всі яблука!", "Потрібно зібрати яблука", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			UpdateInfoLabel();
			canvas.Invalidate();
		}
	}
}
