internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Введіть X1min, X1max і dx1 через пробіл:");
		string[] parts1 = Console.ReadLine()!.Split(' ');

		double x1min = Convert.ToDouble(parts1[0]);
		double x1max = Convert.ToDouble(parts1[1]);
		double dx1 = Convert.ToDouble(parts1[2]);

		Console.WriteLine("Введіть X2min, X2max і dx2 через пробіл:");
		string[] parts2 = Console.ReadLine()!.Split(' ');

		double x2min = Convert.ToDouble(parts2[0]);
		double x2max = Convert.ToDouble(parts2[1]);
		double dx2 = Convert.ToDouble(parts2[2]);

		double sumOfAllIntermediateResults = 0;

		for (double x1 = x1min; x1 <= x1max; x1 += dx1)
		{
			for (double x2 = x2min; x2 <= x2max; x2 += dx2)
			{

				double result = (3 * x2 - Math.Pow(x1, 2)) / Math.Pow(Math.Cos((x1 + 2 * x2 + 9) / 0.37), 3);
				Console.WriteLine("x1 = {0,-8:F3} | x2 = {1,-8:F3} | result = {2,-15:F6}", x1, x2, result);
				if (result > 0) { sumOfAllIntermediateResults += result; }
			}
		}

		Console.WriteLine(new string('-', 40));
		Console.WriteLine("Сума додатних результатів: {0:F6}", sumOfAllIntermediateResults);
	}
}