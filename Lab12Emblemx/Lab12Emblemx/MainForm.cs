using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab12Emblemx
{
	public class MainForm : Form
	{
		private Panel pnMain;
		private Panel pnTools;

		private Button btnShow;
		private Button btnHide;
		private Button btnUp;
		private Button btnDown;
		private Button btnLeft;
		private Button btnRight;
		private Button btnGrow;
		private Button btnShrink;

		private CEmblem emblem;

		public MainForm()
		{
			Text = "Lab12 – Emblem";
			StartPosition = FormStartPosition.CenterScreen;
			Width = 900;
			Height = 600;

			InitializeLayout();
		}

		private void InitializeLayout()
		{
			pnMain = new Panel
			{
				BackColor = Color.White,
				Dock = DockStyle.Fill,
				BorderStyle = BorderStyle.FixedSingle
			};
			pnMain.Paint += PnMain_Paint;
			Controls.Add(pnMain);

			pnTools = new Panel
			{
				Dock = DockStyle.Right,
				Width = 200,
				BackColor = Color.Gainsboro
			};
			Controls.Add(pnTools);

			btnShow = MakeButton("Show", 20, BtnShow_Click);
			btnHide = MakeButton("Hide", 60, BtnHide_Click);
			btnGrow = MakeButton("Grow", 100, BtnGrow_Click);
			btnShrink = MakeButton("Shrink", 140, BtnShrink_Click);
			btnUp = MakeButton("Up", 200, BtnUp_Click);
			btnDown = MakeButton("Down", 240, BtnDown_Click);

			btnLeft = MakeButton("Left", 280, BtnLeft_Click, 75);
			btnRight = MakeButton("Right", 280, BtnRight_Click, 75, 105);
		}

		private Button MakeButton(string text, int top, EventHandler action, int width = 160, int left = 20)
		{
			Button b = new Button
			{
				Text = text,
				Width = width,
				Location = new Point(left, top)
			};
			b.Click += action;
			pnTools.Controls.Add(b);
			return b;
		}

		private void PnMain_Paint(object sender, PaintEventArgs e)
		{
			if (emblem == null)
			{
				emblem = new CEmblem(
					e.Graphics,
					pnMain.Width / 2,
					pnMain.Height / 2,
					80);
			}

			emblem.SetGraphics(e.Graphics);
			emblem.Show();
		}

		private void BtnShow_Click(object sender, EventArgs e)
		{
			pnMain.Invalidate();
		}

		private void BtnHide_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Hide();
		}

		private void BtnGrow_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Expand(10);
		}

		private void BtnShrink_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Collapse(10);
		}

		private void BtnUp_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Move(0, -10);
		}

		private void BtnDown_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Move(0, 10);
		}

		private void BtnLeft_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Move(-10, 0);
		}

		private void BtnRight_Click(object sender, EventArgs e)
		{
			emblem.SetGraphics(pnMain.CreateGraphics());
			emblem.Move(10, 0);
		}
	}
}
