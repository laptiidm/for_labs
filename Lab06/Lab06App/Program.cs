using System;          // потрібен для Console.WriteLine, Console.ReadKey
using System.IO;       // потрібен для File.ReadAllText
using System.Text.Json;// потрібен для JsonSerializer
using Lab06Lib;        // потрібен, щоб бачити клас Camera з бібліотеки


namespace Lab06App
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// читаємо JSON з файлу
			string json = File.ReadAllText("cameras.json");

			// десеріалізуємо в масив об’єктів Camera
			Camera[]? cameras = JsonSerializer.Deserialize<Camera[]>(json);

			if (cameras == null)
			{
				Console.WriteLine("Помилка: JSON не розпарсений");
				return;
			}


			// виводимо інформацію
			foreach (Camera cam in cameras)
			{
				Console.WriteLine("\n=================================");
				Console.WriteLine(cam.ToString());
				Console.WriteLine($"Ціна за мегапіксель: {cam.GetPricePerMegapixel():0.00} USD");
				Console.WriteLine($"Фото на одному заряді: {cam.EstimatePhotosPerCharge()} шт.");
				Console.WriteLine(cam.IsModern() ? "Сучасна модель" : "Стара модель");
			}

			Console.ReadKey();
		}
	}
}
