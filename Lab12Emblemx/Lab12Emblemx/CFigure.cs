using System.Drawing;

namespace Lab12Emblemx
{
	abstract class CFigure
	{
		protected Graphics graphics;

		public int X { get; set; }
		public int Y { get; set; }

		public void SetGraphics(Graphics g)
		{
			graphics = g;
		}

		protected abstract void Draw(Pen pen);

		public void Show()
		{
			Draw(Pens.Red);
		}

		public void Hide()
		{
			Draw(Pens.White);
		}

		public void Move(int dX, int dY)
		{
			Hide();
			X += dX;
			Y += dY;
			Show();
		}

		public abstract void Expand(int delta);
		public abstract void Collapse(int delta);
	}
}
