using System;

namespace ConsoleApp5;

class Camera
{
	// тут приватні поля (інкапсуляція)
	private string? model; // може бути null
	private string? manufacturer; // може бути null
	private double megapixels;
	private int batteryCapacity; // у міліамперах
	private double weight;       // у грамах
	private decimal price;
	private int releaseYear;
	private bool hasWiFi;
	private bool hasInterchangeableLens;

	// властивості 'public' контролюють доступ до приватних полів
	public string Model
	{
		get { return model ?? "Unknown"; } // якщо model null, повертаємо "Unknown"
		set
		{
			if (string.IsNullOrWhiteSpace(value)) // перевірка на null або порожній рядок
				model = "Unknown";
			else
				model = value.Trim();
		}
	}

	public string Manufacturer
	{
		get { return manufacturer ?? "Unknown"; } // якщо manufacturer null, повертаємо "Unknown"
		set
		{
			if (string.IsNullOrWhiteSpace(value)) // те ж саме
				manufacturer = "Unknown";
			else
				manufacturer = value.Trim();
		}
	}

	public double Megapixels
	{
		get { return megapixels; }
		set
		{
			if (value < 1) megapixels = 1;        // мінімум 1
			else if (value > 200) megapixels = 200; // верхня межа, бо камер з 1000 Мп нема
			else megapixels = value;
		}
	}

	public int BatteryCapacity
	{
		get { return batteryCapacity; }
		set
		{
			if (value < 500) batteryCapacity = 500;    // не менше 500 mAh
			else if (value > 10000) batteryCapacity = 10000; // максимум 10 000
			else batteryCapacity = value;
		}
	}

	public double Weight
	{
		get { return weight; }
		set
		{
			if (value < 100) weight = 100;     // занадто легка камера це малоймовірно
			else if (value > 5000) weight = 5000; // обмеження для реалістичності
			else weight = value;
		}
	}

	public decimal Price
	{
		get { return price; }
		set
		{
			if (value <= 0) price = 1;       // мінімум $1
			else if (value > 100000) price = 100000; // верхня межа
			else price = value;
		}
	}

	public int ReleaseYear
	{
		get { return releaseYear; }
		set
		{
			if (value < 1900) releaseYear = 1900;   // перші камери існували ще раніше, але ми ставимо межу
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

	
	public Camera() // конструктор за замовчуванням
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

	public Camera(string model, string manufacturer, double megapixels, // констрюктор з параметрами
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

	// ціна за мегапіксель - сенсу в методі немає, але для прикладу
	public decimal GetPricePerMegapixel()
	{
		return Price / (decimal)Megapixels; // перетворюємо Megapixels у decimal для точності - кастинг
	}

	// перевірка сучасності (перевантажений)
	public bool IsModern()
	{
		return ReleaseYear >= 2020;
	}

	public bool IsModern(int minYear, bool requireWiFi)
	{
		return ReleaseYear >= minYear && (!requireWiFi || HasWiFi);
	}

	// розрахунок фото на одному заряді (умовна формула)
	public int EstimatePhotosPerCharge()
	{
		return BatteryCapacity / 10; // умовно: 10 mAh = 1 фото
	}

	// перевизначення ToString()
	public override string ToString()
	{
		return $"Модель: {Model}, Виробник: {Manufacturer}, " +
			   $"{Megapixels} Мп, Ціна: {Price} USD, Рік: {ReleaseYear}, " +
			   $"WiFi: {(HasWiFi ? "так" : "ні")}, Змінний об’єктив: {(HasInterchangeableLens ? "так" : "ні")}";
	}
}
