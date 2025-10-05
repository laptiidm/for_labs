#include "thingProperties.h"
#include <WiFiS3.h>
#include <ArduinoJson.h>

// Wi-Fi (якщо не підключається автоматично через Cloud)
char ssid[] = "TP-Link_1A10";
char pass[] = "14205286";

// OpenWeatherMap API
const char* weatherServer = "api.openweathermap.org";
int weatherPort = 80; // HTTP
String apiKey = "b746d9d306f889be82b47138df15f20a";
String city = "Zhytomyr";

WiFiClient client;  // замінили WiFiSSLClient на WiFiClient для HTTP

void setup() {
  Serial.begin(115200);
  delay(1500);

  Serial.println("Connecting to Arduino Cloud...");
  initProperties();
  ArduinoCloud.begin(ArduinoIoTPreferredConnection);

  if (WiFi.status() != WL_CONNECTED) {
    WiFi.begin(ssid, pass);
    while (WiFi.status() != WL_CONNECTED) {
      delay(500);
      Serial.print(".");
    }
    Serial.println("\nWiFi connected!");
  }
}

void loop() {
  ArduinoCloud.update();

  if (client.connect(weatherServer, weatherPort)) {
    String url = "/data/2.5/weather?q=" + city + "&appid=" + apiKey + "&units=metric";

    // HTTP GET
    client.println("GET " + url + " HTTP/1.1");
    client.println("Host: " + String(weatherServer));
    client.println("Connection: close");
    client.println();

    // Пропускаємо заголовки
    while (client.connected()) {
      String line = client.readStringUntil('\n');
      if (line == "\r") break;
    }

    String payload = client.readString();
    payload.trim();

    StaticJsonDocument<1024> doc;
    DeserializationError error = deserializeJson(doc, payload);

    if (!error) {
      temperature = doc["main"]["temp"];
      humidity = doc["main"]["humidity"];

      Serial.print("🌡 Temperature: ");
      Serial.print(temperature);
      Serial.print(" °C  |  💧 Humidity: ");
      Serial.print(humidity);
      Serial.println(" %");
    } else {
      Serial.println("JSON parse error ❌");
    }

    client.stop();
  } else {
    Serial.println("Failed to connect to OpenWeatherMap ❌");
  }

  delay(15000); // оновлення кожні 15 секунд
}
