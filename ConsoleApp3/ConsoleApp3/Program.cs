using System;

class Program
{
	// функція відповідно до мого варіанту 5
	static double f(double x) // static тому, що вона не залежить від стану об'єкта класу ... повертає дабл
	{
		return 23 * Math.Pow(Math.Sin(25000 * Math.Pow(x, 8)), 2) + 4 * x + Math.Cos(10 * Math.Pow(x, 2));
	}

	static void Main(string[] args)
	{
		while (true) // сюди повертаємось завжди при введенні "так" або "yes"
		{
			try // обгортаємо в блок try-catch для обробки помилок введення
			{
				// крок 1 - Введення
				Console.WriteLine("Введіть початок відрізка інтегруванн (a), кінець відрізка інтегрування (b), кількість інтервалів інтегрування (n) ЧЕРЕЗ ПРОБІЛ!!!");
				string[] data = Console.ReadLine()!.Split(' '); // always not null

				double a = Convert.ToDouble(data[0]);
				double b = Convert.ToDouble(data[1]);
				int n = Convert.ToInt32(data[2]);

				if (a >= b || n <= 0) // початок відрізка a не може бути більшим або рівним кінцю b
				{
					Console.WriteLine("Помилка: Значення 'a' має бути меншим за 'b', а 'n' - додатним числом.");
					continue; // повернутися до початку циклу, повторити введення
				}

				// крок 2 - розрахунок кроку
				double dx = (b - a) / n;
				double integralSum = 0.0;

				// крок 3 - обчислення (метод правих прямокутників)
				for (int i = 0; i < n; i++)
				{
					double xi = a + (i + 1) * dx; // права межа інтервалу
					integralSum += f(xi) * dx;   // додаємо площу прямокутника до загальної суми
				}

				// крок 4 - виведення результату з форматуванням
				Console.WriteLine($"\nРезультат обчислення інтегралу: {integralSum:F5}"); // для варіантів, номери яких закінчуються на 4...6 – використати метод правих прямокутників; при виводі результату виводити 5 знаків після коми;

				// крок 5 - запит на повторний розрахунок
				Console.WriteLine("\nХочете здійснити ще один розрахунок? (так/ні)");
				string response = Console.ReadLine()!.ToLower();
				if (response != "так" && response != "yes")
				{
					break;
				}
			}
			catch (FormatException) // помилка виникає, коли формат вхідного рядка не відповідає очікуваному типу даних
			{
				Console.WriteLine("Помилка: Введено некоректні дані. Будь ласка, введіть числові значення.");
			}
			catch (Exception ex) //  ловить будь-яку іншу помилку, яка не була оброблена попередніми catch блоками
			{
				Console.WriteLine($"Виникла непередбачувана помилка: {ex.Message}");
			}

			Console.WriteLine(); // для кращої читабельності
		}
	}
}