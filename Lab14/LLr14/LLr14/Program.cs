using System;
using System.Collections.Generic;
using System.IO;

class Program
{
	static void Main()
	{

		Console.OutputEncoding = System.Text.Encoding.UTF8;

		string filePath = @"C:\Onedrive\Desktop\somecamBIN.cams";

		if (!File.Exists(filePath))
		{
			Console.WriteLine("Файл не знайдено: " + filePath);
			return;
		}

		List<Camera> cameras = LoadFromBinary(filePath);

		Console.WriteLine("=== Дані, прочитані з BIN ===");
		Print(cameras);

		cameras.Sort();
		Console.WriteLine("\n=== Після сортування ===");
		Print(cameras);

		cameras.Add(new Camera("Alpha A7IV", "Sony", 33, 2280, 658, 2499, 2021, true, true));
		cameras.Sort();

		Console.WriteLine("\n=== Після додавання нової камери ===");
		Print(cameras);

		if (cameras.Count > 0)
			cameras.RemoveAt(cameras.Count - 1);

		Console.WriteLine("\n=== Після видалення останньої камери ===");
		Print(cameras);

		SaveToBinary(filePath, cameras);

		Console.WriteLine("\nГотово.");
	}

	static void Print(List<Camera> cams)
	{
		foreach (var cam in cams)
			Console.WriteLine(cam);
	}

	static List<Camera> LoadFromBinary(string path)
	{
		List<Camera> list = new List<Camera>();

		using (var br = new BinaryReader(File.OpenRead(path)))
		{
			while (br.BaseStream.Position < br.BaseStream.Length)
			{
				string model = br.ReadString();
				string manufacturer = br.ReadString();
				double mp = br.ReadDouble();
				int battery = br.ReadInt32();
				double weight = br.ReadDouble();
				decimal price = br.ReadDecimal();
				int year = br.ReadInt32();
				bool wifi = br.ReadBoolean();
				bool lens = br.ReadBoolean();

				list.Add(new Camera(model, manufacturer, mp, battery, weight, price, year, wifi, lens));
			}
		}

		return list;
	}

	static void SaveToBinary(string path, List<Camera> cams)
	{
		using (var bw = new BinaryWriter(File.Create(path)))
		{
			foreach (var cam in cams)
			{
				bw.Write(cam.Model);
				bw.Write(cam.Manufacturer);
				bw.Write(cam.Megapixels);
				bw.Write(cam.BatteryCapacity);
				bw.Write(cam.Weight);
				bw.Write(cam.Price);
				bw.Write(cam.ReleaseYear);
				bw.Write(cam.HasWiFi);
				bw.Write(cam.HasInterchangeableLens);
			}
		}
	}
}
