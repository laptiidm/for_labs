using System;
using System.Drawing;

namespace EmblemDemo
{
	public class CEmblem
	{
		private const int DefaultSize = 150; // diameter of outer circle

		private readonly Graphics _graphics;
		private int _size;

		public int X { get; set; } // center X
		public int Y { get; set; } // center Y

		public int Size
		{
			get => _size;
			set
			{
				if (value < 40)
					_size = 40;
				else if (value > 400)
					_size = 400;
				else
					_size = value;
			}
		}

		public CEmblem(Graphics graphics, int x, int y)
			: this(graphics, x, y, DefaultSize)
		{
		}

		public CEmblem(Graphics graphics, int x, int y, int size)
		{
			_graphics = graphics;
			X = x;
			Y = y;
			Size = size;
		}

		private void Draw(Pen pen)
		{
			float R = Size / 2f;

			// 1. Outer circle
			RectangleF outerRect = new RectangleF(
				X - R,
				Y - R,
				2 * R,
				2 * R
			);
			_graphics.DrawEllipse(pen, outerRect);

			// 2. Equilateral triangle inscribed into outer circle
			float sin60 = (float)(Math.Sqrt(3.0) / 2.0);
			float cos60 = 0.5f;

			PointF p1 = new PointF(X, Y - R);                    // top
			PointF p2 = new PointF(X - R * sin60, Y + R * cos60); // bottom left
			PointF p3 = new PointF(X + R * sin60, Y + R * cos60); // bottom right

			PointF[] triangle = { p1, p2, p3 };
			_graphics.DrawPolygon(pen, triangle);

			// 3. Inner circle (inscribed in triangle, center is the same)
			float rInner = R / 2f;
			RectangleF innerRect = new RectangleF(
				X - rInner,
				Y - rInner,
				2 * rInner,
				2 * rInner
			);
			_graphics.DrawEllipse(pen, innerRect);
		}

		public void Show()
		{
			Draw(Pens.SteelBlue);
		}

		public void Hide()
		{
			Draw(Pens.White);
		}

		public void Move(int dx, int dy)
		{
			Hide();
			X += dx;
			Y += dy;
			Show();
		}

		public void Expand(int d)
		{
			Hide();
			Size += d;
			Show();
		}

		public void Collapse(int d)
		{
			Hide();
			Size -= d;
			Show();
		}
	}
}
