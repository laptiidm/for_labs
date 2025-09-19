internal class Program
{
	private static void Main(string[] args)
	{
		Console.Write("Введiть початкове значення Xmin: ");
		string? sxMin = Console.ReadLine();
		double xMin = double.Parse(sxMin ?? throw new ArgumentNullException(nameof(sxMin)));

		Console.Write("Введiть кiнцеве значення Xmax: ");
		string? sxMax = Console.ReadLine();
		double xMax = double.Parse(sxMax ?? throw new ArgumentNullException(nameof(sxMax)));

		Console.Write("Введiть прирiст dX: ");
		string? sdx = Console.ReadLine();
		double dx = double.Parse(sdx ?? throw new ArgumentNullException(nameof(sdx)));

		double x = xMin;
		double y;
		double sum = 0;

		while (x <= xMax)
		{
			double x1 = x;
			double x2 = 3 * x;

			y = (6 - Math.Cos(3 + x1)) / (34 - 9 * Math.Pow(x2, 3) + x2);

			Console.WriteLine("x = {0}\t\ty = {1}", x, y);

			sum += y; 
			x += dx;
		}

		// 
		if (Math.Abs(x - xMax - dx) > 0.0001)
		{
			double x1 = xMax;
			double x2 = 3 * xMax;

			y = (6 - Math.Cos(3 + x1)) / (34 - 9 * Math.Pow(x2, 3) + x2);

			Console.WriteLine("x = {0}\t\ty = {1}", xMax, y);

			sum += y;
		}

		Console.WriteLine("\nСума всiх значень f(x) = {0}", sum);

		Console.ReadKey();
	}
}
