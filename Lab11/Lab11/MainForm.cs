using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace EmblemDemo
{
	public class MainForm : Form
	{
		private Panel pnMain;
		private Panel pnTools;

		private ComboBox cbEmblems;
		private Button btnCreate;
		private Button btnHide;
		private Button btnShow;

		private Button btnUp;
		private Button btnDown;
		private Button btnLeft;
		private Button btnRight;
		private Button btnUpFar;
		private Button btnDownFar;
		private Button btnLeftFar;
		private Button btnRightFar;
		private Button btnExpand;
		private Button btnCollapse;

		private readonly CEmblem[] _emblems;
		private int _emblemCount;
		private int _currentEmblemIndex = -1;

		public MainForm()
		{
			Text = "Emblem Class Demo";
			StartPosition = FormStartPosition.CenterScreen;
			ClientSize = new Size(900, 500);

			_emblems = new CEmblem[100];

			InitializeLayout();
		}

		private void InitializeLayout()
		{
			// Drawing panel
			pnMain = new Panel
			{
				Name = "pnMain",
				BackColor = Color.White,
				BorderStyle = BorderStyle.FixedSingle,
				Dock = DockStyle.Fill
			};

			// Tools panel
			pnTools = new Panel
			{
				Name = "pnTools",
				Dock = DockStyle.Right,
				Width = 260
			};

			Controls.Add(pnMain);
			Controls.Add(pnTools);

			// Label + combo
			Label lblList = new Label
			{
				Text = "Перелік об'єктів",
				AutoSize = true,
				Location = new Point(10, 15)
			};

			cbEmblems = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				Location = new Point(10, 40),
				Width = 230
			};
			cbEmblems.SelectedIndexChanged += (sender, args) =>
			{
				_currentEmblemIndex = cbEmblems.SelectedIndex;
			};

			// Buttons create/hide/show
			btnCreate = new Button
			{
				Text = "Створити новий об'єкт",
				Location = new Point(10, 80),
				Width = 230
			};
			btnCreate.Click += BtnCreate_Click;

			btnHide = new Button
			{
				Text = "Приховати об'єкт",
				Location = new Point(10, 115),
				Width = 230
			};
			btnHide.Click += BtnHide_Click;

			btnShow = new Button
			{
				Text = "Показати об'єкт",
				Location = new Point(10, 150),
				Width = 230
			};
			btnShow.Click += BtnShow_Click;

			pnTools.Controls.Add(lblList);
			pnTools.Controls.Add(cbEmblems);
			pnTools.Controls.Add(btnCreate);
			pnTools.Controls.Add(btnHide);
			pnTools.Controls.Add(btnShow);

			// Movement / size buttons (простий хрест)
			int size = 40;
			int gap = 5;
			int centerX = 120;
			int centerY = 250;

			btnUp = new Button
			{
				Text = "↑",
				Width = size,
				Height = size,
				Location = new Point(centerX, centerY - (size + gap))
			};
			btnUp.Click += (s, e) => MoveCurrent(0, -10);

			btnDown = new Button
			{
				Text = "↓",
				Width = size,
				Height = size,
				Location = new Point(centerX, centerY + (size + gap))
			};
			btnDown.Click += (s, e) => MoveCurrent(0, 10);

			btnLeft = new Button
			{
				Text = "←",
				Width = size,
				Height = size,
				Location = new Point(centerX - (size + gap), centerY)
			};
			btnLeft.Click += (s, e) => MoveCurrent(-10, 0);

			btnRight = new Button
			{
				Text = "→",
				Width = size,
				Height = size,
				Location = new Point(centerX + (size + gap), centerY)
			};
			btnRight.Click += (s, e) => MoveCurrent(10, 0);

			btnExpand = new Button
			{
				Text = "+",
				Width = size,
				Height = size,
				Location = new Point(centerX, centerY)
			};
			btnExpand.Click += (s, e) => ChangeSizeCurrent(+5);

			btnCollapse = new Button
			{
				Text = "-",
				Width = size,
				Height = size,
				Location = new Point(centerX, centerY + 2 * (size + gap))
			};
			btnCollapse.Click += (s, e) => ChangeSizeCurrent(-5);

			// Far movement (анімація)
			btnUpFar = new Button
			{
				Text = "↑↑",
				Width = size,
				Height = size,
				Location = new Point(centerX, centerY - 2 * (size + gap))
			};
			btnUpFar.Click += (s, e) => MoveCurrentAnimated(0, -1);

			btnDownFar = new Button
			{
				Text = "↓↓",
				Width = size,
				Height = size,
				Location = new Point(centerX, centerY + 3 * (size + gap))
			};
			btnDownFar.Click += (s, e) => MoveCurrentAnimated(0, 1);

			btnLeftFar = new Button
			{
				Text = "←←",
				Width = size,
				Height = size,
				Location = new Point(centerX - 2 * (size + gap), centerY)
			};
			btnLeftFar.Click += (s, e) => MoveCurrentAnimated(-1, 0);

			btnRightFar = new Button
			{
				Text = "→→",
				Width = size,
				Height = size,
				Location = new Point(centerX + 2 * (size + gap), centerY)
			};
			btnRightFar.Click += (s, e) => MoveCurrentAnimated(1, 0);

			pnTools.Controls.Add(btnUp);
			pnTools.Controls.Add(btnDown);
			pnTools.Controls.Add(btnLeft);
			pnTools.Controls.Add(btnRight);
			pnTools.Controls.Add(btnExpand);
			pnTools.Controls.Add(btnCollapse);
			pnTools.Controls.Add(btnUpFar);
			pnTools.Controls.Add(btnDownFar);
			pnTools.Controls.Add(btnLeftFar);
			pnTools.Controls.Add(btnRightFar);
		}

		private void BtnCreate_Click(object sender, EventArgs e)
		{
			if (_emblemCount >= 99)
			{
				MessageBox.Show("Досягнуто межі кількості об'єктів!");
				return;
			}

			Graphics g = pnMain.CreateGraphics();

			_currentEmblemIndex = _emblemCount;
			_emblems[_currentEmblemIndex] = new CEmblem(
				g,
				pnMain.Width / 2,
				pnMain.Height / 2,
				150
			);

			_emblems[_currentEmblemIndex].Show();

			_emblemCount++;
			cbEmblems.Items.Add("Емблема №" + _currentEmblemIndex);
			cbEmblems.SelectedIndex = _currentEmblemIndex;
		}

		private void BtnHide_Click(object sender, EventArgs e)
		{
			if (!HasCurrentEmblem())
				return;

			_emblems[_currentEmblemIndex].Hide();
		}

		private void BtnShow_Click(object sender, EventArgs e)
		{
			if (!HasCurrentEmblem())
				return;

			_emblems[_currentEmblemIndex].Show();
		}

		private bool HasCurrentEmblem()
		{
			return _currentEmblemIndex >= 0 && _currentEmblemIndex < _emblemCount;
		}

		private void MoveCurrent(int dx, int dy)
		{
			if (!HasCurrentEmblem())
				return;

			_emblems[_currentEmblemIndex].Move(dx, dy);
		}

		private void MoveCurrentAnimated(int dx, int dy)
		{
			if (!HasCurrentEmblem())
				return;

			for (int i = 0; i < 100; i++)
			{
				_emblems[_currentEmblemIndex].Move(dx, dy);
				Thread.Sleep(5);
			}
		}

		private void ChangeSizeCurrent(int d)
		{
			if (!HasCurrentEmblem())
				return;

			if (d > 0)
				_emblems[_currentEmblemIndex].Expand(d);
			else
				_emblems[_currentEmblemIndex].Collapse(-d);
		}
	}
}
