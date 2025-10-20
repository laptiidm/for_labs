using System;

namespace Lab8
{
	public class Camera
	{
		private string model;
		private string manufacturer;
		private double megapixels;
		private int batteryCapacity;
		private double weight;
		private decimal price;
		private int releaseYear;
		private bool hasWiFi;
		private bool hasInterchangeableLens;

		public string Model
		{
			get { return model ?? "Unknown"; }
			set { model = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim(); }
		}

		public string Manufacturer
		{
			get { return manufacturer ?? "Unknown"; }
			set { manufacturer = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim(); }
		}

		public double Megapixels
		{
			get { return megapixels; }
			set
			{
				if (value < 1) megapixels = 1;
				else if (value > 200) megapixels = 200;
				else megapixels = value;
			}
		}

		public int BatteryCapacity
		{
			get { return batteryCapacity; }
			set
			{
				if (value < 500) batteryCapacity = 500;
				else if (value > 10000) batteryCapacity = 10000;
				else batteryCapacity = value;
			}
		}

		public double Weight
		{
			get { return weight; }
			set
			{
				if (value < 100) weight = 100;
				else if (value > 5000) weight = 5000;
				else weight = value;
			}
		}

		public decimal Price
		{
			get { return price; }
			set
			{
				if (value <= 0) price = 1;
				else if (value > 100000) price = 100000;
				else price = value;
			}
		}

		public int ReleaseYear
		{
			get { return releaseYear; }
			set
			{
				if (value < 1900) releaseYear = 1900;
				else if (value > DateTime.Now.Year) releaseYear = DateTime.Now.Year;
				else releaseYear = value;
			}
		}

		public bool HasWiFi
		{
			get { return hasWiFi; }
			set { hasWiFi = value; }
		}

		public bool HasInterchangeableLens
		{
			get { return hasInterchangeableLens; }
			set { hasInterchangeableLens = value; }
		}

		public Camera()
		{
			Model = "Unknown";
			Manufacturer = "Unknown";
			Megapixels = 12;
			BatteryCapacity = 1500;
			Weight = 400;
			Price = 500;
			ReleaseYear = DateTime.Now.Year;
			HasWiFi = false;
			HasInterchangeableLens = false;
		}

		public Camera(string model, string manufacturer, double megapixels,
			int batteryCapacity, double weight, decimal price,
			int releaseYear, bool hasWiFi, bool hasInterchangeableLens)
		{
			Model = model;
			Manufacturer = manufacturer;
			Megapixels = megapixels;
			BatteryCapacity = batteryCapacity;
			Weight = weight;
			Price = price;
			ReleaseYear = releaseYear;
			HasWiFi = hasWiFi;
			HasInterchangeableLens = hasInterchangeableLens;
		}

		public decimal GetPricePerMegapixel()
		{
			return Price / (decimal)Megapixels;
		}

		public bool IsModern()
		{
			return ReleaseYear >= 2020;
		}

		public bool IsModern(int minYear, bool requireWiFi)
		{
			return ReleaseYear >= minYear && (!requireWiFi || HasWiFi);
		}

		public int EstimatePhotosPerCharge()
		{
			return BatteryCapacity / 10;
		}

		public override string ToString()
		{
			return $"Модель: {Model}, Виробник: {Manufacturer}, {Megapixels} Мп, " +
				   $"Ціна: {Price} USD, Рік: {ReleaseYear}, " +
				   $"WiFi: {(HasWiFi ? "так" : "ні")}, Змінний об’єктив: {(HasInterchangeableLens ? "так" : "ні")}";
		}
	}
}

