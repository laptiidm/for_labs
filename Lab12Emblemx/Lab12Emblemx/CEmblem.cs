using Lab12Emblemx;
using System;
using System.Drawing;

namespace Lab12Emblemx
{
	// 
	class CEmblem : CFigure
	{
		private int _size;

		public int Size
		{
			get => _size;
			set
			{
				if (value < 20) value = 20;
				if (value > 200) value = 200;
				_size = value;
			}
		}

		public CEmblem(Graphics g, int x, int y, int size)
		{
			graphics = g;
			X = x;
			Y = y;
			Size = size;
		}

		protected override void Draw(Pen pen)
		{
			int R = Size;              // радіус великого кола
			int rInner = R / 2;        // радіус внутрішнього кола

			// 1) Велике коло
			graphics.DrawEllipse(
				pen,
				X - R,
				Y - R,
				2 * R,
				2 * R
			);

			// 2) Рівносторонній трикутник, вершини на колі
			// Кути у радіанах: -90°, 30°, 150°
			double a1 = -Math.PI / 2;        // верхня вершина
			double a2 = Math.PI / 6;         // права нижня
			double a3 = 5 * Math.PI / 6;     // ліва нижня

			Point p1 = new Point(
				X + (int)(R * Math.Cos(a1)),
				Y + (int)(R * Math.Sin(a1))
			);

			Point p2 = new Point(
				X + (int)(R * Math.Cos(a2)),
				Y + (int)(R * Math.Sin(a2))
			);

			Point p3 = new Point(
				X + (int)(R * Math.Cos(a3)),
				Y + (int)(R * Math.Sin(a3))
			);

			graphics.DrawPolygon(pen, new[] { p1, p2, p3 });

			// 3) Внутрішнє коло по центру
			graphics.DrawEllipse(
				pen,
				X - rInner,
				Y - rInner,
				2 * rInner,
				2 * rInner
			);
		}

		public override void Expand(int delta)
		{
			Hide();
			Size += delta;
			Show();
		}

		public override void Collapse(int delta)
		{
			Hide();
			Size -= delta;
			Show();
		}
	}
}
