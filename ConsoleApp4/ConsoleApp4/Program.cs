using System;
using System.Linq; // для LINQ методів

class Program
{
	// константи згідно завдання
	const double A = 2.76;
	const double B = 0.5;

	// статична функція f(x) де константи вираховуються
	static double f(double x)
	{
		double x1 = A * x;
		double x2 = B * x;

		return (Math.Pow(Math.Sin(x1), 3) + 45 + x2) / (2 * Math.Pow(x1, 4) + 4 * x2);
	}

	static void Main()
	{
		int n = 10; 
		double[] arr = new double[n];

		// зповнення масив значеннями функції
		for (int i = 0; i < n; i++)
		{
			double x = i + 1; // наприклад, x від 1 до n
			arr[i] = f(x);
		}

		// за спаданням
		Array.Sort(arr);
		Array.Reverse(arr);

		// виведення масиву
		Console.WriteLine("Відсортовані за спаданням значення масиву:");
		for (int i = 0; i < arr.Length; i++)
		{
			Console.WriteLine($"arr[{i:D2}] = {arr[i]:F6}");
		}

		// min, max, avg
		double aMin = arr.Min();
		double aMax = arr.Max();
		double aAvg = arr.Average();

		// вивід min, max, avg
		Console.WriteLine($"\nМінімальне значення масиву: {aMin:F6}");
		Console.WriteLine($"Максимальне значення масиву: {aMax:F6}");
		Console.WriteLine($"Середнє значення масиву: {aAvg:F6}");

		// обчислення R
		//З масиву arr вибираються всі елементи, значення яких лежать у діапазоні від aMin до aMin + 10% від aMin.
		//Потім обчислюється сума цих елементів, і результат записується у змінну R."
		//Тобто кроки:
		//Where(...) – відфільтровує елементи, які задовольняють умові aMin ≤ v ≤ upperBound.
		//.Sum() – підсумовує всі такі елементи.
		//R – отримує суму елементів, що потрапили у вказаний інтервал.

		double upperBound = aMin + 0.1 * aMin;
		double R = arr.Where(v => v >= aMin && v <= upperBound).Sum();

		Console.WriteLine($"\nЗначення R: {R:F6}");
	}
}
