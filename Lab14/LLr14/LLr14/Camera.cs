using System;

[Serializable]
public class Camera : IComparable<Camera>
{
	public string Model { get; set; }
	public string Manufacturer { get; set; }
	public double Megapixels { get; set; }
	public int BatteryCapacity { get; set; }
	public double Weight { get; set; }
	public decimal Price { get; set; }
	public int ReleaseYear { get; set; }
	public bool HasWiFi { get; set; }
	public bool HasInterchangeableLens { get; set; }

	public Camera() { }

	public Camera(string model, string manufacturer, double mp, int battery,
				  double weight, decimal price, int year, bool wifi, bool lens)
	{
		Model = model;
		Manufacturer = manufacturer;
		Megapixels = mp;
		BatteryCapacity = battery;
		Weight = weight;
		Price = price;
		ReleaseYear = year;
		HasWiFi = wifi;
		HasInterchangeableLens = lens;
	}

	public int CompareTo(Camera other)
	{
		if (other == null) return 1;
		return Model.CompareTo(other.Model);
	}

	public override string ToString()
	{
		return $"{Model,-20}  {Manufacturer,-10}  {Megapixels,5} Mp  " +
			   $"{BatteryCapacity,5} mAh  {Weight,5} g  {Price,8}$  " +
			   $"{ReleaseYear}  WiFi:{HasWiFi}  Lens:{HasInterchangeableLens}";
	}
}
