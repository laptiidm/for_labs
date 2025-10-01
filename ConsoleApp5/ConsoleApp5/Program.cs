using System;

namespace ConsoleApp5;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");
		_ = new Camera(); // це "змінна-заглушка" (discard)

		Camera cam = new Camera
		{
			Model = "X100V",
			Manufacturer = "Fujifilm",
			Megapixels = 26.1,
			BatteryCapacity = 1260,
			Weight = 478,
			Price = 1399.99m,
			ReleaseYear = 2020,
			HasWiFi = true,
			HasInterchangeableLens = false
		};

		Console.WriteLine("\n📷 Інформація про фотоапарат:");
		Console.WriteLine(cam.ToString());

		Console.WriteLine("\n🔹 Розрахунки:");
		Console.WriteLine($"Ціна за 1 Мп: {cam.GetPricePerMegapixel():0.00} $/Мп");
		Console.WriteLine($"Фото на одному заряді: {cam.EstimatePhotosPerCharge()} знімків");
		Console.WriteLine($"Чи сучасна модель (після 2020 року): {(cam.IsModern() ? "так" : "ні")}");
		Console.WriteLine($"Чи сучасна (мінімум 2018, WiFi обов'язковий): {(cam.IsModern(2018, true) ? "так" : "ні")}");


	}
}