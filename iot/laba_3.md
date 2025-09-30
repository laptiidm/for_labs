---

## Звіт з лабораторної роботи

**Тема:** Передача даних з плати Arduino Uno R4 WiFi у хмарний сервіс **ThingSpeak**.

### Мета роботи

Навчитися підключати мікроконтролер Arduino до WiFi-мережі, генерувати та надсилати дані у хмарний сервіс для подальшої візуалізації у вигляді графіків.

### Виконання

1. Спочатку було налагоджено з’єднання плати з локальною мережею WiFi.

   * Перевірялась коректність підключення (вивід SSID, IP, RSSI в Serial Monitor).
   * Додано перевірку доступу до Інтернету через HTTP-запит.

2. Під час роботи виникли складнощі:

   * сторінка вебсервера на платі не відкривалась при підключенні через роутер (було потрібно діагностувати мережеву ізоляцію та правила фаєрволу),
   * вдалося підтвердити доступність плати через **ping** з роутера, але не напряму з ПК,
   * було вирішено відмовитись від локальної форми в браузері та перейти до прямої інтеграції з **ThingSpeak**.

3. Оскільки реальні датчики були відсутні, дані імітувались за допомогою функції `random()`.

   * **field1** — умовна температура (20–30 °C),
   * **field2** — умовна вологість (50–80 %).

4. Дані відправлялися кожні **30 секунд** протягом **3 хвилин** (сесія).

   * Після завершення сесії передача автоматично зупинялась.
   * На сервісі ThingSpeak будувались графіки за переданими значеннями.

### Результат

* Плата Arduino Uno R4 WiFi успішно підключилась до мережі.
* Дані генерувались та надсилались у ThingSpeak у правильному форматі.
* У каналі ThingSpeak були побудовані графіки, які можна переглянути навіть після вимкнення плати (дані зберігаються в хмарі).

### Висновок

У ході лабораторної роботи було отримано практичні навички:

* роботи з бібліотекою **WiFiS3**,
* налаштування мережевих з’єднань Arduino,
* інтеграції мікроконтролера з хмарним сервісом **ThingSpeak**,
* емуляції показів датчиків.

Основна складність була пов’язана з мережевою ізоляцією при доступі до локального вебсервера, але завдання вдалося виконати через пряме надсилання даних у хмару.

---
### Код

```cpp
#include <WiFiS3.h>
#include "arduino_secrets.h"

char ssid[] = SECRET_SSID;
char pass[] = SECRET_PASS;
String apiKey = SECRET_APIKEY;

char server[] = "api.thingspeak.com";
WiFiClient client;

unsigned long lastUpdate = 0;
const long interval = 30000;     // 30 сек
int sessionDuration = 180000;    // 3 хв
unsigned long sessionStart = 0;
bool sessionActive = false;

void setup() {
  Serial.begin(9600);

  Serial.print("Connecting to WiFi: ");
  Serial.println(ssid);
  WiFi.begin(ssid, pass);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nConnected to WiFi!");
  Serial.print("IP: ");
  Serial.println(WiFi.localIP());

  startSession(); // стартуємо одразу
}

void loop() {
  if (sessionActive) {
    unsigned long now = millis();

    if (now - sessionStart > sessionDuration) {
      sessionActive = false;
      Serial.println("Session finished");
    }

    if (now - lastUpdate > interval) {
      lastUpdate = now;

      float sensor1 = random(20, 30);  // температура
      float sensor2 = random(50, 80);  // вологість

      sendToThingSpeak(sensor1, sensor2);
    }
  }
}

void startSession() {
  sessionActive = true;
  sessionStart = millis();
  Serial.println("Session started");
}

void sendToThingSpeak(float s1, float s2) {
  if (client.connect(server, 80)) {
    String url = "GET /update?api_key=" + apiKey +
                 "&field1=" + String(s1) +
                 "&field2=" + String(s2) + " HTTP/1.1\r\n" +
                 "Host: " + String(server) + "\r\n" +
                 "Connection: close\r\n\r\n";

    client.print(url);
    Serial.println("Sent: " + url);

    client.stop();
  } else {
    Serial.println("Connection to ThingSpeak failed");
  }
}

```
